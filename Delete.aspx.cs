using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (txtDelMail.Value != null && txtDelMail.Value != "")
        {

            //עדכון האימייל בטבלאת הרכיבות
            //שאילתה
            string strSql1 = "SELECT ridersMail FROM rides";
            DataSet dsRiders = db.ShowTable(strSql1, "rides");

            string[] mails = new string[dsRiders.Tables["rides"].Rows.Count];

            for (int i = 0; i < mails.Length; i++)//לולאה שרצה על כל רכיבה
            {
                mails[i] = dsRiders.Tables["rides"].Rows[i]["ridersMail"].ToString();
                mails[i] = mails[i].Replace("," + txtDelMail.Value.Trim(), "");
                mails[i] = mails[i].Replace(txtDelMail.Value.Trim() + ",", "");
                mails[i] = mails[i].Replace(txtDelMail.Value.Trim(), "");
                string z =  dsRiders.Tables["rides"].Rows[i]["ridersMail"].ToString();
                z = z.Replace("," + txtDelMail.Value.Trim(), "");
                z = z.Replace(txtDelMail.Value.Trim() + ",", "");
                z = z.Replace(txtDelMail.Value.Trim(), "");

                //עדכון האימייל
                string strUpdateRides = "UPDATE rides SET ridersMail='" + z + "' WHERE id = " + i + "";
                db.InsertUpdateDelete(strUpdateRides);


            }

            //מחיקת משתמש ע"פ אימייל
            string strDelete = "DELETE * FROM members WHERE mail = '" + txtDelMail.Value.Trim() + "'";
            db.InsertUpdateDelete(strDelete);

            Response.Redirect("ShowMembers.aspx");
        }

        //הצגת נתוניו של המשתמש לפני מחיקה
        if (Request.QueryString["mail"] != null && Request.QueryString["mail"].ToString() != "")
        {
            string mailCheck = Request.QueryString["mail"].ToString();
            string strSql1 = "SELECT * FROM members WHERE mail = '" + mailCheck.Trim() + "'";
            DataSet ds = db.ShowTable(strSql1, "members");

            //אתחול נתוניו של המשתמש למשתנים
            string fNameTemp = ds.Tables["members"].Rows[0]["fName"].ToString();
            string lNameTemp = ds.Tables["members"].Rows[0]["lName"].ToString();
            string mailTemp = ds.Tables["members"].Rows[0]["mail"].ToString();

            //הצגת נתוניו של המשתמש
            txtDelFName.Value = fNameTemp;
            txtDelLName.Value = lNameTemp;
            txtDelMail.Value = mailTemp;
        }

     
    }
}