using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page
{
    public string hello;
    public string controlPanel;
    public string connGuest;
    public string sessAbnd;
    public string protectedLink;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"] == null)//אם הקליינט הוא אורח
        {
            hello = "שלום אורח חביב";
            connGuest = "<a href='Login.aspx'>התחברות</a> | <a href='Register.aspx'>הרשמה</a>";
        }
        else if (Session["isAdmin"] == "1")//אם הקליינט הוא מנהל
        {
            hello = "שלום המנהל, " + Session["userName"];
            controlPanel = "<a href='ControlPanel.aspx'>פאנל ניהול</a>|";
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";
        }
        else {//אם הקליינט הוא משתמש רגיל
            hello = "שלום, " + Session["userName"];
            controlPanel = "<a href='ControlPanel.aspx'>פאנל ניהול</a>|";
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";
        }
    }
}