using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Data;

public partial class AddRide : System.Web.UI.Page
{
    public string showMembersAdmin;
    public string sessAbnd;

    public string insertValid;
    public string regStatus;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"] != null)
        {
            showMembersAdmin = "<a href='ControlPanel.aspx'>פאנל ניהול</a> | ";
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";
        }
        else
        {
            Response.Redirect("adminErr.aspx");
            Response.End();
        }

        
        if (Request.Form["txtRouteName"] != "" && Request.Form["txtRouteName"] != null)
        {
            DateTime dt = DateTime.Now;

            //הכנסת נתונים
            string count = "SELECT COUNT(mail) FROM rides";
            object obj = db.ReturnObject(count);

            //קליטת הנתונים מהמשתמש
            int id = int.Parse(obj.ToString());
            string routeName = Request.Form["txtRouteName"].ToString();
            string dateCreate = dt.Day + "/" + dt.Month + "/" + dt.Year;
            int km = int.Parse(Request.Form["txtKm"].ToString());
            int maxRiders = int.Parse(Request.Form["txtMaxRiders"].ToString());
            string teq = Request.Form["selectTeq"].ToString();
            string hardness = Request.Form["selectHardness"].ToString();
            int up = int.Parse(Request.Form["txtUp"].ToString());
            int down = int.Parse(Request.Form["txtDown"].ToString());
            string startPoint = Request.Form["txtStartPoint"].ToString();
            string endPoint = Request.Form["txtEndPoint"].ToString();
            string area = Request.Form["selectArea"].ToString();

            DateTime getDay = new DateTime(int.Parse(Request.Form["selectRideDateYear"].ToString()), int.Parse(Request.Form["selectRideDateMonth"].ToString()), int.Parse(Request.Form["selectRideDateDay"].ToString()));
            string day = getDay.ToString("ddd");
            string dateRide = getDay.ToString("d");

            //שינוי שם של יום מאנגלית לעברית
            switch (day)
            {
                case "Sun":
                        day = "א";
                    break;
                case "Mon":
                        day = "ב";
                    break;
                case "Tue":
                        day = "ג";
                    break;
                case "Wed":
                        day = "ד";
                    break;
                case "Thu":
                        day = "ה";
                    break;
                case "Fri":
                        day = "ו";
                    break;
                case "Sat":
                        day = "ש";
                    break;
            }
            
            string hourStart = Request.Form["selectHourStart"].ToString() + ":" + Request.Form["selectMinStart"].ToString();
            string hourEnd = Request.Form["selectHourEnd"].ToString() + ":" + Request.Form["selectMinEnd"].ToString();

            string circleRoad = Request.Form["circleRoad"];
            if (circleRoad == "" || circleRoad == null)
                circleRoad = "לא";

            string howToGet = Request.Form["txtareaHowToGet"].ToString();
            string bring = Request.Form["txtareaBring"].ToString();
            string content = Request.Form["txtareaInfo"].ToString();

            //שאילתת הכנסת נתונים
            string strInsert = "INSERT INTO rides (`id`, `mail`, `routeName`, `dateCreate`, `km`,`maxRiders`, `teq`, `hardness`, `up`, `down`, `startPoint`, `endPoint`, `area`, `day`, `dateRide`, `rideHourStart`, `rideHourEnd`, `circleRoad`, `howToGet`, `bring`, `content`) VALUES(" + id + ",'" + Session["userMail"] + "','" + routeName + "','" + dateCreate + "'," + km + "," + maxRiders + ",'" + teq + "','" + hardness + "'," + up + "," + down + ",'" + startPoint + "','" + endPoint + "','" + area + "','" + day + "','" + dateRide + "','" + hourStart + "','" + hourEnd + "','" + circleRoad + "','" + howToGet + "','" + bring + "','" + content + "')";

            //ביצוע השאילתה
            db.InsertUpdateDelete(strInsert);

            Response.Redirect("Rides.aspx");
        }
    }
}