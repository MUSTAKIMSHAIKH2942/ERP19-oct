Imports System
Imports System.Web.UI

Partial Class SampleRequisition_DeleteSample
    Inherits System.Web.UI.Page

    Dim SampleReqizitionID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Initialize form or load data if needed, for example:
            ' LoadSampleDetails()
            txtSRRefID.Text = Request.QueryString("No")
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Dim deleteSample As New DeleteSample()

        Try
            SampleReqizitionID = Request.QueryString("id")
            ' Assign values from form fields
            deleteSample.SampleReqizitionID = SampleReqizitionID
            deleteSample.SRRefID = txtSRRefID.Text.Trim()
            deleteSample.Reason = txtReason.Text.Trim()

            ' Call method to insert delete sample details
            If deleteSample.InsertDeleteSample(deleteSample) Then
                lblMessage.Text = "Sample details deleted successfully."
                ClearFormFields()
                Response.Redirect("ViewSampleRequisition.aspx")
            Else
                lblMessage.Text = "Error occurred while deleting sample details."
            End If
        Catch ex As FormatException
            lblMessage.Text = "Please enter a valid Sample Requisition ID."
        Catch ex As Exception
            lblMessage.Text = "An unexpected error occurred: " & ex.Message
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBack.Click
        ' Redirect to another page on cancel action
        Response.Redirect("ViewSampleRequisition.aspx")
    End Sub

    Private Sub ClearFormFields()
        SampleReqizitionID = String.Empty
        txtSRRefID.Text = String.Empty
        txtReason.Text = String.Empty
    End Sub
End Class
