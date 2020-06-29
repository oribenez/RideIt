<%@ Page Title="RIDE IT - עדכון נתונים" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/registerSubmit.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" runat="Server">
    
    <div id="user_pnl">
        <%=controlPanel %>
        <%=sessAbnd %>
    </div>
    
    <h1>עדכון נתונים</h1>

    <%

            str += "<table id='tablet'>";

            //שם פרטי
            str += "<tr>";
            str += "<td>שם פרטי </td>";
            str += "<td><input type='text' id='txtUpFName' name='txtUpFName' value='" + fNameTemp + "' runat='server' /></td>";
            str += "</tr>";

            //שם משפחה
            str += "<tr>";
            str += "<td>שם משפחה </td>";
            str += "<td><input type='text' id='txtUpLName' name='txtUpLName' value='" + lNameTemp + "' runat='server' /></td>";
            str += "</tr>";

            //סיסמא
            str += "<tr>";
            str += "<td>סיסמא </td>";
            str += "<td><input type='password' id='txtUpPass' name='txtUpPass' value='" + passTemp + "' runat='server' /></td>";
            str += "</tr>";

            //אימייל
            str += "<tr>";
            str += "<td>אימייל </td>";
            str += "<td><input type='text' id='txtUpMail' name='txtUpMail' value='" + mailTemp + "' runat='server' /></td>";
            str += "</tr>";

            //גיל
            str += "<tr>";
            str += "<td>תאריך לידה </td>";
            str += "<td>";

                DateTime dt1 = DateTime.Now;

                string strDate = "SELECT age FROM members WHERE mail='" + mailTemp + "'";
                ds = db.ShowTable(strDate, "members");

                string[] date = ds.Tables["members"].Rows[0]["age"].ToString().Split('/');
                
                //שנה
                str += "<select id='selectBirthDateYear' name='selectBirthDateYear' onblur='selectRegBirthErr()'>";
                str += "<option>שנה</option>";
                for (int i = dt1.Year; i >= dt1.Year - 85; i--)
                {
                    string selectedDate = "";
                    if (date[2] == i.ToString())
                        selectedDate = "selected";
                    
                    str += "<option value='" + i + "' " + selectedDate + " >" + i + "</option>";
                }
                str += "</select>&nbsp;&nbsp;";

                //חודש
                str += "<select id='selectBirthDateMonth' name='selectBirthDateMonth' onblur='selectRegBirthErr()'>";
                str += "<option>חודש</option>";
                for (int i = 1; i <= 12; i++)
                {
                    string val = i.ToString();
                    if (i < 10)
                    {
                        val = 0 + i.ToString();
                    }

                    string selectedDate = "";
                    if (date[1] == i.ToString())
                        selectedDate = "selected";
                    
                    
                    str += "<option value='" + val + "' " + selectedDate + " >" + val + "</option>";
                }
                str += "</select>&nbsp;&nbsp;";
                
                //יום
                str += "<select id='selectBirthDateDay' name='selectBirthDateDay' onblur='selectRegBirthErr()'>";
                str += "<option>יום</option>";
                for (int i = 1; i <= 31; i++)
                {
                    string val = i.ToString();
                    if (i < 10)
                    {
                        val = 0 + i.ToString();
                    }

                    string selectedDate = "";
                    if (date[0] == i.ToString())
                        selectedDate = "selected";
                    
                    
                    str += "<option value='" + val + "' " + selectedDate + " >" + val + "</option>";
                }
                str += "</select>";

            str += "</td>";
            str += "<td>";
            str += "<div id='validRegBirth' style='margin: 0 -63px 0 0'></div>";
            str += "</td>";
            str += "</tr>";
            
            
            //איזור
            str += "<tr>";
            str += "<td>איזור </td>";
            str += "<td>";
            str += "<select id='selectUpCity' name='selectUpCity' runat='server'>";
            str += "<option>בחר איזור</option>";

            string selectM = "";
            string selectN = "";
            string selectS = "";
            if (cityTemp == "מרכז")
            {
                selectM = "selected";
            }

            else if (cityTemp == "צפון")
            {
                selectN = "selected";
            }

            else if (cityTemp == "דרום")
            {
                selectS = "selected";
            }

            str += "<option value='צפון' " + selectN + ">צפון</option>";
            str += "<option value='מרכז' " + selectM + ">מרכז </option>";
            str += "<option value='דרום' " + selectS + ">דרום </option>";
            str += "</select>";
            str += "</td>";
            str += "</tr>";

            ////מגדר
            //str += "<tr>";
            //str += "<td>מגדר</td>";
            //str += "<td>";
            //if (genderTemp == "גבר")//אם הוא גבר
            //{
            //    str += "<input type='radio' id='g1' name='radioUpGender' value='גבר' runat='server' checked />&nbsp; זכר";
            //    str += "<input type='radio' id='g2' name='radioUpGender' value='אישה' runat='server' />&nbsp; נקבה";
            //}
            //else
            //{
            //    str += "<input type='radio' id='g1' name='radioUpGender' value='גבר' runat='server' />&nbsp; זכר";
            //    str += "<input type='radio' id='g2' name='radioUpGender' value='אישה' runat='server' checked />&nbsp; נקבה";
            //}

            //str += "</td>";
            //str += "</tr>";

            //תחביבים
            str += "<tr>";
            str += "<td>תחביבים </td>";
            str += "<td>";

            string[] hobbies = hobbyTemp.Split(',');
            string chkComp = "";
            string chkBike = "";
            string chkBasketball = "";

            for (int i = 0; i < hobbies.Length; i++)
            {
                if (hobbies[i] == "מחשב")
                {
                    chkComp = "checked";
                }
                else if (hobbies[i] == "אופניים")
                {
                    chkBike = "checked";
                }
                else if (hobbies[i] == "כדורסל")
                {
                    chkBasketball = "checked";
                }
            }

            str += "<input type='checkbox' name='ckBoxUpHobby' id='h1' value='מחשב' runat='server'" + chkComp + " />מחשב&nbsp;";
            str += "<input type='checkbox' name='ckBoxUpHobby' id='h2' value='אופניים' runat='server'" + chkBike + " />אופניים&nbsp;";
            str += "<input type='checkbox' name='ckBoxUpHobby' id='h3' value='כדורסל' runat='server'" + chkBasketball + " />כדורסל";

            str += "</td>";
            str += "</tr>";

            //מידע
            str += "<tr>";
            str += "<td>מידע </td>";
            str += "<td><textarea name='txtAreaUpInfo' id='txtAreaUpInfo' cols='30' rows='4' runat='server'>" + infoTemp + "</textarea></td>";
            str += "</tr>";

            //גישה רק למנהלים
            if (Session["isAdmin"] == "1")
            {
                //מנהל?
                str += "<tr>";
                str += "<td><b>מנהל? </b></td>";

                if (isAdminTemp == "1")
                    str += "<td><input type='checkbox' name='ckBoxUpManager' id='ckBoxUpManager1' value='1' runat='server' checked /></td>";
                else
                    str += "<td><input type='checkbox' name='ckBoxUpManager' id='ckBoxUpManager1' value='1' runat='server' /></td>";
                str += "</tr>";
            }

            //שליחת הנתונים
            str += "<tr>";
            str += "<td></td>";
            str += "<td>";
            str += "<input type='submit' id='upSubmit' value='עדכן' />&nbsp;&nbsp;";
            str += "<a href='ControlPanel.aspx'><input type='button' onclick='location.href(\"ControlPanel.aspx\")' value='בטל' /></a>&nbsp;&nbsp;";
            str += "<div id='validUpSub' style='position: absolute; margin: -30px 103px 0 0;'>" + regStatus + "</div>";
            str += "</td>";
            str += "</tr>";

            str += "</table>";

            Response.Write(str);
            
        if (Session["isAdmin"] == null)
        {
            Response.Redirect("adminErr.aspx");
            Response.End();
        }
        %>


</asp:Content>
