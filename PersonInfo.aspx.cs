using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PersonInfo : System.Web.UI.Page
{
    public string str;
    public string sessAbnd;
    public string controlPanel;
    protected void Page_Load(object sender, EventArgs e)
    {
        //אבטחת הדף למחוברים בלבד
        if (Session["userMail"] != null)
        {
            string strSql1 = "SELECT * FROM members WHERE mail= '" + Request.QueryString["mail"].ToString() + "'";
            DataSet ds = db.ShowTable(strSql1, "members");

            string fName = ds.Tables["members"].Rows[0]["fName"].ToString().Trim();
            string lName = ds.Tables["members"].Rows[0]["lName"].ToString().Trim();
            string mail = ds.Tables["members"].Rows[0]["mail"].ToString().Trim();
            string birth = ds.Tables["members"].Rows[0]["age"].ToString().Trim();
            int birthYear = int.Parse(birth.Substring(birth.LastIndexOf('/') + 1, birth.Length - 1 - birth.LastIndexOf('/')));
            DateTime dt1 = DateTime.Now;
            int ageSub = dt1.Year - birthYear;

            string age = ageSub.ToString();
            string city = ds.Tables["members"].Rows[0]["city"].ToString().Trim();
            string gender = ds.Tables["members"].Rows[0]["gender"].ToString().Trim();
            string hobby = ds.Tables["members"].Rows[0]["hobby"].ToString().Trim();
            string info = ds.Tables["members"].Rows[0]["info"].ToString().Trim();

            //protectedLinks
            controlPanel = "<a href='ControlPanel.aspx'>פאנל ניהול</a>|";
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";


            str += "<h1>פרטים אישיים</h1>";

            str += "<div style='line-height: 25px'>";
            str += "<b>שם פרטי: </b>" + fName;
            str += "<br />";

            str += "<b>שם משפחה: </b>" + lName;
            str += "<br />";

            str += "<b>אימייל: </b>" + mail;
            str += "<br />";

            str += "<b>גיל: </b>" + age;
            str += "<br />";

            str += "<b>עיר מגורים: </b>" + city;
            str += "<br />";

            str += "<b>מגדר: </b>" + gender;
            str += "<br />";

            str += "<b>תחביבים: </b>" + hobby;
            str += "<br />";

            str += "<b>מידע: </b>" + info;
            str += "<br /><br />";
            str += "</div>";

            str += "<a href='Main.aspx'><input type='button' value='חזור לדף הבית' /></a>";

        }
        else
        {
            str += "עליך להתחבר כדי לראות תוכן זה.  <a href='Login.aspx' style='color:#67bf8a; '>להתחברות</a>";
        }
    }
}