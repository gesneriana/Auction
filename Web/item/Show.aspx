﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Auction.Web.item.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		auto_increment
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblitem_id" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		item_name
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblitem_name" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		item_remark
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblitem_remark" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		item_desc
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblitem_desc" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		kind_id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblkind_id" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		addtime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbladdtime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		endtime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblendtime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		init_price
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblinit_price" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		max_price
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblmax_price" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		owner_id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblowner_id" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		winer_id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblwiner_id" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		state_id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblstate_id" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




