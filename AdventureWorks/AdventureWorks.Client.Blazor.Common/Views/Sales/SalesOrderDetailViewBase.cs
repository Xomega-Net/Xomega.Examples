//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Blazor Views" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using AdventureWorks.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Xomega.Framework.Blazor.Views;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Blazor.Common.Views
{
    public partial class SalesOrderDetailViewBase : BlazorDetailsView
    {
        [Inject] protected SalesOrderDetailViewModel VM { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            BindTo(VM);
        }

        public override void BindTo(ViewModel viewModel)
        {
            VM = viewModel as SalesOrderDetailViewModel;
            base.BindTo(viewModel);
        }
    }
}
