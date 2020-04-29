//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "ASP.NET Views" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using AdventureWorks.Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xomega.Framework;
using Xomega.Framework.Web;

namespace AdventureWorks.Client.Web
{
    public partial class SalesOrderView : WebDetailsView
    {
        protected SalesOrderViewModel VM => Model as SalesOrderViewModel;

        public SalesOrderView()
        {
            Model = ServiceProvider.GetService<SalesOrderViewModel>();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            SubscribeToChildEvents(uclCustomerListView);
            SubscribeToChildEvents(uclSalesOrderDetailView);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (VM == null) return;
            Page.RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                LinkCustomerLookupLookUp.Enabled = VM.LinkCustomerLookupLookUp_Enabled();
                LinkDetailNew.Enabled = VM.LinkDetailNew_Enabled();
                await Task.CompletedTask;
            }));
        }

        protected virtual void LinkCustomerLookupLookUp_Click(object sender, CommandEventArgs e)
        {
            if (VM == null) return;
            Page.RegisterAsyncTask(new PageAsyncTask(async () =>
                await VM.LinkCustomerLookupLookUp_CommandAsync(uclCustomerListView, null)));
        }

        protected virtual void LinkDetailDetails_Click(object sender, CommandEventArgs e)
        {
            if (VM == null) return;
            int index = int.Parse(e.CommandArgument.ToString());
            DataRow row = VM.MainObj.DetailList.GetData()[index];
            Page.RegisterAsyncTask(new PageAsyncTask(async () =>
                await VM.LinkDetailDetails_CommandAsync(uclSalesOrderDetailView, null, row)));
        }

        protected virtual void LinkDetailNew_Click(object sender, CommandEventArgs e)
        {
            if (VM == null) return;
            Page.RegisterAsyncTask(new PageAsyncTask(async () =>
                await VM.LinkDetailNew_CommandAsync(uclSalesOrderDetailView, null)));
        }
    }
}