<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Statistics.aspx.cs" Inherits="Statistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" Runat="Server">
    <div id="user_pnl">
        <div style="float: left;">
            <%=controlPanel %>
            <%=sessAbnd %>
        </div>
    </div>
    <%=str%>
    
</asp:Content>

