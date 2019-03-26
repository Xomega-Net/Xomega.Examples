//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "WPF Views - Client-Server" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.WpfCS
{
    public partial class CustomerListView
    {
        public CustomerListView()
        {
            InitializeComponent();
        }

        protected override Button CloseButton { get { return btnClose; } }
        protected override IErrorPresenter ErrorsPanel { get { return pnlErrors; } }
        protected override Button SearchButton { get { return btnSearch; } }
        protected override Button SelectButton { get { return btnSelect; } }

        protected override ItemsControl ResultsGrid { get { return gridResults; } }
        protected override Button ResetButton { get { return btnReset; } }
        protected override IAppliedCriteriaPanel AppliedCriteriaPanel { get { return pnlAppliedCriteria; } }
        protected override ICollapsiblePanel CriteriaExpander { get { return new ExpanderCollapsiblePanel(pnlCriteria); } }
        protected override FrameworkElement CriteriaPanel { get { return pnlCriteria; } }
        protected override ContentControl ChildPanel { get { return pnlDetails; } }
    }
}