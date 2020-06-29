<%@ Page Title="רשימת מנויים - Ride it" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowMembers.aspx.cs" Inherits="ShowMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/searchEngine.js"></script>
    <script type="text/javascript" src="js/confirm.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" runat="Server">
    <div id="user_pnl">
        <%=controlPanel %>
        <%=sessAbnd %>
    </div>

    <h1>רשימת מנויים</h1>

    <div id="searchWrap">
        <input type="button" id="btnShow" value="חיפוש" name="btnShow" onclick="showSearch('show')" style="margin: 0 0 7px 0;" />
        <div id="hiddenContainer">
            <label for="search" id="lblSearch">
                <br />
                חיפוש
            </label>
            <%
                Response.Write(" <input type='text' id='search' name='search' value='"+ Session["serValue"].ToString() + "' runat='server' />");
                 %>
            
            <input type='submit' name='find' id='find' value='חפש' />
            <br />
            <table>
                <tr>
                    <td>
                        <%
                            string str1 = "";
                            string[] arr = null;
                            if (IsPostBack)
                            {
                                if (Session["ckTypeAutoFill"] != "" && Session["ckTypeAutoFill"] != null)
                                {
                                    arr = Session["ckTypeAutoFill"].ToString().Split(',');
                                }
                                string fNameCK = "";
                                int counter11 = 0;
                                if (counter11 < arr.Length && arr[counter11] == "fName")
                                {
                                    fNameCK = "checked";
                                    counter11++;
                                }
                                str1 += "<input type='checkbox' name='ckType' id='fName' value='fName' onclick='disableSelect(1)' " + fNameCK + " /><label for='fName' id='lblFName'>שם פרטי</label>&nbsp;&nbsp;";
                                str1 += "</td>";

                                
                                str1 += "<td>";
                                string lNameCK = "";

                                if (counter11 < arr.Length && arr[counter11] == "lName")
                                {
                                    lNameCK = "checked";
                                    counter11++;
                                }
                                str1 += "<input type='checkbox' name='ckType' id='lName' value='lName' onclick='disableSelect(2)' " + lNameCK + " /><label for='lName' id='lblLName'>שם משפחה</label>&nbsp;&nbsp;";
                                str1 += "</td>";

                                
                                str1 += "<td>";
                                string mailCK = "";
                                if (counter11 < arr.Length && arr[counter11] == "mail")
                                {
                                    mailCK = "checked";
                                }
                                str1 += "<input type='checkbox' name='ckType' id='mail' value='mail' onclick='disableSelect(3)' " + mailCK + " /><label for='mail' id='lblMail'>אימייל</label></td>";

                                
                                str1 += "<td>";
                                string cityCK = "";
                                if (counter11 < arr.Length && arr[counter11] == "mail")
                                {
                                    cityCK = "checked";
                                }
                                str1 += "<input type='checkbox' name='ckType' id='city' value='city' onclick='disableSelect(4)' " + cityCK + " /><label for='city' id='lblCity'>איזור</label>";
                            }
                            else
                            {
                                str1 += "<input type='checkbox' name='ckType' id='fName' value='fName' onclick='disableSelect(1)' checked /><label for='fName' id='lblFName'>שם פרטי</label>&nbsp;&nbsp;";
                                str1 += "</td>";

                                str1 += "<td>";
                                str1 += "<input type='checkbox' name='ckType' id='lName' value='lName' onclick='disableSelect(2)' checked /><label for='lName' id='lblLName'>שם משפחה</label>&nbsp;&nbsp;";
                                str1 += "</td>";

                                str1 += "<td>";
                                str1 += "<input type='checkbox' name='ckType' id='mail' value='mail' onclick='disableSelect(3)' checked /><label for='mail' id='lblMail'>אימייל</label>&nbsp;&nbsp;";
                                str1 += "</td>";

                                str1 += "<td>";
                                str1 += "<input type='checkbox' name='ckType' id='city' value='city' onclick='disableSelect(4)' checked /><label for='city' id='lblCity'>איזור</label>";
                            }
                            Response.Write(str1);
                             %>
                        </td>
                </tr>

                <tr>
                    <td>
                        <select name="fNameSelect" id="fNameSelect">
                            <option value="ללא">מכיל</option>
                            <option value="מתחיל">מתחיל ב..</option>
                            <option value="מסתיים">מסתיים ב..</option>
                        </select>
                    </td>
                    <td>
                        <select name="lNameSelect" id="lNameSelect">
                            <option value="ללא">מכיל</option>
                            <option value="מתחיל">מתחיל ב..</option>
                            <option value="מסתיים">מסתיים ב..</option>
                        </select>
                    </td>
                    <td>
                        <select name="mailSelect" id="mailSelect">
                            <option value="ללא">מכיל</option>
                            <option value="מתחיל">מתחיל ב..</option>
                            <option value="מסתיים">מסתיים ב..</option>
                        </select>
                    </td>
                    <td>
                        <select name="citySelect" id="citySelect">
                            <option value="ללא">מכיל</option>
                            <option value="מתחיל">מתחיל ב..</option>
                            <option value="מסתיים">מסתיים ב..</option>
                        </select>
                    </td>
                </tr>

            </table>

            <input type='button' name='close' id='close' onclick='showSearch("hide")' value='אפס חיפוש' style="margin: 5px 0 0 0;" />

        </div>
        <%=hideSer %>
    </div>

    <%=str %>
</asp:Content>
