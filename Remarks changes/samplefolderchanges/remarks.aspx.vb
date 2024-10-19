Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class SampleRequisition_remarks
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtSampleID.Text = Request.QueryString("No")
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        ' Get the username from the session
        Dim username As String = Request.QueryString("Name") ' Assuming the session key is "UserName"
        Dim sampleID As Integer
        Dim remarks As String = txtRemarks.Text.Trim()

        ' Validate input
        If Integer.TryParse(txtSampleID.Text, sampleID) AndAlso Not String.IsNullOrEmpty(remarks) Then
            ' Create an instance of RemarksDetails
            Dim remarksDetails As New RemarksDetails()
            remarksDetails.SampleID = sampleID
            remarksDetails.UserName = username
            remarksDetails.Remarks = remarks

            ' Insert the remark into the database
            Dim isInserted As Boolean = RemarksDetails.InsertRemarksDetails(remarksDetails)

            If isInserted Then
                lblMessage.Text = "Remark inserted successfully."
                ClearFormFields()
            Else
                lblMessage.Text = "Error inserting remark."
            End If
        Else
            lblMessage.Text = "Please enter valid Sample ID and Remarks."
        End If
    End Sub

    Private Sub ClearFormFields()
        txtRemarks.Text = String.Empty
    End Sub
End Class
