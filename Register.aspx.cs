using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Register : System.Web.UI.Page
{
    public string hello;
    public string controlPanel;
    public string connGuest;
    public string sessAbnd;

    public string regStatus;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"] == "1")//אם הקליינט הוא מנהל
        {
            controlPanel = "<a href='ControlPanel.aspx'>פאנל ניהול</a>|";
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";
        }
        else if (Session["isAdmin"] != null)
        {//אם הקליינט הוא משתמש רגיל
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";
        }

        if (Request.Form["txtRegFName"] != null && Request.Form["txtRegFName"].ToString() != "")
        {
            string txtRegFName = Request.Form["txtRegFName"];
            string txtRegLName = Request.Form["txtRegLName"];
            string txtRegPass = Request.Form["txtRegPass"];
            string txtRegMail = Request.Form["txtRegMail"];
            string selectRegBirthDate = Request.Form["selectBirthDateDay"] + "/" + Request.Form["selectBirthDateMonth"] + "/" + Request.Form["selectBirthDateYear"];
            string selectRegCity = Request.Form["selectRegCity"];
            string radioRegGender = Request.Form["radioRegGender"];
            string ckBoxRegHobby = Request.Form["ckBoxRegHobby"];
            string txtAreaRegInfo = Request.Form["txtAreaRegInfo"];

            regStatus = "";

            string strSearch = "SELECT COUNT(lName) FROM members WHERE mail = '" + txtRegMail.Trim() + "'";
            object obj = db.ReturnObject(strSearch);

            if (int.Parse(obj.ToString()) > 0)
            {
                regStatus = "המייל קיים במערכת";
            }
            else
            {
                string strInsert = "INSERT INTO members(fName, lName, pass, mail, age, city, gender, hobby, info) VALUES('" + txtRegFName + "','" + txtRegLName + "','" + txtRegPass + "','" + txtRegMail + "','" + selectRegBirthDate + "','" + selectRegCity + "','" + radioRegGender + "','" + ckBoxRegHobby + "','" + txtAreaRegInfo + "')";
                db.InsertUpdateDelete(strInsert);

                //התחברות ישר לאחר הרשמה
                string strSql1 = "SELECT * FROM members WHERE mail = '" + txtRegMail.Trim() + "' AND pass = '" + txtRegPass.Trim() + "'";
                DataSet ds = db.ShowTable(strSql1, "members");

                string name = ds.Tables["members"].Rows[0]["fName"].ToString();
                string email = ds.Tables["members"].Rows[0]["mail"].ToString().Trim();
                string pass = ds.Tables["members"].Rows[0]["pass"].ToString();
                string isAdmin = ds.Tables["members"].Rows[0]["isAdmin"].ToString();

                Session["isAdmin"] = "0";

                if (isAdmin == "1")
                {
                    Session["isAdmin"] = "1";
                }

                Session["userName"] = name;
                Session["userMail"] = email;
                Response.Redirect("Main.aspx");
                Response.End();
            }

        }
    }
}