<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RndNumGame.aspx.cs" Inherits="RndNumGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/RndNumGame.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" runat="Server">
    <form name="fGame">
        
        <input type="button" name="start" value="      התחל משחק     " onclick="NewGame()" /><br />
        <input type="text" name="output" size="70" readonly="readonly" /><br />
        הכנס מספר
        <input type="text" name="inputNum" size="20" />
        <input type="button" name="doIt" value=" נחש מספר  " onclick="Game(fGame.inputNum.value);" /><br />

        <input type="text" name="highLow" size="20" readonly="readonly" /><br />
        <br />

        מספר ניחושים
        <input type="text" name="tries" value="0" size="1" readonly="readonly" /><br />
        
    </form>

    <img src id="goodJob" alt="" width="200" style="margin: 0 300px 0 0" />
</asp:Content>

