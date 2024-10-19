Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class SampleRequisition_remarks
    Inherits System.Web.UI.Page

    Private Shared lockObject As New Object() ' Locking object for thread safety

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        ' Use a lock to ensure only one thread can execute this block at a time
        SyncLock lockObject
            Dim username As String = Request.QueryString("Name")
            Dim SampleReqizitionID As Integer
            Dim remarks As String = txtRemarks.Text.Trim()

            If Integer.TryParse(Request.QueryString("id"), SampleReqizitionID) Then
                If Not String.IsNullOrEmpty(remarks) Then
                    Dim remarksDetails As New RemarksDetails()
                    remarksDetails.SampleID = SampleReqizitionID.ToString()
                    remarksDetails.UserName = username
                    remarksDetails.Remarks = remarks

                    ' Check for existing remark before inserting
                    remarksDetails.InsertRemarksDetails(remarksDetails)

                     ClearFormFields()
                    Response.Redirect("ViewSampleRequisition.aspx")
                Else
                    lblMessage.Text = "Remarks cannot be empty."
                End If
            Else
                lblMessage.Text = "Invalid Sample Request ID."
            End If
        End SyncLock
    End Sub

    Private Sub ClearFormFields()
        txtRemarks.Text = String.Empty
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("ViewSampleRequisition.aspx")
    End Sub
End Class
