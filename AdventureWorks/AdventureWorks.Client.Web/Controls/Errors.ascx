<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Errors.ascx.cs" Inherits="AdventureWorks.Client.Web.Errors" %>

<%@ Import Namespace="Xomega.Framework" %>

<asp:Panel ID="pnlMessages" runat="server" CssClass="cpanel widget errors">
  <div class="widget-header">
    <span id="ui-id-1" class="widget-caption">
        <asp:Label ID="lblTitle" runat="server" Text='Please view the following errors/warnings' CssClass="widget-title"></asp:Label>
    </span>
    <div class="widget-toolbar">
      <div class="widget-toolbar-icon">
        <asp:Button ID="btnClose" CssClass="close-button" Text="X" runat="server" OnClick="btnClose_Click"/>
      </div>
    </div>
  </div>
  <asp:Repeater ID="rptErrors" runat="server">
    <ItemTemplate>
      <div runat="server" class='<%# Eval("Severity") %>'>
        <i class='severity-icon fa <%# GetIconClass(((ErrorMessage)Container.DataItem).Severity) %>'></i><span><%# Eval("Message") %></span>
      </div>
    </ItemTemplate>
  </asp:Repeater>
</asp:Panel>
