using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Update : System.Web.UI.Page
{

    static string originMail;
    public string regStatus;
    public string str = "";

    public string fNameTemp;
    public string lNameTemp;
    public string passTemp;
    public string mailTemp;
    public string ageTemp;
    public DataSet ds;
    public string cityTemp;
    public string genderTemp;
    public string hobbyTemp;
    public string infoTemp;
    public string isAdminTemp;

    public string controlPanel;
    public string sessAbnd;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"] == "1")
        {
            controlPanel = "<a href='ControlPanel.aspx'>פאנל ניהול</a>|";
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";
            
        }

        //אבטחת הדף למחוברים בלבד
        if (Session["userMail"] != null)
        {
            if (Session["isAdmin"] != "1")
            {
                if (Session["userMail"].ToString().Trim() != Request.QueryString["mail"].Trim())
                {
                    Response.Redirect("404Err.aspx");
                }
            }
            if (Request.Form["txtUpFName"] != null && Request.Form["txtUpFName"] != "")
            {
                string fName = Request.Form["txtUpFName"].Trim();
                string lName = Request.Form["txtUpLName"].Trim();
                string pass = Request.Form["txtUpPass"].Trim();
                string mail = Request.Form["txtUpMail"].Trim();
                string selectRegBirthDate = Request.Form["selectBirthDateDay"] + "/" + Request.Form["selectBirthDateMonth"] + "/" + Request.Form["selectBirthDateYear"];
                string city = Request.Form["selectUpCity"].Trim();
                //string gender = Request.Form["txtUpGender"].Trim();
                string hobby = Request.Form["ckBoxUpHobby"].Trim();
                string info = Request.Form["txtAreaUpInfo"].Trim();

                string ckBoxUpManager = "";
                if (Session["isAdmin"] == "1")
                    ckBoxUpManager = Request.Form["ckBoxUpManager"];

                if (originMail.Trim() == mail.Trim())//אם האימייל לא שונה
                {
                    if (Validation(fName, lName, pass, mail, selectRegBirthDate))
                    { 
                        //שאילתה
                        string strUpdate = "UPDATE members SET fName='" + fName + "'";
                        strUpdate += ", lName='" + lName + "'";
                        strUpdate += ", pass='" + pass + "'";
                        strUpdate += ", age='" + selectRegBirthDate + "'";
                        strUpdate += ", city='" + city + "'";
                        //strUpdate += ", gender='" + gender + "'";
                        strUpdate += ", hobby='" + hobby + "'";
                        strUpdate += ", info='" + info + "'";
                        if (Session["isAdmin"] == "1")
                            strUpdate += ", isAdmin='" + ckBoxUpManager + "'";
                        strUpdate += "WHERE mail='" + originMail.Trim() + "'";

                        db.InsertUpdateDelete(strUpdate);
                        Response.Redirect("ControlPanel.aspx");
                    }
                    else
                        AutoFill();

                }
                else//אם האימייל שונה
                {
                    regStatus = "";

                    string strSearch = "SELECT COUNT(lName) FROM members WHERE mail = '" + mail.Trim() + "'";
                    object obj = db.ReturnObject(strSearch);

                    if (int.Parse(obj.ToString()) > 0)
                    {
                        regStatus = "המייל קיים במערכת";
                    }
                    else
                    {
                        if (Validation(fName, lName, pass, mail, selectRegBirthDate))
                        {
                            //עדכון האימייל בטבלאת הרכיבות
                            //שאילתה
                            string strSql1 = "SELECT ridersMail FROM rides";
                            DataSet dsRiders = db.ShowTable(strSql1, "rides");

                            string[] id = new string[dsRiders.Tables["rides"].Rows.Count];

                            for (int i = 0; i < id.Length; i++)//לולאה שרצה על כל רכיבה
                            {
                                id[i] = dsRiders.Tables["rides"].Rows[i]["ridersMail"].ToString();
                                if (id[i].IndexOf(Session["userMail"].ToString().Trim()) != -1)
                                {
                                    string newMailsRides = id[i].Replace(Session["userMail"].ToString(), mail);

                                    //עדכון האימייל
                                    string strUpdateRides = "UPDATE rides SET ridersMail='" + newMailsRides + "' WHERE id = " + i;
                                    db.InsertUpdateDelete(strUpdateRides);
                                }
                            }


                            //שאילתה
                            string strUpdate = "UPDATE members SET fName='" + fName + "'";
                            strUpdate += ", lName='" + lName + "'";
                            strUpdate += ", pass='" + pass + "'";
                            strUpdate += ", mail='" + mail + "'";
                            strUpdate += ", age='" + selectRegBirthDate + "'";
                            strUpdate += ", city='" + city + "'";

                            strUpdate += ", hobby='" + hobby + "'";
                            strUpdate += ", info='" + info + "'";
                            if (Session["isAdmin"] == "1")
                                strUpdate += ", isAdmin='" + ckBoxUpManager + "'";
                            strUpdate += "WHERE mail='" + originMail.Trim() + "'";

                            Session["userMail"] = mail;

                            db.InsertUpdateDelete(strUpdate);
                            Response.Redirect("ControlPanel.aspx");
                        }
                        else
                            AutoFill();
                    }
                }
            }


            if (!IsPostBack)
            {
                if (Request.QueryString["mail"] != null && Request.QueryString["mail"].ToString() != "")
                {
                    AutoFill();

                    originMail = mailTemp;
                }
            }
        }
        else
        {
            Response.Redirect("adminErr.aspx");
            Response.End();
        }
    }

    private void AutoFill()
    {
        string txtRegMailCheck = Request.QueryString["mail"].ToString();
        string strSql1 = "SELECT * FROM members WHERE mail = '" + txtRegMailCheck.Trim() + "'";
        DataSet ds = db.ShowTable(strSql1, "members");

        fNameTemp = ds.Tables["members"].Rows[0]["fName"].ToString();
        lNameTemp = ds.Tables["members"].Rows[0]["lName"].ToString();
        passTemp = ds.Tables["members"].Rows[0]["pass"].ToString();
        mailTemp = ds.Tables["members"].Rows[0]["mail"].ToString();
        ageTemp = ds.Tables["members"].Rows[0]["age"].ToString();
        cityTemp = ds.Tables["members"].Rows[0]["city"].ToString();
        genderTemp = ds.Tables["members"].Rows[0]["gender"].ToString();
        hobbyTemp = ds.Tables["members"].Rows[0]["hobby"].ToString();
        infoTemp = ds.Tables["members"].Rows[0]["info"].ToString();
        if (Session["isAdmin"] == "1")
            isAdminTemp = ds.Tables["members"].Rows[0]["isAdmin"].ToString();

        originMail = mailTemp;
    }

    private bool Validation(string fName, string lName, string pass, string mail, string age)
    {
        if (!ValidFName(fName)) return false;
        if (!ValidLName(lName)) return false;
        if (!ValidPass(pass)) return false;
        if (!ValidMail(mail)) return false;
        if (!ValidAge(age)) return false;

        return true;
    }

    private bool ValidFName(string str)
    {
        if (str == "")
        {
            regStatus = "הכנס שם פרטי";
            return false;
        }
        if (str.Length < 2 || str.Length > 10)
        {
            regStatus = "אורך השם פרטי לא הגיוני";
            return false;
        }
        if (!Numbers(str))
        {
            regStatus = "אסור מספרים בשם הפרטי";
            return false;
        }
        if (!noSigns(str))
        {
            regStatus = "תווים אסורים בשם פרטי";
            return false;
        }

        return true;
    }

    private bool ValidLName(string str)
    {
        if (str == "")
        {
            regStatus = "הכנס שם משפחה";
            return false;
        }
        if (str.Length < 2 || str.Length > 10) 
        {
            regStatus = "אורך שם משפחה לא תקין";
            return false;
        }
        if (Numbers(str) == false) 
        {
            regStatus = "אסור מספרים בשם המשפחה";
            return false;
        }
        if (noSigns(str) == false) 
        {
            regStatus = "תווים אסורים בשם המשפחה";
            return false;
        }

        return true;
    }

    private bool ValidPass(string str)
    {
        if (str == "") 
        {
            regStatus = "הכנס סיסמא";  
            return false;
        }

        if (str.Length < 6) 
        {
            regStatus = "אורך הסיסמא לפחות 6 תווים";
            return false;
        }

        return true;
    }

    private bool ValidMail(string str)
    {
        if (str == "") 
        {
            regStatus = "הכנס אימייל";
            return false;
        }

        if (str.IndexOf("@") == -1) 
        {
            regStatus = "אימייל לא תקין";
            return false;
        }
        if (str.LastIndexOf("@") != str.IndexOf("@")) 
        {
            regStatus = "אימייל לא תקין";
            return false;
        }
        if (str.IndexOf(".") == -1) 
        {
            regStatus = "אימייל לא תקין";
            return false;
        }
        if (str.IndexOf("@.") != -1)
        {
            regStatus = "אימייל לא תקין";
            return false;
        }
        string mailEnd = str.Substring(str.LastIndexOf('.') + 1);
        if (mailEnd != "com" && mailEnd != "net" && mailEnd != "il" && mailEnd != "org" && mailEnd != "gov" && mailEnd != "biz" && mailEnd != "info")
        {
            regStatus = "סיומת אימייל לא תקינה";
            return false;
        }

        if (IsSmallEnglish(str) == false)
        {
            regStatus = "אימייל לא תקין";
            return false;
        }
        return true;
    }

    private bool ValidAge(string age)
    {
        string[] ageSplt = age.Split('/');

        for (int i = 0; i < ageSplt.Length; i++)
        {
            if (ageSplt[i] == "")
            {
                regStatus = "הכנס תאריך";
                return false;
            }
        }

        return true; 
    }

    //private int IsChecked(int ckBoxUp) {
    //    for (int i = 0; i < ckBoxUp.Length; i++)  // הסימון תיבות מערך על מעבר
    //        if (ckBoxUp[i] == 1) //   מסומנת תיבה אם   
    //            return 1;
    //    return 0;
    //}



    ///////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////
    //                             בדיקת עברית בלבד 
    //
    private bool IsHbrew(string srt)
    { 
        for(int i=0;i<srt.Length;i++)
        {
        if (!(srt[i]>='א'&& srt[i]<='ת' ))
        {
                return false;
        }
        }
        return true;
     }

    ////////////////////////////////////////////////////////////////////////////////////////
    //                                  בדיקת מספרים   

     private bool Numbers(string str)
     {
         for (int i = 0; i < str.Length; i++)
         {
             if (str[i] >= 1 && str[i] <= 9)
             {
                 return false;
             }
         }
         return true;
     }

    ///////////////////////////////////////////////////////////////////////////////////////////
    //                                     תווים אסורים  
    private bool noSigns(string str)
    {
        string t = "*$%#@\"()";
        for (int i = 0; i < str.Length; i++)
        {
            for (int j = 0; j < t.Length; j++) 
            {
                if (str[i] == t[j])
                {
                    return false;
                }
            }
        }
        return true;
    }

     /////////////////////////////////////////////////////////////////////////////////////////
    //                                      אנגלית בלבד  
    private bool IsSmallEnglish(string srt) 
    {
        for(int i=0;i<srt.Length;i++)
        {
            if (srt[i] >= 'א' && srt[i] <= 'ת')
            {
                return false;
            }
        }
        return true;
    }
} 