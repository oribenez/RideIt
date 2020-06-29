<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rides.aspx.cs" Inherits="Rides" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/RidesS.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" Runat="Server">
    <div id="user_pnl">
        <div style="float: left;">
            <%=controlPanel %>
            <%=connGuest %>
            <%=sessAbnd %>
        </div>
        
        <div style="float: right;">
            <%=hello %>
        </div>
    </div>
    <br />
    <%=str %>
</asp:Content>

