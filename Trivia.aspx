<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Trivia.aspx.cs" Inherits="Trivia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <title>טריוויה</title>

    <script src="game.js" type="text/javascript"></script>
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" Runat="Server">
    <div id="quest"></div>
    <form id="gameForm">

        <input type="button" value="התחל משחק" id="btnStartGame" onclick="Start()" />

        <input type="hidden" name="ans" id="ans1" class="radioAns" value="ans1" onclick="Answers()" />
        <%--תשובה א--%>
        <br />
        <input type="hidden" name="ans" id="ans2" class="radioAns" value="ans2" onclick="Answers()" />
        <%--תשובה ב--%>
        <br />
        <input type="hidden" name="ans" id="ans3" class="radioAns" value="ans3" onclick="Answers()" />
        <%--תשובה ג--%>
        <br />
        <input type="hidden" name="ans" id="ans4" class="radioAns" value="ans4" onclick="Answers()" />
        <%--תשובה ד--%>
    </form>

    <div id="goodBad"></div>

</asp:Content>