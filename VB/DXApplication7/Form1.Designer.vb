Namespace DXApplication7
    Partial Public Class Main
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.pictureEdit1 = New DXApplication7.CustomPictureEdit()
            Me.pictureEdit2 = New DXApplication7.CustomPictureEdit()
            CType(Me.pictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pictureEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' pictureEdit1
            ' 
            Me.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default
            Me.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Left
            Me.pictureEdit1.Location = New System.Drawing.Point(0, 0)
            Me.pictureEdit1.Name = "pictureEdit1"
            Me.pictureEdit1.Properties.ActiveFigureColor = System.Drawing.Color.FromArgb((CInt((CByte(100)))), (CInt((CByte(255)))), (CInt((CByte(165)))), (CInt((CByte(0)))))
            Me.pictureEdit1.Properties.HighlightFigureColor = System.Drawing.Color.FromArgb((CInt((CByte(100)))), (CInt((CByte(0)))), (CInt((CByte(0)))), (CInt((CByte(255)))))
            Me.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto
            Me.pictureEdit1.Size = New System.Drawing.Size(787, 676)
            Me.pictureEdit1.TabIndex = 0
            ' 
            ' pictureEdit2
            ' 
            Me.pictureEdit2.Cursor = System.Windows.Forms.Cursors.Default
            Me.pictureEdit2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pictureEdit2.Location = New System.Drawing.Point(787, 0)
            Me.pictureEdit2.Name = "pictureEdit2"
            Me.pictureEdit2.Properties.ActiveFigureColor = System.Drawing.Color.FromArgb((CInt((CByte(100)))), (CInt((CByte(255)))), (CInt((CByte(165)))), (CInt((CByte(0)))))
            Me.pictureEdit2.Properties.HighlightFigureColor = System.Drawing.Color.FromArgb((CInt((CByte(100)))), (CInt((CByte(0)))), (CInt((CByte(0)))), (CInt((CByte(255)))))
            Me.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto
            Me.pictureEdit2.Size = New System.Drawing.Size(741, 676)
            Me.pictureEdit2.TabIndex = 1
            ' 
            ' Main
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1528, 676)
            Me.Controls.Add(Me.pictureEdit2)
            Me.Controls.Add(Me.pictureEdit1)
            Me.Name = "Main"
            Me.Text = "Main"
            CType(Me.pictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pictureEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents pictureEdit1 As CustomPictureEdit
        Private pictureEdit2 As CustomPictureEdit

    End Class
End Namespace

