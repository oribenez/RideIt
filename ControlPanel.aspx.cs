using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPanel : System.Web.UI.Page
{
    public string sessAbnd;
    public string protectedStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["isAdmin"] == null)
        {
            Response.Redirect("adminErr.aspx");
            Response.End();
        }
        else if (Session["isAdmin"] == "1")//הרשאת מנהל בלבד
        {
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";

            //רשימת מנויים
            protectedStr += "<div class='optionCP'>";
            protectedStr += "<a href='ShowMembers.aspx'>";
            protectedStr += "<img src='images/show_members.png' alt='' border='0' height='128' width='128' /></a>";
            protectedStr += "<h6 class='labelCP'>רשימת מנויים </h6>";
            protectedStr += "</div>";

            //פרטים אישיים
            protectedStr += "<div class='optionCP'>";
            protectedStr += "<a href='PersonInfo.aspx?mail=" + Session["userMail"] + "'>";
            protectedStr += "<img src='images/personal_info.png' alt='' border='0' height='128' width='128' /></a>";
            protectedStr += "<h6 class='labelCP'>פרטים אישיים </h6>";
            protectedStr += "</div>";

            //עדכון נתונים אישיים
            protectedStr += "<div class='optionCP' style='margin: 0;'>";
            protectedStr += "<a href='Update.aspx?mail=" + Session["userMail"] + "'>";
            protectedStr += "<img src='images/update.png' alt='' border='0' height='128' width='128' /></a>";
            protectedStr += "<h6 class='labelCP'>עדכון נתונים </h6>";
            protectedStr += "</div>";

            //הוספת טיפים
            protectedStr += "<div class='optionCP'>";
            protectedStr += "<a href='AddTip.aspx'>";
            protectedStr += "<img src='images/AddTip.png' alt='' border='0' height='128' width='128' /></a>";
            protectedStr += "<h6 class='labelCP'>הוספת טיפים </h6>";
            protectedStr += "</div>";

            //הוספת מסלול
            protectedStr += "<div class='optionCP'>";
            protectedStr += "<a href='AddRoute.aspx'>";
            protectedStr += "<img src='images/route.png' alt='' border='0' height='128' width='128' /></a>";
            protectedStr += "<h6 class='labelCP'>הוספת מסלול </h6>";
            protectedStr += "</div>";

            //הוספת רכיבה
            protectedStr += "<div class='optionCP'>";
            protectedStr += "<a href='AddRide.aspx'>";
            protectedStr += "<img src='images/addRide.png' alt='' border='0' height='128' width='128' /></a>";
            protectedStr += "<h6 class='labelCP'>הוספת רכיבה </h6>";
            protectedStr += "</div>";

            //סטטיסטיקה
            protectedStr += "<div class='optionCP'>";
            protectedStr += "<a href='Statistics.aspx'>";
            protectedStr += "<img src='images/statistics.png' alt='' border='0' height='128' width='128' /></a>";
            protectedStr += "<h6 class='labelCP'>סטטיסטיקה </h6>";
            protectedStr += "</div>";
        }
        else if (Session["isAdmin"] == "0")//הרשאת משתמש
        {
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";

            //פרטים אישיים
            protectedStr += "<div class='optionCP'>";
            protectedStr += "<a href='PersonInfo.aspx?mail=" + Session["userMail"] + "'>";
            protectedStr += "<img src='images/personal_info.png' alt='' border='0' height='128' width='128' /></a>";
            protectedStr += "<h6 class='labelCP'>פרטים אישיים </h6>";
            protectedStr += "</div>";

            //עדכון נתונים אישיים
            protectedStr += "<div class='optionCP'>";
            protectedStr += "<a href='Update.aspx?mail=" + Session["userMail"] + "'>";
            protectedStr += "<img src='images/update.png' alt='' border='0' height='128' width='128' /></a>";
            protectedStr += "<h6 class='labelCP'>עדכון נתונים </h6>";
            protectedStr += "</div>";

            //הוספת רכיבה
            protectedStr += "<div class='optionCP' style='margin: 0;'>";
            protectedStr += "<a href='AddRide.aspx'>";
            protectedStr += "<img src='images/addRide.png' alt='' border='0' height='128' width='128' /></a>";
            protectedStr += "<h6 class='labelCP'>הוספת רכיבה </h6>";
            protectedStr += "</div>";
        }
    }
}