Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports System.Collections

Namespace DXApplication7
    <UserRepositoryItem("RegisterCustomPictureEdit")> _
    Public Class RepositoryItemCustomPictureEdit
        Inherits RepositoryItemPictureEdit

        Shared Sub New()
            RegisterCustomPictureEdit()
        End Sub
        Public Const CustomEditName As String = "CustomPictureEdit"
        Public Sub New()
            HighlightFigureColor = Color.FromArgb(100, Color.Blue)
            ActiveFigureColor = Color.FromArgb(100, Color.Orange)
        End Sub
        Public Overrides ReadOnly Property EditorTypeName() As String
            Get
                Return CustomEditName
            End Get
        End Property
        Public Shared Sub RegisterCustomPictureEdit()
            Dim img As Image = Nothing
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(CustomPictureEdit), GetType(RepositoryItemCustomPictureEdit), GetType(CustomPictureEditViewInfo), New CustomPictureEditPainter(), True, img))
        End Sub

        Private highlightFigureColor_Renamed As Color
        Public Property HighlightFigureColor() As Color
            Get
                Return highlightFigureColor_Renamed
            End Get
            Set(ByVal value As Color)
                If highlightFigureColor_Renamed <> value Then
                    highlightFigureColor_Renamed = value
                    OnPropertiesChanged()
                End If
            End Set
        End Property

        Private activeFigureColor_Renamed As Color
        Public Property ActiveFigureColor() As Color
            Get
                Return activeFigureColor_Renamed
            End Get
            Set(ByVal value As Color)
                If activeFigureColor_Renamed <> value Then
                    activeFigureColor_Renamed = value
                    OnPropertiesChanged()
                End If
            End Set
        End Property
        Public Overrides Sub Assign(ByVal item As RepositoryItem)
            BeginUpdate()
            Try
                MyBase.Assign(item)
                Dim source As RepositoryItemCustomPictureEdit = TryCast(item, RepositoryItemCustomPictureEdit)
                If source Is Nothing Then
                    Return
                End If
                HighlightFigureColor = source.HighlightFigureColor
                ActiveFigureColor = source.ActiveFigureColor
            Finally
                EndUpdate()
            End Try
        End Sub
    End Class

    <ToolboxItem(True)> _
    Public Class CustomPictureEdit
        Inherits PictureEdit

        Shared Sub New()
            RepositoryItemCustomPictureEdit.RegisterCustomPictureEdit()
        End Sub
        Public Sub New()
        End Sub
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public Shadows ReadOnly Property Properties() As RepositoryItemCustomPictureEdit
            Get
                Return TryCast(MyBase.Properties, RepositoryItemCustomPictureEdit)
            End Get
        End Property
        Public Overrides ReadOnly Property EditorTypeName() As String
            Get
                Return RepositoryItemCustomPictureEdit.CustomEditName
            End Get
        End Property

        Private nestedFigures_Renamed As NestedFigureCollection
        Public Property NestedFigures() As NestedFigureCollection
            Get
                If nestedFigures_Renamed Is Nothing Then
                    nestedFigures_Renamed = New NestedFigureCollection()
                End If
                Return nestedFigures_Renamed
            End Get
            Set(ByVal value As NestedFigureCollection)
                If nestedFigures_Renamed IsNot value Then
                    nestedFigures_Renamed = value
                    OnPropertiesChanged()
                End If
            End Set
        End Property
        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)
            UpdateNestedFigures(e.Location)
        End Sub
        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)
            ActivateNestedFigures(e.Location)
        End Sub
        Protected Sub UpdateNestedFigures(ByVal pt As Point)
            If NestedFigures.Count > 0 Then
                Dim imagePoint As Point = ViewportToImage(pt)
                For Each figure As Figure In NestedFigures
                    figure.Selected = figure.SourceRect.Contains(imagePoint)
                Next figure
                Invalidate()
            End If
        End Sub
        Protected Sub ActivateNestedFigures(ByVal pt As Point)
            If NestedFigures.Count > 0 Then
                Dim imagePoint As Point = ViewportToImage(pt)
                For Each figure As Figure In NestedFigures
                    If figure.SourceRect.Contains(imagePoint) Then
                        figure.Active = Not figure.Active
                        Exit For
                    End If
                Next figure
                Invalidate()
            End If
        End Sub
        Protected Friend Function FigureRectToEditorRect(ByVal figure As Figure) As Rectangle
            Return New Rectangle(ImageToViewport(figure.SourceRect.Location), figure.SourceRect.Size)
        End Function
         Public Function GetImageWithFigures() As Image
             If Image Is Nothing Then
                 Return Nothing
             End If
             If NestedFigures.Count = 0 Then
                 Return Image
             End If
             Dim newImage As Image = TryCast(Image.Clone(), Image)
             Using graphics As Graphics = System.Drawing.Graphics.FromImage(newImage)
                For Each figure As Figure In NestedFigures
                    If figure.Active Then
                        Using brush As New SolidBrush(Properties.ActiveFigureColor)
                            graphics.FillRectangle(brush, figure.SourceRect)
                        End Using
                    End If
                Next figure
             End Using
             Return newImage
         End Function
    End Class

    Public Class CustomPictureEditViewInfo
        Inherits PictureEditViewInfo

        Public Sub New(ByVal item As RepositoryItem)
            MyBase.New(item)
        End Sub
    End Class
    Public Class CustomPictureEditPainter
        Inherits PictureEditPainter

        Public Sub New()
        End Sub
        Protected Overrides Sub DrawImage(ByVal info As ControlGraphicsInfoArgs)
            MyBase.DrawImage(info)
            Dim viewInfo As PictureEditViewInfo = TryCast(info.ViewInfo, PictureEditViewInfo)
            If viewInfo.OwnerEdit IsNot Nothing Then
                Dim edit As CustomPictureEdit = TryCast(viewInfo.OwnerEdit, CustomPictureEdit)
                If edit.NestedFigures.Count > 0 Then
                    For Each figure As Figure In edit.NestedFigures
                        If Not figure.Active AndAlso Not figure.Selected Then
                            Continue For
                        End If
                        Dim rect As Rectangle = edit.FigureRectToEditorRect(figure)
                        info.Cache.FillRectangle(If(figure.Selected, edit.Properties.HighlightFigureColor, edit.Properties.ActiveFigureColor), rect)
                    Next figure
                End If
            End If
        End Sub
    End Class
    Public Class Figure
        Public Property SourceRect() As Rectangle
        Friend Property Active() As Boolean
        Friend Property Selected() As Boolean
    End Class
    Public Class NestedFigureCollection
        Inherits CollectionBase

        Public Sub Add(ByVal figureRect As Rectangle)
            List.Add(New Figure() With {.SourceRect = figureRect})
        End Sub
        Public Sub AddRange(ByVal figureRects As IEnumerable)
            For Each rect As Rectangle In figureRects
                List.Add(New Figure() With {.SourceRect = rect})
            Next rect
        End Sub
        Public Sub Remove(ByVal figureRect As Rectangle)
            Dim figure = List.OfType(Of Figure)().FirstOrDefault(Function(f) f.SourceRect = figureRect)
            If figure IsNot Nothing Then
                List.Remove(figure)
            End If
        End Sub
        Default Public ReadOnly Property Item(ByVal index As Integer) As Figure
            Get
                Return TryCast(List(index), Figure)
            End Get
        End Property
    End Class
End Namespace
