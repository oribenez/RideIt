using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Routes : System.Web.UI.Page
{
    public string hello;
    public string showMembersAdmin;
    public string connGuest;
    public string sessAbnd;

    public string contentTips = "";
    static bool continueRead;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"] == null)//אם הקליינט הוא אורח
        {
            connGuest = "<a href='Login.aspx'>התחברות</a> | <a href='Register.aspx'>הרשמה</a>";
        }
        else
        {
            showMembersAdmin = "<a href='ControlPanel.aspx'>פאנל ניהול</a> | ";
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";
        }

        string XMLfile = Server.MapPath("XML/XMLroutes.xml");  //מיקום קובץ הטיפים
        XmlDocument doc = new XmlDocument();  //יצירת אובייקט לטעינת המסמך
        doc.Load(XMLfile);  //טעינת המסמך

        XmlNodeList img = doc.GetElementsByTagName("img");  //רשימת התמונות
        XmlNodeList title = doc.GetElementsByTagName("title");  //רשימת הכותרות
        XmlNodeList date = doc.GetElementsByTagName("date");  //רשימת התאריכים
        XmlNodeList km = doc.GetElementsByTagName("km");
        XmlNodeList time = doc.GetElementsByTagName("time");
        XmlNodeList hardness = doc.GetElementsByTagName("hardness");
        XmlNodeList area = doc.GetElementsByTagName("area");
        XmlNodeList content = doc.GetElementsByTagName("content");  //רשימת התכנים

        if (Request.QueryString["post"] == null && Request.QueryString["page"] != null)
        {
            contentTips += "<h1>מסלולים</h1>";

            int objNumber = 4;
            int numPost = content.Count + 1;
            int page = (int.Parse(Request.QueryString["page"].ToString()) - 1) * objNumber;//מספר אובייקטים
            int objNumber1 = objNumber;

            int numPage = content.Count / objNumber;
            if (content.Count % objNumber != 0)
            {
                numPage++;
            }

            if (content.Count % objNumber != 0 && int.Parse(Request.QueryString["page"].ToString()) == numPage)
            {
                objNumber1 = content.Count % objNumber;
            }
            for (int i = page; i < page + objNumber1; i++)
            {
                numPost--;
                string lessContent = MaxLengthContent(content[i].InnerText);
                
                contentTips += "<div class='tips_block'>";
                contentTips += "<div class='decoration'></div>";
                contentTips += "<div class='content'>";
                contentTips += "<h4>" + title[i].InnerText + "</h4>";
                contentTips += "<div class='tipDate'>" + date[i].InnerText + "</div>";
                contentTips += "<div class='tips_divider'></div>";
                contentTips += "<div class='tips_main_content'>";
                contentTips += "<div class='tips_pic'>";
                contentTips += "<img src='images/tips_img/" + img[i].InnerText + "' width='170' height='130' alt='' />";
                contentTips += "</div>";
                contentTips += "<div class='tips_text'>";
                contentTips += "<img src='images/km.png' width='26' height='26' style='margin: 5px 22px 0 0; float: right;' /><div style='margin: 8px 6px 0px 0px;float: right;font-size: 19px;'> " + km[i].InnerText + " ק'מ </div> ";
                contentTips += "<img src='images/time.png' width='24' height='24' style='margin: 5px 22px 0 0; float: right;' /><div style='margin: 8px 6px 0px 0px;float: right;font-size: 19px;'> " + time[i].InnerText + "</div>";
                //contentTips += "<img src='images/area.png' width='24' height='24' style='margin: 5px 18px 0 0; float: right;' /><div style='margin: 8px 6px 0px 0px;float: right;font-size: 19px;'> איזור " + area[i].InnerText + "</div>";

                string color = "";
                if (hardness[i].InnerText == "קל" || hardness[i].InnerText == "קל - בינוני") color = "easy";
                else if (hardness[i].InnerText == "בינוני" || hardness[i].InnerText == "בינוני - קשה") color = "medium";
                else if (hardness[i].InnerText == "קשה" || hardness[i].InnerText == "קשה - קשה מאוד") color = "hard";
                else if (hardness[i].InnerText == "קשה מאוד") color = "veryHard";

                contentTips += "<img src='images/" + color + ".png' width='26' height='26' style='margin: 5px 22px 0 0; float: right;' /><div style='margin: 8px 6px 0px 0px;float: right;font-size: 19px;'> " + hardness[i].InnerText + "</div> <br /><br />";
                contentTips += lessContent.Trim();
                contentTips += "</div></div></div>";
                if (continueRead)
                    contentTips += "<div class='tips_continue'><a href='Routes.aspx?post=" + numPost + "' style='color: #67bf8a;'>המשך...</a></div>";
                contentTips += "</div>";

            }

            contentTips += "<div style='margin: 0 465px 0 0; font-size: 22px;'>";
            for (int i = numPage; i >= 1; i--)
            {
                contentTips += "<a href='Routes.aspx?page=" + i + "'>" + i + "</a>&nbsp;&nbsp;";
            }
            contentTips += "</div>";
        }
        else if (Request.QueryString["post"] == null && Request.QueryString["page"] == null)
        {
            Response.Redirect("Routes.aspx?page=1");
        }
        else
        {
            int post = content.Count - int.Parse(Request.QueryString["post"].ToString());

            contentTips += "<h1>" + title[post].InnerText + "</h1>";
            contentTips += "<div class='tips_text'>" + content[post].InnerText + "</div>";

        }
    }

    public string MaxLengthContent(string content)
    {
        continueRead = false;
        int maxTav = 210;
        if (content.Length > maxTav)
        {
            string lessContent = content.Substring(0, maxTav);
            lessContent += "...";
            continueRead = true;
            return lessContent;
        }
        return content;
    }
}