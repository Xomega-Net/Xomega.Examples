//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "WPF Views" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using AdventureWorks.Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using System.Windows.Input;
using Xomega.Framework;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Wpf
{
    public partial class SalesOrderView
    {
        protected SalesOrderViewModel VM => Model as SalesOrderViewModel;

        public SalesOrderView()
        {
            LinkCustomerLookupLookUp_Command = new RelayCommand<object>(LinkCustomerLookupLookUp_Execute, LinkCustomerLookupLookUp_Enabled);
            LinkDetailDetails_Command = new RelayCommand<DataRow>(LinkDetailDetails_Execute, LinkDetailDetails_Enabled);
            LinkDetailNew_Command = new RelayCommand<object>(LinkDetailNew_Execute, LinkDetailNew_Enabled);
            InitializeComponent();
            IsAsync = true;
        }

        #region LinkCustomerLookupLookUp_Command

        public ICommand LinkCustomerLookupLookUp_Command { get; set; }

        public virtual async void LinkCustomerLookupLookUp_Execute(object arg)
        {
            if (VM == null) return;
            WPFView cur = null as CustomerListView;
            WPFView tgt = cur ?? VM.ServiceProvider.GetService<CustomerListView>();
            tgt.Owner = this;
            await VM.LinkCustomerLookupLookUp_CommandAsync(tgt, cur);
        }

        public virtual bool LinkCustomerLookupLookUp_Enabled(object arg)
            => VM != null && VM.LinkCustomerLookupLookUp_Enabled();

        #endregion

        #region LinkDetailDetails_Command

        public ICommand LinkDetailDetails_Command { get; set; }

        public virtual async void LinkDetailDetails_Execute(DataRow row)
        {
            if (VM == null) return;
            WPFView cur = null as SalesOrderDetailView;
            WPFView tgt = cur ?? VM.ServiceProvider.GetService<SalesOrderDetailView>();
            tgt.Owner = this;
            await VM.LinkDetailDetails_CommandAsync(tgt, cur, row);
        }

        public virtual bool LinkDetailDetails_Enabled(DataRow row)
            => VM != null && VM.LinkDetailDetails_Enabled(row);

        #endregion

        #region LinkDetailNew_Command

        public ICommand LinkDetailNew_Command { get; set; }

        public virtual async void LinkDetailNew_Execute(object arg)
        {
            if (VM == null) return;
            WPFView cur = null as SalesOrderDetailView;
            WPFView tgt = cur ?? VM.ServiceProvider.GetService<SalesOrderDetailView>();
            tgt.Owner = this;
            await VM.LinkDetailNew_CommandAsync(tgt, cur);
        }

        public virtual bool LinkDetailNew_Enabled(object arg)
            => VM != null && VM.LinkDetailNew_Enabled();

        #endregion

        protected override TextBlock TitleControl => viewTitle;
        protected override Button CloseButton => btnClose;
        protected override IErrorPresenter ErrorsPanel => pnlErrors;
        protected override Button DeleteButton => btnDelete;
        protected override Button SaveButton => btnSave;
    }
}