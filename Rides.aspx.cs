using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Mail;
using System.IO;

public partial class Rides : System.Web.UI.Page
{
    public string hello;
    public string controlPanel;
    public string connGuest;
    public string sessAbnd;
    public string protectedLink;

    public string str;
    static string err = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string tableName = "rides";
        string strSql1 = "SELECT * FROM " + tableName + " ORDER BY id";
        DataSet ds = db.ShowTable(strSql1, tableName);

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
        else
        {//אם הקליינט הוא משתמש רגיל
            hello = "שלום, " + Session["userName"];
            controlPanel = "<a href='ControlPanel.aspx'>פאנל ניהול</a>|";
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";
        }

        //אם זה הדף הראשי של רכיבות
        if (Request.QueryString["post"] == null)
        {
            str += "<h1>רכיבות</h1>";
            str += "<div id='tableWrapper'><table class='oddEven'>";
            str += "<tr class='trFirstRow'><td> שם הטיול </td> <td> תאריך </td><td> יום </td><td> איזור </td><td>אופי</td><td>מרחק</td><td> סטטוס </td> </tr>";

            //הצגת כל הרכיבות שנוצרו
            for (int i = 0; i < ds.Tables[tableName].Rows.Count; i++)
            {
                string strSql2 = "SELECT fName FROM members WHERE mail = '" + ds.Tables[tableName].Rows[i]["mail"].ToString() + "'";
                DataSet ds2 = db.ShowTable(strSql2, "members");

                string trClassOddEven = "even";

                if (i % 2 == 0)
                    trClassOddEven = "even";
                else
                    trClassOddEven = "odd";

                str += "<tr class='" + trClassOddEven + "'>";

                str += "<td style='text-align: right;'><a href='Rides.aspx?post=" + ds.Tables[tableName].Rows[i]["id"].ToString() + "'><div style='font-size: 14px; font-weight: bold;'>" + ds.Tables[tableName].Rows[i]["routeName"].ToString() + "</div>";
                str += "<div>" + ds2.Tables["members"].Rows[0]["fName"].ToString() + "-" + ds.Tables[tableName].Rows[i]["dateCreate"].ToString() + "</div></a></td>";
                str += "<td><a href='Rides.aspx?post=" + i + "'><div>" + ds.Tables[tableName].Rows[i]["dateRide"].ToString() + "</div>";
                str += "<div>" + ds.Tables[tableName].Rows[i]["rideHourStart"].ToString() + "</div></a></td>";
                str += "<td><a href='Rides.aspx?post=" + i + "'>" + ds.Tables[tableName].Rows[i]["day"].ToString() + "</td>";
                str += "<td><a href='Rides.aspx?post=" + i + "'>" + ds.Tables[tableName].Rows[i]["area"].ToString() + "</a></td>";
                str += "<td><a href='Rides.aspx?post=" + i + "'><div>" + ds.Tables[tableName].Rows[i]["teq"].ToString() + "</div>";
                str += "<div>" + ds.Tables[tableName].Rows[i]["hardness"].ToString() + "</div></a></td>";
                str += "<td><a href='Rides.aspx?post=" + i + "'>" + ds.Tables[tableName].Rows[i]["km"].ToString() + " ק''מ</a></td>";
                str += "<td><a href='Rides.aspx?post=" + i + "'>פתוח להרשמה עד " + ds.Tables[tableName].Rows[i]["maxRiders"].ToString() + " רוכבים";
                str += "<div>רשומים " + int.Parse(ds.Tables[tableName].Rows[i]["numRiders"].ToString()) + "</div></a></td>";

                str += "</tr>";
            }
            str += "</table></div>";
        }
        else//אם זה רכיבה מסויימת
        {
            //מספר הפוסט
            int postNo = int.Parse(Request.QueryString["post"]);
            
            str += "<br /><div style='font-size: 19px; font-weight: bold;'>" + ds.Tables[tableName].Rows[postNo]["routeName"].ToString() + "</div>";
            str += "<div>";
            str += "<br /><div style='float: right;font-size: 14px;margin: 0 0 0 56px; font-family: Arial, Tahoma;'>";
            str += "<h4 style='font-size:17px;'>פרטי טיול</h4><br /><ul style='list-style-type: none;'>";
            str += "<li><b>איזור: </b>" + ds.Tables[tableName].Rows[postNo]["area"].ToString() + "</li> ";
            str += "<li><b>מרחק: </b>" + ds.Tables[tableName].Rows[postNo]["km"].ToString() + "</li> ";
            str += "<li><b>אופי: </b>" + ds.Tables[tableName].Rows[postNo]["teq"].ToString() + "</li> ";
            str += "<li><b>קושי: </b>" + ds.Tables[tableName].Rows[postNo]["hardness"].ToString() + "</li> ";
            str += "<li><b>טיפוס מצטבר: </b>" + ds.Tables[tableName].Rows[postNo]["up"].ToString() + " מטר</li> ";
            str += "<li><b>ירידות מצטברות: </b>" + ds.Tables[tableName].Rows[postNo]["down"].ToString() + "מטר</li> ";
            str += "<li><b>מסלול מעגלי </b>" + ds.Tables[tableName].Rows[postNo]["circleRoad"].ToString() + "</li> ";
            
            str += "</ul></div>";

            str += "<div style='float: right;font-size: 14px; margin: 0 0 0 56px; font-family: Arial, Tahoma;'>";
            str += "<h4 style='font-size:17px;'>תאריך, יום ושעה</h4><br /><ul style='list-style-type: none;'>";
            str += "<li>" + ds.Tables[tableName].Rows[postNo]["dateRide"].ToString() + "</li> ";

            string day = ds.Tables[tableName].Rows[postNo]["day"].ToString();
            if (day == "א")
                day = "ראשון";
            if (day == "ב")
                day = "שני";
            if (day == "ג")
                day = "שלישי";
            if (day == "ד")
                day = "רביעי";
            if (day == "ה")
                day = "חמישי";
            if (day == "ו")
                day = "שישי";
            if (day == "ש")
                day = "שבת";
            str += "<li>יום " + day + "</li> ";
            str += "<li>" + ds.Tables[tableName].Rows[postNo]["rideHourEnd"].ToString() + " - " + ds.Tables[tableName].Rows[postNo]["rideHourStart"].ToString() + "</li> ";

            str += "</ul></div>";

            string strSql3 = "SELECT imgPath,fName,lName,city,mail FROM members WHERE mail = '" + ds.Tables[tableName].Rows[postNo]["mail"].ToString() + "'";
            DataSet ds3 = db.ShowTable(strSql3, "members");

            str += "<div style='float: right;font-size: 14px;margin: 0 0 0 56px; font-family: Arial, Tahoma;'>";
            str += "<h4 style='font-size:17px;'>מוביל הטיול</h4><br /><ul style='list-style-type: none;'>";
            str += "<li><img src='" + ds3.Tables["members"].Rows[0]["imgPath"].ToString() + "' alt='' width='130' height='100' /></li> ";
            str += "<li>" + ds3.Tables["members"].Rows[0]["fName"].ToString() + " " + ds3.Tables["members"].Rows[0]["lName"].ToString() + "</li> ";
            
            str += "</ul></div>";

            str += "</div>";



            if (Session["userMail"] != null)//אם הקלינט הוא משתמש מחובר ולא אורח
            {
                string mailGroup = ds.Tables[tableName].Rows[postNo]["ridersMail"].ToString();
                string mailLeader = ds.Tables[tableName].Rows[postNo]["mail"].ToString();

                //אם הקלינט הוא לא מוביל הטיול
                if (ds.Tables[tableName].Rows[postNo]["mail"].ToString().Trim() != Session["userMail"].ToString())
                {
                    if (mailGroup != "")//אם יש כבר אנשים בטיול חוץ מהמוביל
                    {
                        int counter = 0;
                        string[] ridersMailArray = mailGroup.Split(',');
                        bool flag = false;
                        string mails = "";
                        counter += ridersMailArray.Length;

                        for (int i = 0; i < ridersMailArray.Length; i++)
                        {
                            //אם הקליינט נמצא בטיול
                            if (Session["userMail"].ToString() == ridersMailArray[i])
                            {
                                str += "<input type='submit' name='quitTrip' id='quitTrip' value='צא מטיול' /><div style='font-weight: bold; color: red;'>" + err + "</div>";
                                flag = true;
                            }
                            else
                            {
                                //כל המיילים חוץ משלי
                                mails += ridersMailArray[i] + ",";
                            }
                        }
                        if (flag)//אם הקלינט כבר בטיול
                        {
                            if (Request.Form["quitTrip"] != null && Request.Form["quitTrip"] != "")
                            {
                                //if (mails.IndexOf())
                                //{
                                    
                                //}
                                //מחיקת המשתמש מהרכיבה
                                string strUpdate = "UPDATE " + tableName + " SET ridersMail='" + mails.Trim(',') + "', numRiders=" + (counter);
                                strUpdate += " WHERE id=" + postNo;

                                db.InsertUpdateDelete(strUpdate);

                                err = "יצאת מטיול זה";
                                Response.Redirect("Rides.aspx?post=" + Request.QueryString["post"]);//רענון הדף
                            }
                        }
                        else//אם הקליינט לא בטיול
                        {
                            str += "<input type='submit' name='joinTrip' id='joinTrip' value='הצטרף לטיול' /><div style='font-weight: bold; color: red;'>" + err + "</div>";
                        }
                    }
                    else
                    {
                        str += "<input type='submit' name='joinTrip' id='joinTrip' value='הצטרף לטיול' /><div style='font-weight: bold; color: red;'>" + err + "</div>";
                    }
                    

                    if (Request.Form["joinTrip"] != null && Request.Form["joinTrip"] != "")//אם הכפתור "הצטרף לטיול" נלחץ
                    {
                        
                        int counter = 1;

                        if (mailGroup != "")//אם יש כבר אנשים בטיול חוץ מהמוביל
                        {
                            string[] ridersMailArray = mailGroup.Split(',');
                            bool flag = false;
                            counter += ridersMailArray.Length;
                            for (int i = 0; i < ridersMailArray.Length && !flag; i++)
                            {
                                if (Session["userMail"].ToString() == ridersMailArray[i])
                                {
                                    err = "הינך רשום לטיול זה";
                                    flag = true;

                                    //רענון הדף
                                    Response.Redirect("Rides.aspx?post=" + Request.QueryString["post"]);
                                }
                            }
                            if (!flag)
                            {
                                string mails = Session["userMail"].ToString() + "," + mailGroup;
                                string strUpdate = "UPDATE " + tableName + " SET ridersMail='" + mails + "', numRiders=" + (counter + 1);
                                strUpdate += " WHERE id=" + postNo;

                                db.InsertUpdateDelete(strUpdate);
                                err = "נרשמת בהצלחה לטיול זה";

                                //שליחת אימייל למשתמש שנכנס לרכיבה
                                string from = "tiptop.yben@gmail.com";
                                string to = Session["userMail"].ToString();
                                string subject = ds.Tables[tableName].Rows[postNo]["routeName"].ToString() + " - RIDE IT";
                                string body = "<div style='color: rgb(75, 75, 75); padding: 15px;'><img src='http://localhost:13691/RIDEIT010513 _0000/images/logoBig.png' width='112' height='105' style='float: left;' />&nbsp;&nbsp;<img src='http://localhost:13691/RIDEIT010513 _0000/images/logo2Big.png' style='margin: 30px 0 0 0; float: left;' />";
                                body += "<div style='font-size: 26px; font-weight: bold; text-align: right;'>";
                                body += "&nbsp;&nbsp;" + ds.Tables[tableName].Rows[postNo]["routeName"].ToString();
                                body += "</div>";

                                body += "<br /><div style='float: right;font-size: 14px;margin: 0 0 0 56px; font-family: Arial, Tahoma; text-align: right;'>";
                                body += "<h4 style='font-size:17px; text-align: right;'>פרטי טיול</h4><ul style='list-style-type: none; text-align: right;'>";
                                body += "<li><b>איזור: </b>" + ds.Tables[tableName].Rows[postNo]["area"].ToString() + "</li> ";
                                body += "<li><b>מרחק: </b>" + ds.Tables[tableName].Rows[postNo]["km"].ToString() + "</li> ";
                                body += "<li><b>אופי: </b>" + ds.Tables[tableName].Rows[postNo]["teq"].ToString() + "</li> ";
                                body += "<li><b>קושי: </b>" + ds.Tables[tableName].Rows[postNo]["hardness"].ToString() + "</li> ";
                                body += "<li><b>טיפוס מצטבר: </b>" + ds.Tables[tableName].Rows[postNo]["up"].ToString() + " מטר</li> ";
                                body += "<li><b>ירידות מצטברות: </b>" + ds.Tables[tableName].Rows[postNo]["down"].ToString() + "מטר</li> ";
                                body += "<li><b>מסלול מעגלי: </b>" + ds.Tables[tableName].Rows[postNo]["circleRoad"].ToString() + "</li> ";

                                body += "</ul></div>";

                                body += "<div style='float: right;font-size: 14px; margin: 0 0 0 56px; font-family: Arial, Tahoma; text-align: right;'>";
                                body += "<h4 style='font-size:17px;'>תאריך, יום ושעה</h4><ul style='list-style-type: none;'>";
                                body += "<li>" + ds.Tables[tableName].Rows[postNo]["dateRide"].ToString() + "</li> ";

                                day = ds.Tables[tableName].Rows[postNo]["day"].ToString();
                                if (day == "א")
                                    day = "ראשון";
                                if (day == "ב")
                                    day = "שני";
                                if (day == "ג")
                                    day = "שלישי";
                                if (day == "ד")
                                    day = "רביעי";
                                if (day == "ה")
                                    day = "חמישי";
                                if (day == "ו")
                                    day = "שישי";
                                if (day == "ש")
                                    day = "שבת";
                                body += "<li>" + day + "</li> ";
                                body += "<li>" + ds.Tables[tableName].Rows[postNo]["rideHourEnd"].ToString() + " - " + ds.Tables[tableName].Rows[postNo]["rideHourStart"].ToString() + "</li> ";

                                body += "</ul></div>";

                                body += "<div style='float: right;font-size: 14px;margin: 0 0 0 56px; font-family: Arial, Tahoma; text-align: right;'>";
                                body += "<h4 style='font-size:17px;'>מוביל הטיול</h4><ul style='list-style-type: none;'>";
                                body += "<li><a href='" + mailLeader + "'><img src='http://localhost:13691/RIDEIT010513%20_0000/";
                                body += ds3.Tables["members"].Rows[0]["imgPath"].ToString() + "' alt='' width='130' height='100' style='border: #aaaaaa solid 1px;' /></a></li> ";
                                body += "<li><a href='" + mailLeader + "'>" + ds3.Tables["members"].Rows[0]["fName"].ToString() + " " + ds3.Tables["members"].Rows[0]["lName"].ToString() + "</a></li> ";

                                body += "</ul></div>";

                                body += "<div style='clear: right;margin: 170px auto 30px auto;width: 90%;'><hr /></div>";//divider

                                body += "<div style='clear: right;'>";

                                bool f1 = false;
                                bool f2 = false;
                                body += "<div style='float: right; text-align: right;'>";
                                if (ds.Tables[tableName].Rows[postNo]["howToGet"].ToString().Trim() != "")
                                {

                                    body += "<div style='font-size: 14px; margin: 0 0 30px 20px; font-family: Arial, Tahoma;'>";
                                    body += "<h4 style='font-size:17px;'>הסבר הגעה</h4>";
                                    body += "<div style='width: 240px;'>" + ds.Tables[tableName].Rows[postNo]["howToGet"].ToString() + "</div>";
                                    body += "</div>";

                                    f1 = true;
                                }

                                if (ds.Tables[tableName].Rows[postNo]["bring"].ToString().Trim() != "")
                                {
                                    body += "<div style='font-size: 14px;margin: 0 0 30px 20px; font-family: Arial, Tahoma;'>";
                                    body += "<h4 style='font-size:17px;'>מה להביא</h4>";
                                    body += "<div style='width: 240px;'>" + ds.Tables[tableName].Rows[postNo]["bring"].ToString() + "</div>";
                                    body += "</div>";

                                    f2 = true;
                                }
                                body += "</div>";
                                if (f1 && f2)
                                    if (ds.Tables[tableName].Rows[postNo]["bring"].ToString() != "" || ds.Tables[tableName].Rows[postNo]["howToGet"].ToString() != "")
                                        body += "<div style='float: right; background: grey;width: 1px; height:150px; margin: 30px 0 0 0'></div>";//divider

                                if (ds.Tables[tableName].Rows[postNo]["content"].ToString().Trim() != "")
                                {
                                    body += "<div style='float: right;font-size: 14px;margin: 0 20px 0 56px; font-family: Arial, Tahoma; text-align: right;'>";
                                    body += "<h4 style='font-size:17px;'>תיאור הרכיבה</h4>";
                                    body += "<div style='width: 500px;'>" + ds.Tables[tableName].Rows[postNo]["content"].ToString() + "</div>";
                                    body += "</div>";
                                }
                                body += "</div>";

                                //ביצוע שליחת האימייל
                                MailHelper reminder = new MailHelper(from, to, null, null, subject, body);
                                reminder.SendMailMessage();

                                Response.Redirect("Rides.aspx?post=" + Request.QueryString["post"]);//רענון הדף
                            }
                        }
                        else
                        {
                            string strUpdate = "UPDATE " + tableName + " SET ridersMail='" + Session["userMail"].ToString() + "', numRiders=" + (counter + 1);
                            strUpdate += " WHERE id=" + postNo;
                            db.InsertUpdateDelete(strUpdate);

                            err = "נרשמת בהצלחה לטיול זה";
                            Response.Redirect("Rides.aspx?post=" + Request.QueryString["post"]);//רענון הדף
                        }
                    }
                }
                else//אם הקלינט הוא מוביל הטיול
                {
                    str += "<a href='UpdateRide.aspx?id=" + postNo + "'><input type='button' value='עדכן טיול' style='margin: 0 0 0 10px;' /></a>";
                    str += "<a href='DeleteRide.aspx?id=" + postNo + "'><input type='button' value='מחק טיול' /></a>";
                }
            }
            else//אם הקלינט הוא אורח
            {
                str += "<input type='submit' name='joinTrip' id='joinTrip' value='הצטרף לטיול' /><div style='font-weight: bold; color: red;'>" + err + "</div>";

                if (Request.Form["joinTrip"] != null && Request.Form["joinTrip"] != "")//אם הכפתור "הצטרף לטיול" נלחץ
                {
                    Response.Redirect("Login.aspx");
                }
            }

            str += "<div style='clear: right;margin: 170px auto 30px auto;width: 90%;'><hr /></div>";//divider

            bool g1 = false;
            bool g2 = false;
            str += "<div style='float: right;'>";
            if (ds.Tables[tableName].Rows[postNo]["howToGet"].ToString().Trim() != "")
            {
                
                str += "<div style='font-size: 14px; margin: 0 0 30px 20px; font-family: Arial, Tahoma;'>";
                str += "<h4 style='font-size:17px;'>הסבר הגעה</h4><br />";
                str += "<div style='width: 240px;'>" + ds.Tables[tableName].Rows[postNo]["howToGet"].ToString() + "</div>";
                str += "</div>";

                g1 = true;
            }

            if (ds.Tables[tableName].Rows[postNo]["bring"].ToString().Trim() != "")
            {
                str += "<div style='font-size: 14px;margin: 0 0 30px 20px; font-family: Arial, Tahoma;'>";
                str += "<h4 style='font-size:17px;'>מה להביא</h4><br />";
                str += "<div style='width: 240px;'>" + ds.Tables[tableName].Rows[postNo]["bring"].ToString() + "</div>";
                str += "</div>";

                g2 = true;
            }
            str += "</div>";
            if (g1 && g2)
                if (ds.Tables[tableName].Rows[postNo]["bring"].ToString() != "" || ds.Tables[tableName].Rows[postNo]["howToGet"].ToString() != "")
                    str += "<div style='float: right; background: grey;width: 1px; height:150px; margin: 30px 0 0 0'></div>";//divider

            if (ds.Tables[tableName].Rows[postNo]["content"].ToString().Trim() != "")
            {
                str += "<div style='float: right;font-size: 14px;margin: 0 20px 0 56px; font-family: Arial, Tahoma;'>";
                str += "<h4 style='font-size:17px;'>תיאור הרכיבה</h4><br />";
                str += "<div style='width: 500px;'>" + ds.Tables[tableName].Rows[postNo]["content"].ToString() + "</div>";
                str += "</div>";
            }

            //הצגת רשימת המשתתפים
            str += "<div style='padding: 22px 0 0 0;clear:right; font-size: 14px;margin: 60px 0 0 56px; font-family: Arial, Tahoma;'>";
            str += "<h4 style='font-size:17px;'>רשימת משתתפים</h4><br />";
            str += "<div id='tableWrapper'><table class='oddEven' style='width:100%;'>";
            str += "<tr class='trFirstRow'><td> שם משתתף </td><td> איזור </td> </tr>";


            //הצגת מוביל הטיול ראשון
            str += "<tr class='odd'>";
            str += "<td style='text-align: right;'><a href='PersonInfo.aspx?mail=" + ds3.Tables["members"].Rows[0]["mail"].ToString() + "'><img src='" + ds3.Tables["members"].Rows[0]["imgPath"].ToString() + "' alt='' width='40' height='30' style='float:right; margin: 0 5px 0 9px;' /><div style='font-size: 14px; font-weight: bold;'>" + ds3.Tables["members"].Rows[0]["fName"].ToString() + " " + ds3.Tables["members"].Rows[0]["lName"].ToString() + "</div> מוביל /ה</a></td>";
            str += "<td><a href='#'><div>" + ds3.Tables["members"].Rows[0]["city"].ToString() + "</div></a></td>";
            str += "</tr>";


            string mailGroup2 = ds.Tables[tableName].Rows[postNo]["ridersMail"].ToString();
            string[] ridersMailArray2 = mailGroup2.Split(',');

            //הצגת שאר המשתמשים
            for (int i = 0; i < ridersMailArray2.Length; i++)
            {
                if (ridersMailArray2[i].Trim() != "" && ridersMailArray2[i].Trim() != null)
                {
                    string strSql4 = "SELECT imgPath,fName,lName,city,mail FROM members WHERE mail = '" + ridersMailArray2[i].Trim() + "'";
                    DataSet ds4 = db.ShowTable(strSql4, "members");

                    string trClassOddEven = "even";

                    if (i % 2 == 0)
                        trClassOddEven = "even";
                    else
                        trClassOddEven = "odd";

                    str += "<tr class='" + trClassOddEven + "'>";

                    str += "<td style='text-align: right;'><a href='PersonInfo.aspx?mail=" + ds4.Tables["members"].Rows[0]["mail"].ToString() + "'><img src='" + ds4.Tables["members"].Rows[0]["imgPath"].ToString() + "' alt='' width='40' height='30' style='float:right; margin: 0 5px 0 9px;' /><div style='font-size: 14px; font-weight: bold;'>" + ds4.Tables["members"].Rows[0]["fName"].ToString() + " " + ds4.Tables["members"].Rows[0]["lName"].ToString() + "</div></a></td>";
                    str += "<td><a href='Rides.aspx?post=" + i + "'><div>" + ds4.Tables["members"].Rows[0]["city"].ToString() + "</div></a></td>";

                    str += "</tr>";
                }
            }
            str += "</table></div></div>";
            str += "מספר המשתתפים: " + ds.Tables[tableName].Rows[postNo]["numRiders"].ToString();
            
        }
    }
}