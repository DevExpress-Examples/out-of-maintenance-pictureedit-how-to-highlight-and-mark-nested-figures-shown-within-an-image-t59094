using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using System.Collections;

namespace DXApplication7 {
    [UserRepositoryItem("RegisterCustomPictureEdit")]
    public class RepositoryItemCustomPictureEdit : RepositoryItemPictureEdit {
        static RepositoryItemCustomPictureEdit() {
            RegisterCustomPictureEdit();
        }
        public const string CustomEditName = "CustomPictureEdit";
        public RepositoryItemCustomPictureEdit() {
            HighlightFigureColor = Color.FromArgb(100, Color.Blue);
            ActiveFigureColor = Color.FromArgb(100, Color.Orange);
        }
        public override string EditorTypeName {
            get {
                return CustomEditName;
            }
        }
        public static void RegisterCustomPictureEdit() {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(CustomPictureEdit), typeof(RepositoryItemCustomPictureEdit), typeof(CustomPictureEditViewInfo), new CustomPictureEditPainter(), true, img));
        }
        Color highlightFigureColor;
        public Color HighlightFigureColor {
            get { return highlightFigureColor; }
            set {
                if (highlightFigureColor != value) {
                    highlightFigureColor = value;
                    OnPropertiesChanged();
                }
            }
        }
        Color activeFigureColor;
        public Color ActiveFigureColor {
            get { return activeFigureColor; }
            set {
                if (activeFigureColor != value) {
                    activeFigureColor = value;
                    OnPropertiesChanged();
                }
            }
        }
        public override void Assign(RepositoryItem item) {
            BeginUpdate();
            try {
                base.Assign(item);
                RepositoryItemCustomPictureEdit source = item as RepositoryItemCustomPictureEdit;
                if (source == null) return;
                HighlightFigureColor = source.HighlightFigureColor;
                ActiveFigureColor = source.ActiveFigureColor;
            }
            finally {
                EndUpdate();
            }
        }
    }

    [ToolboxItem(true)]
    public class CustomPictureEdit : PictureEdit {
        static CustomPictureEdit() {
            RepositoryItemCustomPictureEdit.RegisterCustomPictureEdit();
        }
        public CustomPictureEdit() { }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomPictureEdit Properties {
            get {
                return base.Properties as RepositoryItemCustomPictureEdit;
            }
        }
        public override string EditorTypeName {
            get {
                return RepositoryItemCustomPictureEdit.CustomEditName;
            }
        }
        NestedFigureCollection nestedFigures;
        public NestedFigureCollection NestedFigures {
            get {
                if (nestedFigures == null) {
                    nestedFigures = new NestedFigureCollection();
                }
                return nestedFigures;
            }
            set {
                if (nestedFigures != value) {
                    nestedFigures = value;
                    OnPropertiesChanged();
                }
            }
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e) {
            base.OnMouseMove(e);
            UpdateNestedFigures(e.Location);
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e) {
            base.OnMouseDown(e);
            ActivateNestedFigures(e.Location);
        }
        protected void UpdateNestedFigures(Point pt) {
            if (NestedFigures.Count > 0) {
                Point imagePoint = ViewportToImage(pt);
                foreach (Figure figure in NestedFigures) {
                    figure.Selected = figure.SourceRect.Contains(imagePoint);
                }
                Invalidate();
            }
        }
        protected void ActivateNestedFigures(Point pt) {
            if (NestedFigures.Count > 0) {
                Point imagePoint = ViewportToImage(pt);
                foreach (Figure figure in NestedFigures) {
                    if(figure.SourceRect.Contains(imagePoint)){
                        figure.Active = !figure.Active;
                        break;
                    }
                }
                Invalidate();
            }
        }
        internal protected Rectangle FigureRectToEditorRect(Figure figure){
            return new Rectangle(ImageToViewport(figure.SourceRect.Location), figure.SourceRect.Size);
        }
         public Image GetImageWithFigures() {
             if (Image == null) return null;
             if(NestedFigures.Count == 0) return Image;
             Image newImage = Image.Clone() as Image;
             using(Graphics graphics = Graphics.FromImage(newImage))
                foreach (Figure figure in NestedFigures) {
                    if(figure.Active){
                        using (SolidBrush brush = new SolidBrush(Properties.ActiveFigureColor)) {
                            graphics.FillRectangle(brush, figure.SourceRect);
                        }
                    }
                }
             return newImage;
        }
    }

    public class CustomPictureEditViewInfo : PictureEditViewInfo {
        public CustomPictureEditViewInfo(RepositoryItem item)
            : base(item) {
        }
    }
    public class CustomPictureEditPainter : PictureEditPainter {
        public CustomPictureEditPainter() {
        }
        protected override void DrawImage(ControlGraphicsInfoArgs info) {
            base.DrawImage(info);
            PictureEditViewInfo viewInfo = info.ViewInfo as PictureEditViewInfo;
            if (viewInfo.OwnerEdit != null) {
                CustomPictureEdit edit = viewInfo.OwnerEdit as CustomPictureEdit;
                if (edit.NestedFigures.Count > 0) {
                    foreach (Figure figure in edit.NestedFigures) {
                        if (!figure.Active && !figure.Selected) continue;
                        Rectangle rect = edit.FigureRectToEditorRect(figure);
                        info.Cache.FillRectangle(figure.Selected ? edit.Properties.HighlightFigureColor : edit.Properties.ActiveFigureColor, rect);
                    }
                }
            }
        }
    }
    public class Figure {
        public Rectangle SourceRect { get; set; }
        internal bool Active { get; set; }
        internal bool Selected { get; set; }
    }
    public class NestedFigureCollection : CollectionBase{
        public void Add(Rectangle figureRect) {
            List.Add(new Figure() { SourceRect = figureRect});
        }
        public void AddRange(IEnumerable figureRects) {
            foreach (Rectangle rect in figureRects) {
                List.Add(new Figure() { SourceRect = rect });
            }
        }
        public void Remove(Rectangle figureRect) {
            var figure = List.OfType<Figure>().FirstOrDefault(f => f.SourceRect == figureRect);
            if (figure != null) {
                List.Remove(figure);
            }
        }
        public Figure this[int index] {
            get { return List[index] as Figure; }
        }
    }
}
