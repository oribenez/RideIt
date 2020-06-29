<%@ Page Title="מחיקת מנוי - Ride it" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Delete.aspx.cs" Inherits="Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" runat="Server">
    <div id="user_pnl">
    </div>

        <table style="background: #fff; border: solid 1px #ddd;">
            <tr>
                <td><u>שם פרטי </u></td>
                <td><u>שם משפחה </u></td>
                <td><u>אימייל </u></td>
            </tr>

            <tr>
                <td>
                    <input type="text" id="txtDelFName" readonly="readonly" runat="server" />
                </td>
                <td>
                    <input type="text" id="txtDelLName" readonly="readonly" runat="server" />
                </td>
                <td>
                    <input type="text" id="txtDelMail" readonly="readonly" runat="server" />
                </td>
            </tr>

        </table>

        <input type="submit" value="מחק" />
        <input type="button" value="בטל" onclick="location = 'ShowMembers.aspx';" />

</asp:Content>