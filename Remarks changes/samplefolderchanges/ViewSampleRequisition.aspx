<%@ Page Language="VB"  Theme="BlueChip"  AutoEventWireup="false" CodeFile="ViewSampleRequisition.aspx.vb"
    Inherits="SampleRequisition_ViewSampleRequisition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../Styles.css" type="text/css" rel="stylesheet">
     <style>
     .untouchable {
    pointer-events: none;
    color: gray; /* Optional: Change color to indicate it's disabled */
    text-decoration: none; /* Optional: Remove underline */
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <table id="Table1" class="mainTable" align="center">
        <tr>
            <td class="tableheader" align="center">
                Veiw Sample Requisition
            </td>
        </tr>
        <tr>
            <td class="tabledata" align="right">
                <b>REQUISITION No.</b>
                <asp:TextBox Style="border-color: SkyBlue" 
                    Text="" ID="txtSearch" SkinID="SearchTextBox" runat="server"></asp:TextBox>
                <a id="a1" runat="server" causesvalidation="false" style="cursor: hand;" class="searchImage"
                    onserverclick="LoadData">
                    <img src="../Images/Search.gif" id="imgbtnSearch" border="0" runat="server" class="searchImage" /></a>
            </td>
        </tr>
    </table>
    <table id="Table2" align="center" width="860px">
        <tr>
            <td align="center">
                <asp:Label CssClass="searchtxt" ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:DataGrid ID="dgRmcplRequisition" Width=2300px  runat="server" HorizontalAlign="center" DataKeyField="RMCPL_TID">
        <Columns>
            <asp:TemplateColumn SortExpression="RMCPL_SR_NO" HeaderText="Sample No.">
                <ItemTemplate>
                    <asp:Label ID="lblRMCPL_SR_NO" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RMCPL_SR_NO")%>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
             <asp:TemplateColumn SortExpression="RMCPL_SAMPLE_NAME" HeaderText="Product">
                <ItemTemplate>
                    <asp:Label ID="lblRMCPL_SAMPLE_NAME" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RMCPL_SAMPLE_NAME")%>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn SortExpression="RMCPL_DATE" HeaderText="DATE">
                <ItemTemplate>
                    <asp:Label ID="lblRMCPL_DATE" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RMCPL_DATE","{0:dd/MM/yyyy}")%>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>

            <asp:TemplateColumn SortExpression="RMCPL_PACK_SIZE" HeaderText="Packing Size">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblRMCPL_PACK_SIZE" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RMCPL_PACK_SIZE")%>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn SortExpression="RMCPL_QTY_REQUIRED" HeaderText="Qty">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblRMCPL_QTY_REQUIRED" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RMCPL_QTY_REQUIRED")%>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
           <%-- <asp:TemplateColumn SortExpression="RMCPL_SAMPLE_CD" HeaderText="Sample">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblRMCPL_SAMPLE_CD" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RMCPL_SAMPLE_CD")%>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>--%>
          <%--  <asp:TemplateColumn SortExpression="remarks" HeaderText="remarks">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblremarks" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.remarks")%>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>--%>
            <asp:TemplateColumn SortExpression="Department" HeaderText="Department">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblDepartment" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Department")%>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
             <asp:TemplateColumn SortExpression="AllRemarks" HeaderText="All Remarks">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblAllRemarks" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AllRemarks") %>'></asp:Label> <asp:LinkButton ID="lnkbtnRemarks" runat="server"   ForeColor=Red  Text=" "   CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateColumn>

           <%-- <asp:TemplateColumn SortExpression="SalesManager" HeaderText="SalesManager">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblSalesManager" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SalesManager")%>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn SortExpression="IsHODApproved" HeaderText="IsHODApproved">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblIsHODApproved" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsHODApproved")%>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>--%>
            <asp:TemplateColumn  HeaderStyle-Width="100px" HeaderText="Check whether material available in Stores<br>(Stores)"> 
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                  <asp:Label ID="lblisavailableinstores" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.isavailableinstores")%>'> </asp:Label>  <asp:LinkButton ID="lnkbtnAvailableStores" runat="server"   ForeColor=Red  Text="Pending"   CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateColumn>

             <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="Check Request & forward to R&D if not available in plant<br>(QC)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                  <asp:Label ID="lblisavailableinplant" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsSampleAvailableInPlant")%>'> </asp:Label>  <asp:LinkButton ID="lnkisavailableinplant" runat="server"   ForeColor=Red  Text="Pending"   CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>

            </asp:TemplateColumn>
              <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="R&D will allocate to concern department<br>(R&D)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                  <asp:Label ID="lblDepartmentRequisition" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartmentRequisitionDivID")%>'> </asp:Label>  <asp:LinkButton ID="lnkDepartmentRequisition" runat="server"   ForeColor=Red  Text="Pending"   CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateColumn> 
           <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="Sample Preparation by R & D Department<br>(R&D)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblSamplePreparation" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SampleID")%>'> </asp:Label>
                    <asp:LinkButton ID="lnkSamplePreparation" runat="server" ForeColor="Red" Text="Pending" CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
           </asp:TemplateColumn>

            <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="Packing Labelling & COA Gate pass by QC<br>(QC)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblPackingLabellingCOAGatePass" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PackagingID")%>'> </asp:Label>
                    <asp:LinkButton ID="lnkPackingLabellingCOAGatePass" runat="server" ForeColor="Red" Text="Pending" CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
           </asp:TemplateColumn>
            
            <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="Verifying label & checking COA by QA<br>(QA)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblQA_Verification" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QA_VerificationId")%>'> </asp:Label>
                    <asp:LinkButton ID="lnkQA_Verification" runat="server" ForeColor="Red" Text="Pending" CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
           </asp:TemplateColumn>
            
           <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="If Delay<br>(Anyone)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblIfDelay" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IfDelayId")%>'> </asp:Label>
                    <asp:LinkButton ID="lnkIfDelay" runat="server" ForeColor="Red" Text="Pending" CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
           </asp:TemplateColumn>
            
               <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="Material dispatched<br>(Rakesh)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblSampleDispatch" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CourierDetailsId") %>'> </asp:Label>
                    <asp:LinkButton ID="lnkSampleDispatch" runat="server" ForeColor="Red" Text="Pending" CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
           </asp:TemplateColumn>

              <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="Inform Customer on Dispatch Details<br>(CRM)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblInformCustomerDispatchDetails" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.InformCustomerDispatchDetailsID") %>'> </asp:Label>
                    <asp:LinkButton ID="lnkInformCustomerDispatchDetails" runat="server" ForeColor="Red" Text="Pending" CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
              </asp:TemplateColumn>

              <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="Track Dispatch Until delivery & Sample Delivery<br>(Logistics)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblTrackDispatchUntildelivery" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TrackDispatchUntildeliveryID")%>'> </asp:Label>
                    <asp:LinkButton ID="lnkTrackDispatchUntildelivery" runat="server" ForeColor="Red" Text="Pending" CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
              </asp:TemplateColumn>

              <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="Check with Customer on Receipt of Sample<br>(Logistics)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblCustomerSampleReceiptCheck" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CustomerSampleReceiptCheckID")%>'> </asp:Label>
                    <asp:LinkButton ID="lnkCustomerSampleReceiptCheck" runat="server" ForeColor="Red" Text="Pending" CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
             </asp:TemplateColumn>

             <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="Tracking Test Report & Sales Progress<br>(Sales Executive)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblCustomerSampleApproval" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CustomerSampleApprovalID")%>'> </asp:Label>
                    <asp:LinkButton ID="lnkCustomerSampleApproval" runat="server" ForeColor="Red" Text="Pending" CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
             </asp:TemplateColumn>

             <asp:TemplateColumn HeaderStyle-Width="100px" HeaderText="Receiving of PO from the customer.<br>(Sales Executive)">
                <ItemStyle></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblReceivingOfPOfromCustomer" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ReceivingOfPOfromCustomerID")%>'> </asp:Label>
                    <asp:LinkButton ID="lnkReceivingOfPOfromCustomer" runat="server" ForeColor="Red" Text="Pending" CausesValidation="false"></asp:LinkButton>
                </ItemTemplate>
             </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
                
    <asp:TextBox ID="txtSortField" runat="server" Visible="False"></asp:TextBox>
    </form>
</body>
</html>
