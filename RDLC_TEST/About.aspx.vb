Imports Microsoft.Reporting.WebForms

Public Class About
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadReport()



        End If
    End Sub

    Private Sub LoadReport()
        Dim vDT As DataTable = PrepareData()
        rdlc.LocalReport.ReportPath = Server.MapPath("~/Reports/MyReport.rdlc")
        Dim rds As New ReportDataSource("MyDataSet", vDT)

        rdlc.LocalReport.DataSources.Clear()
        rdlc.LocalReport.DataSources.Add(rds)
        rdlc.ShowToolBar = True
        rdlc.LocalReport.Refresh()

    End Sub

    Private Function PrepareData() As DataTable
        Dim vDT As DataTable = New DataTable
        vDT.Columns.Add("ID")
        vDT.Columns.Add("ITEM")
        vDT.Columns.Add("DESC")

        Dim rnd As New Random()
        Dim randomNumber As Integer = rnd.Next(1, 101)


        For index As Integer = randomNumber To (randomNumber + 10)
            Dim dr = vDT.NewRow
            dr(0) = index
            dr(1) = "item" & index
            dr(2) = "desc" & index
            vDT.Rows.Add(dr)


        Next
        Return vDT
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadReport()
    End Sub
End Class