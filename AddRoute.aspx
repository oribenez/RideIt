<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddRoute.aspx.cs" Inherits="AddRoute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" runat="Server">
    <div id="user_pnl">
        <%=showMembersAdmin %>
        <%=sessAbnd %>
    </div>
    <table width="80%" style="line-height: 27px;" >
        <tr>
            <td>כותרת</td>
            <td>
                <input type="text" name="title" id="title" /></td>
        </tr>
        <tr>
            <td>מרחק</td>
            <td>
                <input type="text" name="txtKm" id="txtKm" /></td>
        </tr>
        <tr>
            <td>זמן</td>
            <td>
                <input type="text" name="txtTime" id="txtTime" /></td>
        </tr>
        <tr>
            <td>קושי</td>
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
            <td>איזור</td>
            <td>
                <select id="selectArea" name="selectArea">
                    <option>בחר איזור</option>
                    <option value="צפון">צפון</option>
                    <option value="חיפה">חיפה</option>
                    <option value="השרון">השרון</option>
                    <option value="תל אביב">תל אביב</option>
                    <option value="מרכז">מרכז</option>
                    <option value="ירושלים">ירושלים</option>
                    <option value="דרום">דרום</option>
                </select>

            </td>
        </tr>
        <tr>
            <td>תמונה</td>
            <td>
                <input type="file" name="file" id="file" /></td>
        </tr>
        <tr>
            <td>תוכן</td>
            <td>
                <textarea rows="5" cols="60" name="content" id="content"></textarea></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <input type="submit" name="name" value="שלח" /><%=insertValid %></td>
        </tr>
    </table>


</asp:Content>

