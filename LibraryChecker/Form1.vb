Public Class Form1
#Region " Move Form "

    ' [ Move Form ]
    '
    ' // By Elektro 

    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point

    Public Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseDown ' Add more handles here (Example: PictureBox1.MouseDown)

        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If

    End Sub

    Public Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseMove ' Add more handles here (Example: PictureBox1.MouseMove)

        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If

    End Sub

    Public Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseUp ' Add more handles here (Example: PictureBox1.MouseUp)

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If

    End Sub
#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Form2.Show()
        Form2.Visible = False

        If TextBox1.Text = "settings" Or TextBox1.Text = "Settings" Then
            Form2.Show()
            TextBox1.Text = ""
        End If

        If TextBox1.Text <> "settings" And TextBox1.Text <> "Settings" And TextBox1.Text.Trim <> "" Then

            Dim x As Integer = 0

            Shell("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe")
            'Shell("notepad.exe")
            System.Threading.Thread.Sleep(3000)
            While x < Form2.ListView1.Items.Count
                TextBox2.Text = Form2.ListView1.Items.Item(x).Text.Replace(" ", "%20")
                SendKeys.Send(Form2.ListView1.Items.Item(x).Text.Replace("**WERD**", TextBox1.Text))
                SendKeys.Send("{ENTER}")
                x = x + 1
                If x < Form2.ListView1.Items.Count Then SendKeys.Send("^t")
                System.Threading.Thread.Sleep(1000)

            End While
            TextBox1.Text = ""
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If IO.File.Exists("C:\Users\G\Documents\LibCheck\listview.txt") = False Then
            TextBox1.Text = "Type 'settings' for options..."
            SendKeys.Send("{RIGHT}")
        End If

    End Sub
#Region "KeyDown Stuff"
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyData = Keys.Enter Then Button1.PerformClick()
        If e.KeyData = Keys.Escape Then Application.Exit()

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyData = Keys.Enter Then Button1.PerformClick()
        If e.KeyData = Keys.Escape Then Application.Exit()

    End Sub
#End Region
End Class
