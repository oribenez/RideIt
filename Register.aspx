<%@ Page Title="הרשמה - Ride it" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/registerSubmit.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" runat="Server">
    <div id="user_pnl">

        <div style="text-align:left;">
            <%=controlPanel%>
            <%=sessAbnd %>
        </div>
        
    </div>

    <h2>אז למה בעצם להירשם?</h2>
    <h3>כשאתם רשומים לאתר יש לכם יותר גישות. 
                <br />
        אתם תוכלו לקבוע רכיבה עם אנשים שאינכם מכירים ובכך להכיר חברים חדשים.
                <br />
        תוכלו גם לקבל שלום יפה בכניסה לאתר.
                <br />
        כבר נרשמת? <a href="Login.aspx">התחבר</a>
    </h3>

    <h1>הרשמה </h1>

        <table id="tablet" border="0">

            <tr>
                <td>שם פרטי </td>

                <td>
                    <input type="text" id="txtRegFName" name="txtRegFName" onblur="txtRegFNameErr()" size="20" />
                </td>

                <td>
                    <div id="validRegFName" style="margin: 0 -100px 0 0"></div>
                </td>
            </tr>

            <tr>
                <td>שם משפחה </td>

                <td>
                    <input type="text" id="txtRegLName" name="txtRegLName" onblur="txtRegLNameErr()" size="20" />
                </td>

                <td>
                    <div id="validRegLName" style="margin: 0 -100px 0 0"></div>
                </td>
            </tr>

            <tr>
                <td>סיסמא </td>

                <td>
                    <input type="password" id="txtRegPass" name="txtRegPass" onblur="txtRegPassErr()" onkeypress="PasswordStrength()" onkeydown="PasswordStrength()" onkeyup="PasswordStrength()" size="20" />
                </td>

                <td>
                    <div id="validRegPass" style="margin: 0 -100px 0 0"></div>
                </td>
            </tr>

            <tr>
                <td>אימות סיסמא </td>

                <td>
                    <input type="password" id="txtRegPassConfirm" name="txtRegPassConfirm" onblur="txtRegPassConfirmErr()" size="20" />
                </td>

                <td>
                    <div id="validRegPassConfirm" style="margin: 0 -100px 0 0"></div>
                </td>

            </tr>

            <tr>
                <td>אימייל </td>

                <td>
                    <input type="text" id="txtRegMail" name="txtRegMail" onblur="txtRegMailErr()" size="20" />
                </td>

                <td>
                    <div id="validRegMail" style="margin: 0 -100px 0 0"><%=regStatus %></div>
                </td>
            </tr>

            <tr>
                <td>תאריך לידה </td>

                <td>
                    <%
                    string str = "";
                    DateTime dt1 = DateTime.Now;

                    //יום
                    str += "<select id='selectBirthDateDay' name='selectBirthDateDay' onblur='selectRegBirthErr()'>";
                    str += "<option>יום</option>";
                    for (int i = 1; i <= 31; i++)
                    {
                        if (i < 10)
                        {
                            i = int.Parse(0 + i.ToString());
                        }

                        str += "<option value='" + i + "'>" + i + "</option>";
                    }
                    str += "</select>&nbsp;&nbsp;";

                    //חודש
                    str += "<select id='selectBirthDateMonth' name='selectBirthDateMonth' onblur='selectRegBirthErr()'>";
                    str += "<option>חודש</option>";
                    for (int i = 1; i <= 12; i++)
                    {
                        if (i < 10)
                        {
                            i = int.Parse(0 + i.ToString());
                        }
                        str += "<option value='" + i + "'>" + i + "</option>";
                    }
                    str += "</select>&nbsp;&nbsp;";

                    //שנה
                    str += "<select id='selectBirthDateYear' name='selectBirthDateYear' onblur='selectRegBirthErr()'>";
                    str += "<option>שנה</option>";
                    for (int i = dt1.Year; i >= dt1.Year - 85; i--)
                    {
                        str += "<option value='" + i + "'>" + i + "</option>";
                    }
                    str += "</select>";

                    Response.Write(str);
                %>
                </td>

                <td>
                    <div id="validRegBirth" style="margin: 0 -63px 0 0"></div>
                </td>
            </tr>

            <tr>
                <td>איזור </td>

                <td>
                    <select id="selectRegCity" name="selectRegCity" onblur="selectRegCityErr()">
                        <option>בחר איזור</option>
                        <option value="צפון">צפון </option>
                        <option value="מרכז">מרכז </option>
                        <option value="דרום">דרום </option>
                    </select>
                </td>

                <td>
                    <div id="validRegCity" style="margin: 0 -100px 0 0"></div>
                </td>
            </tr>

            <tr>
                <td>מין</td>
                <td>
                    <input type="radio" id="g1" name="radioRegGender" value="גבר" onclick="radioRegGenderErr()" />
                    &nbsp; זכר
                            <input type="radio" id="g2" name="radioRegGender" value="אישה" onclick="radioRegGenderErr()" />
                    &nbsp; נקבה
                </td>

                <td>
                    <div id="validRegGender" style="margin: 0 -100px 0 0"></div>
                </td>
            </tr>

            <tr>
                <td>תחביבים </td>
                <td>
                    <input type="checkbox" name="ckBoxRegHobby" id="h1" value="מחשב" onclick="ckBoxRegHobbyErr()" />
                    מחשב&nbsp;
                            <input type="checkbox" name="ckBoxRegHobby" id="h2" value="אופניים" onclick="ckBoxRegHobbyErr()" />
                    אופניים&nbsp;
                            <input type="checkbox" name="ckBoxRegHobby" id="h3" value="כדורסל" onclick="ckBoxRegHobbyErr()" />
                    כדורסל
                </td>
                <td>
                    <div id="validRegHobby" style="margin: 0px 6px 0 0"></div>
                </td>
            </tr>

            <tr>
                <td>מידע </td>

                <td>
                    <textarea name="txtAreaRegInfo" id="txtAreaRegInfo" cols="30" rows="4" onblur="txtAreaRegInfoErr()" onkeyup="NumTav()" onkeydown="NumTav()" onkeypress="NumTav()"></textarea></td>
                <td>
                    <div id="validRegInfo" style="margin: 57px 6px 0 0"></div>
                </td>
            </tr>

            <tr></tr>

            <tr>
                <td></td>
                <td>
                    <input type="submit" value="הירשם" id="subReg" onclick="return subRegAllErr()" />
                    &nbsp;&nbsp;
                            <input type="reset" value="נקה" onclick="CleanAllField()" />
                    <div id="tav" style="float: left; font-size: 12px;">תווים: 125</div>
                </td>
            </tr>

        </table>

    <img src="images/bicycle_ride.png" id="img_bicycleRide" alt="" />

</asp:Content>
