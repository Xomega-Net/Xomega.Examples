<%---------------------------------------------------------------------------------------------
 This file was AUTO-GENERATED by "ASP.NET Views" Xomega.Net generator.

 Manual CHANGES to this file WILL BE LOST when the code is regenerated.
----------------------------------------------------------------------------------------------%>

<%@ Control Language="C#" Inherits="AdventureWorks.Client.Web.SalesOrderListView" %>

<%@ Import Namespace="AdventureWorks.Client.Objects" %>
<%@ Register src="~/Controls/CollapsiblePanel.ascx" tagname="CollapsiblePanel" tagprefix="uc" %>
<%@ Register src="~/Controls/Editors/DateTimeControl.ascx" tagname="DateTimeControl" tagprefix="uc" %>
<%@ Register src="~/Controls/Errors.ascx" tagname="Errors" tagprefix="uc" %>
<%@ Register src="~/Controls/AppliedCriteria.ascx" tagname="AppliedCriteria" tagprefix="uc" %>
<%@ Register src="~/Views/Sales/SalesOrderView.ascx" tagname="SalesOrderView" tagprefix="uc" %>

<asp:Panel ID="pnlComposition" CssClass="view-composition" runat="server">
  <div>
    <asp:UpdatePanel ID="upl_Main" UpdateMode="Conditional" runat="server">
      <ContentTemplate>
        <asp:Panel ID="pnl_View" CssClass="view vw-sales-order-list-view" runat="server" data-width="1760" data-height="860">
          <div class="view-header">
            <asp:Label ID="lbl_ViewTitle" CssClass="view-title" runat="server"></asp:Label>
          </div>
          <div class="view-body">
            <div class="content indented">
              <uc:CollapsiblePanel ID="ucl_Criteria" Title="Criteria" runat="server">
                <ContentTemplate>
                  <asp:Panel ID="pnlCriteria" CssClass="xw-obj" runat="server">
                    <table class="xw-fieldset-layout">
                      <tr>
                        <td class="fieldColumn" style="width: 50%">
                          <div class="field">
                            <asp:Label ID="lblSalesOrderNumber" Text="Sales Order Number:" CssClass="label" runat="server"></asp:Label>
                            <asp:DropDownList LabelID="lblSalesOrderNumber" ID="ctlSalesOrderNumberOperator" Property="<%# SalesOrderCriteria.SalesOrderNumberOperator %>" runat="server" AutoPostBack="true" CssClass="operator"></asp:DropDownList>
                            <asp:TextBox ID="ctlSalesOrderNumber" Property="<%# SalesOrderCriteria.SalesOrderNumber %>" runat="server"></asp:TextBox>
                          </div>
                          <div class="field">
                            <asp:Label ID="lblStatus" Text="Status:" CssClass="label" runat="server"></asp:Label>
                            <asp:DropDownList LabelID="lblStatus" ID="ctlStatusOperator" Property="<%# SalesOrderCriteria.StatusOperator %>" runat="server" AutoPostBack="true" CssClass="operator"></asp:DropDownList>
                            <asp:TextBox ID="ctlStatus" Property="<%# SalesOrderCriteria.Status %>" runat="server"></asp:TextBox>
                          </div>
                          <div class="field">
                            <asp:Label ID="lblOrderDate" Text="Order Date:" CssClass="label" runat="server"></asp:Label>
                            <asp:DropDownList LabelID="lblOrderDate" ID="ctlOrderDateOperator" Property="<%# SalesOrderCriteria.OrderDateOperator %>" runat="server" AutoPostBack="true" CssClass="operator"></asp:DropDownList>
                            <uc:DateTimeControl ID="ctlOrderDate" Property="<%# SalesOrderCriteria.OrderDate %>" TextCssClass="date" runat="server"></uc:DateTimeControl>
                            <uc:DateTimeControl ID="ctlOrderDate2" Property="<%# SalesOrderCriteria.OrderDate2 %>" TextCssClass="date" runat="server"></uc:DateTimeControl>
                          </div>
                          <div class="field">
                            <asp:Label ID="lblDueDate" Text="Due Date:" CssClass="label" runat="server"></asp:Label>
                            <asp:DropDownList LabelID="lblDueDate" ID="ctlDueDateOperator" Property="<%# SalesOrderCriteria.DueDateOperator %>" runat="server" AutoPostBack="true" CssClass="operator"></asp:DropDownList>
                            <uc:DateTimeControl ID="ctlDueDate" Property="<%# SalesOrderCriteria.DueDate %>" TextCssClass="date" runat="server"></uc:DateTimeControl>
                            <uc:DateTimeControl ID="ctlDueDate2" Property="<%# SalesOrderCriteria.DueDate2 %>" TextCssClass="date" runat="server"></uc:DateTimeControl>
                          </div>
                          <div class="field">
                            <asp:Label ID="lblTotalDue" Text="Total Due:" CssClass="label" runat="server"></asp:Label>
                            <asp:DropDownList LabelID="lblTotalDue" ID="ctlTotalDueOperator" Property="<%# SalesOrderCriteria.TotalDueOperator %>" runat="server" AutoPostBack="true" CssClass="operator"></asp:DropDownList>
                            <asp:TextBox ID="ctlTotalDue" Property="<%# SalesOrderCriteria.TotalDue %>" runat="server" CssClass="decimal"></asp:TextBox>
                            <asp:TextBox ID="ctlTotalDue2" Property="<%# SalesOrderCriteria.TotalDue2 %>" runat="server" CssClass="decimal"></asp:TextBox>
                          </div>
                        </td>
                        <td class="fieldColumn" style="width: 50%">
                          <div class="field">
                            <asp:Label ID="lblCustomerStore" Text="Customer Store:" CssClass="label" runat="server"></asp:Label>
                            <asp:DropDownList LabelID="lblCustomerStore" ID="ctlCustomerStoreOperator" Property="<%# SalesOrderCriteria.CustomerStoreOperator %>" runat="server" AutoPostBack="true" CssClass="operator"></asp:DropDownList>
                            <asp:TextBox ID="ctlCustomerStore" Property="<%# SalesOrderCriteria.CustomerStore %>" runat="server"></asp:TextBox>
                          </div>
                          <div class="field">
                            <asp:Label ID="lblCustomerName" Text="Customer Name:" CssClass="label" runat="server"></asp:Label>
                            <asp:DropDownList LabelID="lblCustomerName" ID="ctlCustomerNameOperator" Property="<%# SalesOrderCriteria.CustomerNameOperator %>" runat="server" AutoPostBack="true" CssClass="operator"></asp:DropDownList>
                            <asp:TextBox ID="ctlCustomerName" Property="<%# SalesOrderCriteria.CustomerName %>" runat="server"></asp:TextBox>
                          </div>
                          <div class="field">
                            <asp:Label ID="lblGlobalRegion" Text="Global Region:" CssClass="label" runat="server"></asp:Label>
                            <asp:DropDownList LabelID="lblGlobalRegion" ID="ctlGlobalRegion" Property="<%# SalesOrderCriteria.GlobalRegion %>" AutoPostBack="true" runat="server"></asp:DropDownList>
                          </div>
                          <div class="field">
                            <asp:Label ID="lblTerritoryId" Text="Sales Territory:" CssClass="label" runat="server"></asp:Label>
                            <asp:DropDownList LabelID="lblTerritoryId" ID="ctlTerritoryIdOperator" Property="<%# SalesOrderCriteria.TerritoryIdOperator %>" AutoPostBack="true" runat="server" CssClass="operator"></asp:DropDownList>
                            <asp:DropDownList ID="ctlTerritoryId" Property="<%# SalesOrderCriteria.TerritoryId %>" AutoPostBack="true" runat="server"></asp:DropDownList>
                          </div>
                          <div class="field">
                            <asp:Label ID="lblSalesPersonId" Text="Sales Person:" CssClass="label" runat="server"></asp:Label>
                            <asp:DropDownList LabelID="lblSalesPersonId" ID="ctlSalesPersonIdOperator" Property="<%# SalesOrderCriteria.SalesPersonIdOperator %>" runat="server" AutoPostBack="true" CssClass="operator"></asp:DropDownList>
                            <asp:ListBox ID="ctlSalesPersonId" Property="<%# SalesOrderCriteria.SalesPersonId %>" runat="server"></asp:ListBox>
                          </div>
                        </td>
                      </tr>
                    </table>
                  </asp:Panel>
                </ContentTemplate>
              </uc:CollapsiblePanel>
              <uc:Errors ID="ucl_Errors" runat="server"></uc:Errors>
              <div class="action-bar">
                <asp:Button ID="btn_Search" Text="Search" CssClass="btn-search" runat="server"></asp:Button>
                <asp:Button ID="btn_Reset" Text="Reset" CssClass="btn-reset" runat="server"></asp:Button>
                <asp:LinkButton ID="lnkPermaLink" CssClass="permalink" Text="PermaLink" OnClick="PermaLink_Click" runat="server"></asp:LinkButton>
              </div>
              <asp:Panel ID="pnlResults" CssClass="xw-obj" runat="server">
                <uc:AppliedCriteria ID="ucl_AppliedCriteria" runat="server"></uc:AppliedCriteria>
                <asp:GridView ID="grd_Results" AllowPaging="True" PageSize="20" runat="server">
                  <Columns>
                    <asp:TemplateField HeaderText="SO#">
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkDetails" runat="server" OnCommand="LinkDetails_Click" CommandArgument="<%# Container.DataItemIndex %>">
                          <asp:Label ID="fldSalesOrderNumber" Property="<%# SalesOrderList.SalesOrderNumber %>" runat="server"></asp:Label>
                        </asp:LinkButton>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                      <ItemTemplate>
                        <asp:Label ID="fldStatus" Property="<%# SalesOrderList.Status %>" runat="server"></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Date">
                      <ItemTemplate>
                        <asp:Label ID="fldOrderDate" Property="<%# SalesOrderList.OrderDate %>" runat="server"></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ship Date">
                      <ItemTemplate>
                        <asp:Label ID="fldShipDate" Property="<%# SalesOrderList.ShipDate %>" runat="server"></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Due Date">
                      <ItemTemplate>
                        <asp:Label ID="fldDueDate" Property="<%# SalesOrderList.DueDate %>" runat="server"></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Due">
                      <ItemTemplate>
                        <asp:Label ID="fldTotalDue" Property="<%# SalesOrderList.TotalDue %>" runat="server"></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Online">
                      <ItemTemplate>
                        <asp:Label ID="fldOnlineOrderFlag" Property="<%# SalesOrderList.OnlineOrderFlag %>" runat="server"></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Store">
                      <ItemTemplate>
                        <asp:Label ID="fldCustomerStore" Property="<%# SalesOrderList.CustomerStore %>" runat="server"></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Name">
                      <ItemTemplate>
                        <asp:Label ID="fldCustomerName" Property="<%# SalesOrderList.CustomerName %>" runat="server"></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sales Person">
                      <ItemTemplate>
                        <asp:Label ID="fldSalesPersonId" Property="<%# SalesOrderList.SalesPersonId %>" runat="server"></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sales Territory">
                      <ItemTemplate>
                        <asp:Label ID="fldTerritoryId" Property="<%# SalesOrderList.TerritoryId %>" runat="server"></asp:Label>
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              </asp:Panel>
              <div class="action-bar">
                <asp:LinkButton ID="LinkNew" runat="server" OnCommand="LinkNew_Click">New</asp:LinkButton>
              </div>
              <div class="action-bar">
                <asp:Button ID="btn_Select" Text="Select" CssClass="btn-select" runat="server"></asp:Button>
                <asp:Button ID="btn_Close" Text="Close" CssClass="btn-close" runat="server"></asp:Button>
              </div>
            </div>
          </div>
        </asp:Panel>
      </ContentTemplate>
    </asp:UpdatePanel>
  </div>
  <div>
    <asp:UpdatePanel ID="uplSalesOrderView" UpdateMode="Conditional" runat="server">
      <ContentTemplate>
        <uc:SalesOrderView ID="uclSalesOrderView" Visible="false" runat="server"></uc:SalesOrderView>
      </ContentTemplate>
    </asp:UpdatePanel>
  </div>
</asp:Panel>