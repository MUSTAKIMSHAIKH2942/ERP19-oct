<%@ Page Language="VB" Theme="BlueChip" AutoEventWireup="false" CodeFile="remarks.aspx.vb" Inherits="SampleRequisition_remarks" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Remarks Form</title>
    <link href="../Styles.css" type="text/css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.css" rel="stylesheet" />
    <style type="text/css">
        .btn-secondary {
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table id="Table1" align="center" class="mainTable7">
            <tr>
                <td colspan="2" align="center" class="tableheader">Remarks Form</td>
            </tr>
            <tr>
                <td class="fieldheaders">Sample ID <span style="color: red;">*</span></td>
                <td class="tabledata">
                    <asp:TextBox ID="txtSampleID" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvSampleID" runat="server" ControlToValidate="txtSampleID" 
                        ErrorMessage="Sample ID is required." CssClass="error-message" />
                </td>
            </tr>
            <tr>
                <td class="fieldheaders">Remarks <span style="color: red;">*</span></td>
                <td class="tabledata">
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                    <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ControlToValidate="txtRemarks" 
                        ErrorMessage="Remarks are required." CssClass="error-message" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn-submit btn-secondary" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="tabledata">
                    <asp:Label ID="lblMessage" runat="server" CssClass="MessageBox"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
