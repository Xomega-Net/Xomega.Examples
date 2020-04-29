<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CollapsiblePanel.ascx.cs" Inherits="AdventureWorks.Client.Web.CollapsiblePanel" %>

<div class="cpanel widget">
  <asp:Panel ID="Header" CssClass="widget-header" runat="server">
    <div class="widget-toolbar">
      <div class="widget-toolbar-icon">
        <asp:Label ID="twister" CssClass="fa" runat="server" />
      </div>
    </div>
    <div class="widget-caption">
      <asp:Label ID="lblTitle" CssClass="widget-title" runat="server" />
    </div>
  </asp:Panel>
  <asp:Panel ID="pnlCollapsible" runat="server">
      <asp:Panel ID="Body" CssClass="widget-body" runat="server">
        <asp:PlaceHolder ID="Content" runat="server" />
      </asp:Panel>
  </asp:Panel>
</div>
