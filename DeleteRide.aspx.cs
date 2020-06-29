using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteRide : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"].Trim() != null && Request.QueryString["id"].Trim() == "")
        {
            string strDelete = "DELETE * FROM rides WHERE id = '" + Request.QueryString["id"].Trim() + "'";
            db.InsertUpdateDelete(strDelete);  
        }
        Response.Redirect("Rides.aspx");
    }
}