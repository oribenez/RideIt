<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddTip.aspx.cs" Inherits="AddTip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" Runat="Server">

    <div id="user_pnl">
        <%=showMembersAdmin %>
        <%=sessAbnd %> 
    </div>
    <input type="text" name="title" id="title" /><br />
    <input type="file" name="file" id="file" /><br />
    <textarea rows="5" cols="60" name="content" id="content"></textarea><br />
    <input type="submit" name="name" value="שלח" /><%=insertValid %>
</asp:Content>

