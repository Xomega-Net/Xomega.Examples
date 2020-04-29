using Xomega.Framework;
using Xomega.Framework.Properties;
using Xomega.Framework.Web;

namespace AdventureWorks.Client.Web
{
    public partial class DateTimeControl : BaseDateTimeControl
    {
        public override void OnPropertyBound(DateTimeProperty prop, DataRow row)
        {
            base.OnPropertyBound(prop, row);
            extCalendar.Format = prop.Format;
        }
    }
}