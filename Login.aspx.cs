using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class login : System.Web.UI.Page
{
    public string msg = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //אם נלחץ כפתור השליחה
        if (Request.Form["loginCheck"] != null)
        {
            string txtLoginMail = Request.Form["txtLoginMail"];
            string txtLoginPass = Request.Form["txtLoginPass"];

            //חיפוש משתמש במסד הנתונים ע"פ אימייל וסיסמא
            string strSearch = "SELECT COUNT(fName) FROM members WHERE mail = '" + txtLoginMail.Trim() + "' AND pass='" + txtLoginPass.Trim() + "'";
            object obj = db.ReturnObject(strSearch);

            //אם לא נמצא משתמש
            if (int.Parse(obj.ToString()) == 0)
            {
                msg = "אימייל או סיסמא אינם נכונים";
            }
            else//אם נמצא משתמש
            {
                //לקיחת נתוניו של המשתמש ממסד הנתונים 
                string strSql1 = "SELECT * FROM members WHERE mail = '" + txtLoginMail.Trim() + "' AND pass = '" + txtLoginPass.Trim() + "'";
                DataSet ds = db.ShowTable(strSql1, "members");

                string name = ds.Tables["members"].Rows[0]["fName"].ToString();
                string email = ds.Tables["members"].Rows[0]["mail"].ToString();
                string pass = ds.Tables["members"].Rows[0]["pass"].ToString();
                string isAdmin = ds.Tables["members"].Rows[0]["isAdmin"].ToString();

                //עוגיות, השאר מחובר
                //HttpCookie stayLogged = new HttpCookie("bigCookie");
                //stayLogged.Value = "";

                Session["isAdmin"] = "0";

                //אם מנהל
                if (isAdmin == "1")
                    Session["isAdmin"] = "1";

                Session["userName"] = name;
                Session["userMail"] = email;
                Response.Redirect("Main.aspx");
                Response.End();
            }
        }
    }
}