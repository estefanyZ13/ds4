using System;
using System.Web;
using System.Web.Routing;
namespace CafeteriaWebForms

{
    public partial class ViewSwitcher : System.Web.UI.UserControl
    {
        protected string CurrentView { get; private set; }

        protected string AlternateView { get; private set; }

        protected string SwitchUrl { get; private set; }

    }
}