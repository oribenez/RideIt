using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Application["visitors"] == null)
        {
            Application["visitors"] = 0;
        }

        if (Application["visitors"] != null && Session["visitor"] == null)
        {
            Application.Lock();

            Application["visitors"] = int.Parse(Application["visitors"].ToString()) + 1;

            Application.UnLock();

            Session["visitor"] = "true";
        }
    }
}
