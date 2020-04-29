using System;
using System.Web.UI;
using Xomega.Framework.Views;
using Xomega.Framework.Web;

namespace AdventureWorks.Client.Web
{
    public partial class CollapsiblePanel : UserControl, ICollapsiblePanel
    {
        private const string ExpandedIconText = "&#xf077;";
        private const string CollapsedIconText = "&#xf078;";

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateInstance(TemplateInstance.Single)]
        public ITemplate ContentTemplate { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (ContentTemplate != null)
                ContentTemplate.InstantiateIn(Content);

            Header.Attributes.Add("onclick", $"__doPostBack('{Header.ClientID}', 'Click')");
            twister.Text = ExpandedIconText;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (IsPostBack)
            {
                var controlName = Request.Params.Get("__EVENTTARGET");
                var argument = Request.Params.Get("__EVENTARGUMENT");
                if (controlName == Header.ClientID && argument == "Click")
                {
                    Collapsed = !Collapsed;
                }
            }
        }

        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public bool Collapsed
        {
            get => !pnlCollapsible.Visible;
            set
            {
                WebUtil.SetControlVisible(pnlCollapsible, !value);
                twister.Text = value ? CollapsedIconText : ExpandedIconText;
            }
        }
    }
}