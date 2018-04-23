Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace DXApplication7
    Partial Public Class Main
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            SetUpEditors()
        End Sub

        Private Sub SetUpEditors()
            pictureEdit1.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.True
            pictureEdit1.Properties.AllowScrollViaMouseDrag = True
            pictureEdit1.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.True
            pictureEdit1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True
            pictureEdit1.Properties.ShowScrollBars = True
            pictureEdit2.Properties.Assign(pictureEdit1.Properties)
            pictureEdit1.Image = Image.FromFile("SimpleDiagram.png")
            pictureEdit1.NestedFigures.AddRange(New Rectangle(){ _
                New Rectangle(40, 40, 180, 145), _
                New Rectangle(40, 255, 180, 145), _
                New Rectangle(292, 110, 180, 145), _
                New Rectangle(292, 325, 180, 145), _
                New Rectangle(545, 220, 180, 145) _
            })
        End Sub
        Private Sub OnPictureEditClick(ByVal sender As Object, ByVal e As EventArgs) Handles pictureEdit1.Click
            pictureEdit2.Image = pictureEdit1.GetImageWithFigures()
        End Sub
    End Class
End Namespace
