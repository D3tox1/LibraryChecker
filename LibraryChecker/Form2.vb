Public Class Form2
    Dim myCoolFile As String = "C:\Users\G\Documents\LibCheck\listview.txt"
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
        Dim fileControl As New IO.StreamWriter(myCoolFile)
        Dim x As Integer = 0

        TextBox1.Text = TextBox1.Text.Replace("%", "{%}")
        TextBox1.Text = TextBox1.Text.Replace("^", "{^}")
        TextBox1.Text = TextBox1.Text.Replace("+", "{+}")
        TextBox1.Text = TextBox1.Text.Replace("~", "{~}")
        TextBox1.Text = TextBox1.Text.Replace("(", "{(}")
        TextBox1.Text = TextBox1.Text.Replace(")", "{)}")

        ListView1.Items.Add(TextBox1.Text)

        While x < ListView1.Items.Count

            fileControl.WriteLine(ListView1.Items(x).Text)
            x = x + 1

        End While

        fileControl.Close()
        TextBox1.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fileControl As New IO.StreamWriter(myCoolFile)
        Dim x As Integer = 0

        ListView1.Items.Remove(ListView1.FocusedItem)

        While x < ListView1.Items.Count

            fileControl.WriteLine(ListView1.Items(x).Text)
            x = x + 1

        End While

        fileControl.Close()

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        On Error Resume Next
        If IO.File.Exists(myCoolFile) Then
            Dim myCoolFileLines() As String = IO.File.ReadAllLines(myCoolFile)
            Dim x As Integer = 0

            For Each line As String In myCoolFileLines
                ListView1.Items.Add(myCoolFileLines(x))
                x = x + 1
            Next

        End If



    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Hide()
    End Sub
End Class