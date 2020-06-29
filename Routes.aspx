<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Routes.aspx.cs" Inherits="Routes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" Runat="Server">

    <div id="user_pnl">
        <%=showMembersAdmin %>
        <%=sessAbnd %>
        <%=connGuest %>
    </div>

    
    <%=contentTips %>

</asp:Content>

