<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PersonInfo.aspx.cs" Inherits="PersonInfo" %>

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

