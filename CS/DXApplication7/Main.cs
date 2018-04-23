using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXApplication7 {
    public partial class Main : DevExpress.XtraEditors.XtraForm {
        public Main() {
            InitializeComponent();
            SetUpEditors();
        }

        private void SetUpEditors() {
            pictureEdit1.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.True;
            pictureEdit1.Properties.AllowScrollViaMouseDrag = true;
            pictureEdit1.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.True;
            pictureEdit1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            pictureEdit1.Properties.ShowScrollBars = true;
            pictureEdit2.Properties.Assign(pictureEdit1.Properties);
            pictureEdit1.Image = Image.FromFile("SimpleDiagram.png");
            pictureEdit1.NestedFigures.AddRange(
                new Rectangle[]{
                               new Rectangle(40, 40, 180, 145),
                               new Rectangle(40, 255, 180, 145),
                               new Rectangle(292, 110, 180, 145),
                               new Rectangle(292, 325, 180, 145),
                               new Rectangle(545, 220, 180, 145)
                               });
        }
        private void OnPictureEditClick(object sender, EventArgs e) {
            pictureEdit2.Image = pictureEdit1.GetImageWithFigures();
        }
    }
}
