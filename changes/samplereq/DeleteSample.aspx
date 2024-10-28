<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DeleteSample.aspx.vb" Inherits="SampleRequisition_DeleteSample" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Delete Sample Details</title>
    <link href="../Styles.css" type="text/css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
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
                <td colspan="2" align="center" class="tableheader">
                    Delete Sample Details
                </td>
            </tr>
            <tr>
                <td class="fieldheaders">
                    &nbsp;</td>
                <td class="tabledata" align="right">
                    <asp:Button ID="btnBack" CausesValidation="False" runat="server" Text="Back" 
                        CssClass="btn-cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td class="fieldheaders">
                    SR Reference ID <span style="color: red;">*</span>
                </td>
                <td class="tabledata">
                    <asp:TextBox ID="txtSRRefID" runat="server" CssClass="form-control" />
                </td>
            </tr>
            <tr>
                <td class="fieldheaders">
                    Reason for Deletion <span style="color: red;">*</span>
                </td>
                <td class="tabledata">
                    <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                    <asp:RequiredFieldValidator ID="rfvReason" runat="server" ControlToValidate="txtReason" 
                        ErrorMessage="Reason is required." CssClass="error-message" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="fieldheaders">
                    &nbsp;</td>
                <td class="tabledata">
                    <asp:Button ID="btnSubmit" runat="server" Text="Delete" OnClick="btnSubmit_Click" CssClass="btn-submit" />
                </td>
            </tr>
            <tr>
                <td class="fieldheaders">
                </td>
                <td class="fieldheaders">
                    <asp:Label CssClass="MessageBox" ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
