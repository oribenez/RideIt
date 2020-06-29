<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddRide.aspx.cs" Inherits="AddRide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" runat="Server">

    <h1>הוספת רכיבה</h1>
    <table  style="line-height: 24px; float:right;">
        <tr>
            <td>שם הרכיבה</td>
            <td>
                <input type="text" name="txtRouteName" id="txtRouteName" /></td>
        </tr>
        <tr>
            <td>מרחק בק"מ</td>
            <td>
                <input type="text" name="txtKm" id="txtKm" /></td>
        </tr>
        <tr>
            <td>מקסימום רוכבים</td>
            <td>
                <input type="text" name="txtMaxRiders" id="txtMaxRiders" /></td>
        </tr>
        <tr>
            <td>אופי</td>
            <td>
                <select id="selectTeq" name="selectTeq">
                    <option>בחר אופי רכיבה</option>
                    <option value="XC">XC </option>
                    <option value="DH/FR">DH/FR </option>
                    <option value="DJ">DJ </option>
                    <option value="אימון שטח">אימון שטח </option>
                    <option value="כביש">רכיבת כביש </option>
                    <option value="אימון כביש">אימון כביש </option>
                    <option value="מפגש חברתי">מפגש חברתי </option>
                </select>
            </td>
        </tr>
        <tr>
            <td>רמת קושי</td>
            <td>
                <select id="selectHardness" name="selectHardness">
                    <option>רמת קושי</option>
                    <option value="קל">קל</option>
                    <option value="קל - בינוני">קל - בינוני</option>
                    <option value="בינוני">בינוני</option>
                    <option value="בינוני - קשה">בינוני - קשה</option>
                    <option value="קשה">קשה</option>
                    <option value="קשה - קשה מאוד">קשה - קשה מאוד</option>
                    <option value="קשה מאוד">קשה מאוד</option>
                </select>

            </td>
        </tr>
        <tr>
            <td>עליות מצטברות</td>
            <td>
                <input type="text" name="txtUp" id="txtUp" /></td>
        </tr>
        <tr>
            <td>ירידות מצטברות</td>
            <td>
                <input type="text" name="txtDown" id="txtDown" /></td>
        </tr>

        <tr>
            <td>נקודת התחלה</td>
            <td>
                <input type="text" name="txtStartPoint" id="txtStartPoint" /></td>
        </tr>
        <tr>
            <td>נקודת סיום</td>
            <td>
                <input type="text" name="txtEndPoint" id="txtEndPoint" /></td>
        </tr>
        <tr>
            <td>איזור</td>
            <td>
                <select id="selectArea" name="selectArea">
                    <option>בחר איזור</option>
                    <option value="צפון">צפון </option>
                    <option value="מרכז">מרכז </option>
                    <option value="דרום">דרום </option>
                </select>
            </td>
        </tr>
        <tr>
            <td>תאריך הרכיבה</td>
            <td>
                <%
                    string str = "";
                    DateTime dt1 = DateTime.Now;

                    //יום
                    str += "יום: <select id='selectRideDateDay' name='selectRideDateDay'>";
                    str += "<option>יום</option>";
                    for (int i = 1; i <= 31; i++)
                    {
                        if (i < 10)
                        {
                            i = int.Parse(0 + i.ToString());
                        }

                        string choose = "";
                        if (dt1.Day == i)
                        {
                            choose = "selected";
                        }

                        str += "<option value='" + i + "' " + choose + ">" + i + "</option>";
                    }
                    str += "</select>&nbsp;&nbsp;";

                    //חודש
                    str += "חודש: <select id='selectRideDateMonth' name='selectRideDateMonth'>";
                    str += "<option>חודש</option>";
                    for (int i = 1; i <= 12; i++)
                    {
                        if (i < 10)
                        {
                            i = int.Parse(0 + i.ToString());
                        }

                        string choose = "";
                        if (dt1.Month == i)
                        {
                            choose = "selected";
                        }

                        str += "<option value='" + i + "' " + choose + ">" + i + "</option>";
                    }
                    str += "</select>&nbsp;&nbsp;";

                    //שנה
                    str += "שנה: <select id='selectRideDateYear' name='selectRideDateYear'>";
                    str += "<option>שנה</option>";
                    for (int i = dt1.Year; i <= dt1.Year + 10; i++)
                    {
                        string choose = "";
                        if (dt1.Year == i)
                        {
                            choose = "selected";
                        }

                        str += "<option value='" + i + "' " + choose + ">" + i + "</option>";
                    }
                    str += "</select>";

                    Response.Write(str);
                %></td>
        </tr>
        <tr>
            <td>מתחיל ב..</td>
            <td>
                <%
                    str = "";

                    //דקה
                    str += "<select id='selectMinStart' name='selectMinStart'>";
                    str += "<option>דקה</option>";

                    for (int i = 0; i <= 59; i++)
                    {
                        str += "<option value='" + i + "'>" + i + "</option>";
                    }
                    str += "</select>&nbsp;<b>:</b>&nbsp;";

                    //שעה
                    str += "<select id='selectHourStart' name='selectHourStart'>";
                    str += "<option>שעה</option>";

                    for (int i = 0; i <= 23; i++)
                    {
                        str += "<option value='" + i + "'>" + i + "</option>";
                    }
                    str += "</select>&nbsp;&nbsp;";

                    Response.Write(str);
                %>
            </td>
        </tr>
        <tr>
            <td>מסתיים ב..</td>
            <td>
                <%
                    str = "";

                    //דקה
                    str += "<select id='selectMinEnd' name='selectMinEnd'>";
                    str += "<option>דקה</option>";

                    for (int i = 0; i <= 59; i++)
                    {
                        str += "<option value='" + i + "'>" + i + "</option>";
                    }
                    str += "</select>&nbsp;<b>:</b>&nbsp;";

                    //שעה
                    str += "<select id='selectHourEnd' name='selectHourEnd'>";
                    str += "<option>שעה</option>";

                    for (int i = 0; i <= 23; i++)
                    {
                        str += "<option value='" + i + "'>" + i + "</option>";
                    }
                    str += "</select>&nbsp;&nbsp;";

                    Response.Write(str);
                %>
            </td>
        </tr>
        <tr>
            <td>מסלול מעגלי</td>
            <td>
                <input type="checkbox" name="circleRoad" id="circleRoad" value="כן" /></td>
        </tr>
    </table>

    <div style='float: right; background: lightgrey;width: 1px; height:570px; margin: 0 10px 0 10px;'></div>

    <table style="line-height: 24px; float:right;">
        <tr>
            <td>הסבר הגעה</td>
            <td>
                <textarea rows="11" cols="20" name="txtareaHowToGet" id="txtareaHowToGet"></textarea></td>
        </tr>
        <tr>
            <td>מה להביא</td>
            <td>
                <textarea rows="11" cols="20" name="txtareaBring" id="txtareaBring"></textarea></td>
        </tr>
        <tr>
            <td>תיאור הרכיבה</td>
            <td>
                <textarea rows="5" cols="30" name="txtareaInfo" id="txtareaInfo"></textarea></td>
        </tr>

        <tr>
            <td>&nbsp;</td>
            <td>
                <input type="submit" name="name" value="שלח" /><%=insertValid %></td>
        </tr>
    </table>

</asp:Content>

