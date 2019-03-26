using System;
using System.Linq;
using System.Web.UI;
using Xomega.Framework;
using Xomega.Framework.Views;

namespace AdventureWorks.Client.Web
{
    public partial class Errors : UserControl, IErrorPresenter
    {
        private ErrorList errorList;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Visible = false;
        }

        public void Show(ErrorList errorList)
        {
            this.errorList = errorList;
            if (errorList == null || errorList.Errors.Count == 0)
            {
                Visible = false;
                rptErrors.DataSource = null;
                rptErrors.DataBind();
                lblTitle.Text = "";
            }
            else
            {
                rptErrors.DataSource = errorList.Errors;
                rptErrors.DataBind();
                Visible = true;
                string str = errorList.Errors.Any(e => e.Severity > ErrorSeverity.Warning) ? "error" :
                    errorList.Errors.Any(e => e.Severity > ErrorSeverity.Info) ? "warning" : "message";
                str = "Please review the following " + str;
                if (errorList.Errors.Count > 1) str += "s";
                lblTitle.Text = str;
            }
        }

        protected string GetIconClass(ErrorSeverity severity)
        {
            switch (severity)
            {
                case ErrorSeverity.Critical:
                case ErrorSeverity.Error: return "fa-exclamation-circle";
                case ErrorSeverity.Warning: return "fa-exclamation-triangle";
                case ErrorSeverity.Info: return "fa-info-circle";
            }
            return "";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            if (errorList != null) errorList.Clear();
            Show(errorList);
        }
    }
}