<%@ Page Title="item" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Auction.Web.item.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="item_id" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="item_name" HeaderText="item_name" SortExpression="item_name" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="item_remark" HeaderText="item_remark" SortExpression="item_remark" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="item_desc" HeaderText="item_desc" SortExpression="item_desc" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="kind_id" HeaderText="kind_id" SortExpression="kind_id" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="addtime" HeaderText="addtime" SortExpression="addtime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="endtime" HeaderText="endtime" SortExpression="endtime" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="init_price" HeaderText="init_price" SortExpression="init_price" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="max_price" HeaderText="max_price" SortExpression="max_price" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="owner_id" HeaderText="owner_id" SortExpression="owner_id" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="winer_id" HeaderText="winer_id" SortExpression="winer_id" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="state_id" HeaderText="state_id" SortExpression="state_id" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="item_id" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="item_id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
