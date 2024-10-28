Imports System.Data

Partial Class SampleRequisition_ViewSampleRequisition
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            LoadData(sender, e)
            lblMessage.Text = ""
        End If
    End Sub

    Public Sub LoadData(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dv As Data.DataView = New Data.DataView(SampleRequisition.GetRmcplRequisition(txtSearch.Text).Tables(0))
        dv.Sort = txtSortField.Text
        Try
            With dgRmcplRequisition
                .ShowFooter = True
                .DataSource = dv
                .DataBind()
            End With
        Catch
            With dgRmcplRequisition
                .CurrentPageIndex = .PageCount - 1
                .ShowFooter = True
                .SelectedIndex = -1
                .DataSource = dv
                .DataBind()
            End With
        End Try
    End Sub

    Protected Sub dgRmcplRequisition_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgRmcplRequisition.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ' Adding target attribute to open links in a new tab
            CType(e.Item.FindControl("lnkbtnAvailableStores"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkisavailableinplant"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkDepartmentRequisition"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkSamplePreparation"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkPackingLabellingCOAGatePass"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkQA_Verification"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkIfDelay"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkSampleDispatch"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkInformCustomerDispatchDetails"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkTrackDispatchUntildelivery"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkCustomerSampleReceiptCheck"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkCustomerSampleApproval"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkReceivingOfPOfromCustomer"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkbtnRemarks"), LinkButton).Attributes.Add("target", "")
            CType(e.Item.FindControl("lnkDelete"), LinkButton).Attributes.Add("target", "")


            ' Get the Requisition ID and Sample Number
            Dim RmcplRequisitionID As Integer = dgRmcplRequisition.DataKeys(e.Item.ItemIndex)
            Dim SampleRequiNo As String = CType(e.Item.FindControl("lblRMCPL_SR_NO"), Label).Text.Trim()

            ' Set href attributes for links
            CType(e.Item.FindControl("lnkbtnAvailableStores"), LinkButton).Attributes.Add("href", "sampleReqizitionpage1.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkisavailableinplant"), LinkButton).Attributes.Add("href", "sampleReqizitionpage2.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkDepartmentRequisition"), LinkButton).Attributes.Add("href", "DepartmentRequisitionDivpage.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkSamplePreparation"), LinkButton).Attributes.Add("href", "SamplePreparationPage.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkPackingLabellingCOAGatePass"), LinkButton).Attributes.Add("href", "PackingLabellingCOAGatePassPage.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkQA_Verification"), LinkButton).Attributes.Add("href", "QA_VerificationPage.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkIfDelay"), LinkButton).Attributes.Add("href", "IfDelayPage.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkSampleDispatch"), LinkButton).Attributes.Add("href", "CourierDetailsPage.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkInformCustomerDispatchDetails"), LinkButton).Attributes.Add("href", "InformCustomerDispatchDetailsPage.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkTrackDispatchUntildelivery"), LinkButton).Attributes.Add("href", "TrackDispatchUntideliveryPage.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkCustomerSampleReceiptCheck"), LinkButton).Attributes.Add("href", "CustomerSampleReceiptCheckPage.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkCustomerSampleApproval"), LinkButton).Attributes.Add("href", "CustomerSampleApprovalPage.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkReceivingOfPOfromCustomer"), LinkButton).Attributes.Add("href", "ReceivingofPOfromcustomerPage.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo)
            CType(e.Item.FindControl("lnkbtnRemarks"), LinkButton).Attributes.Add("href", "remarks.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo & "&Name=" & Request.QueryString("UserName"))
            CType(e.Item.FindControl("lnkDelete"), LinkButton).Attributes.Add("href", "DeleteSample.aspx?id=" & RmcplRequisitionID & "&No=" & SampleRequiNo & "&Name=" & Request.QueryString("UserName"))

            ' Handle visibility of other controls based on their respective labels
            If CType(e.Item.FindControl("lblisavailableinstores"), Label).Text <> "" Then
                CType(e.Item.FindControl("lnkbtnAvailableStores"), LinkButton).Visible = False
            End If

            If CType(e.Item.FindControl("lblisavailableinplant"), Label).Text <> "" Then
                CType(e.Item.FindControl("lnkisavailableinplant"), LinkButton).Visible = False
            End If


            ' Handling multiple Label and LinkButton pairs
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblDepartmentRequisition"), Label), CType(e.Item.FindControl("lnkDepartmentRequisition"), LinkButton))
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblSamplePreparation"), Label), CType(e.Item.FindControl("lnkSamplePreparation"), LinkButton))
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblPackingLabellingCOAGatePass"), Label), CType(e.Item.FindControl("lnkPackingLabellingCOAGatePass"), LinkButton))
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblQA_Verification"), Label), CType(e.Item.FindControl("lnkQA_Verification"), LinkButton))
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblIfDelay"), Label), CType(e.Item.FindControl("lnkIfDelay"), LinkButton))
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblSampleDispatch"), Label), CType(e.Item.FindControl("lnkSampleDispatch"), LinkButton))
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblInformCustomerDispatchDetails"), Label), CType(e.Item.FindControl("lnkInformCustomerDispatchDetails"), LinkButton))
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblTrackDispatchUntildelivery"), Label), CType(e.Item.FindControl("lnkTrackDispatchUntildelivery"), LinkButton))
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblCustomerSampleReceiptCheck"), Label), CType(e.Item.FindControl("lnkCustomerSampleReceiptCheck"), LinkButton))
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblCustomerSampleApproval"), Label), CType(e.Item.FindControl("lnkCustomerSampleApproval"), LinkButton))
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblReceivingOfPOfromCustomer"), Label), CType(e.Item.FindControl("lnkReceivingOfPOfromCustomer"), LinkButton))
            MakeLinkButtonUntouchableIfComplete(CType(e.Item.FindControl("lblDelete"), Label), CType(e.Item.FindControl("lnkDelete"), LinkButton))

            If CType(e.Item.FindControl("lblisavailableinplant"), Label).Text = "Yes" Then
                CType(e.Item.FindControl("lblDepartmentRequisition"), Label).Text = "NA"
                CType(e.Item.FindControl("lblSamplePreparation"), Label).Text = "NA"

                CType(e.Item.FindControl("lnkDepartmentRequisition"), LinkButton).Visible = False
                CType(e.Item.FindControl("lnkSamplePreparation"), LinkButton).Visible = False
 

            End If
        End If
    End Sub

    ' Helper function to apply the untouchable class
    Public Sub MakeLinkButtonUntouchableIfComplete(ByVal lbl As Label, ByVal lnk As LinkButton)
        If lbl IsNot Nothing AndAlso lnk IsNot Nothing Then
            Dim lblText As String = lbl.Text.Trim()

            If Not String.IsNullOrEmpty(lblText) Then
                If lblText.Equals("Completed", StringComparison.OrdinalIgnoreCase) Then
                    ' Make the button "untouchable"
                    lnk.CssClass = "untouchable"
                Else
                    lnk.Visible = False
                    lbl.Text = "Completed"
                    lbl.ForeColor = Drawing.Color.Green
                    lnk.ForeColor = Drawing.Color.Green
                End If
            End If
        End If
    End Sub

    Private Sub dgStates_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgRmcplRequisition.SortCommand
        If txtSortField.Text.Trim.ToLower <> e.SortExpression.Trim.ToLower Then
            txtSortField.Text = e.SortExpression()
        Else
            txtSortField.Text = e.SortExpression() & " DESC"
        End If
        LoadData(source, e)
    End Sub

    Private Sub dgStates_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgRmcplRequisition.PageIndexChanged
        dgRmcplRequisition.CurrentPageIndex = e.NewPageIndex
        dgRmcplRequisition.EditItemIndex = -1
        dgRmcplRequisition.SelectedIndex = -1
        LoadData(source, e)
    End Sub

    Protected Sub btnExportExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        dgRmcplRequisition.AllowPaging = False
        LoadData(sender, e)
         
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=SampleRequisition.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.ms-excel"

        Dim stringWrite As New System.IO.StringWriter()
        Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)
        dgRmcplRequisition.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString())
        Response.End()
    End Sub
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub
End Class
