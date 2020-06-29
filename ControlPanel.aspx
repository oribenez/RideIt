<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ControlPanel.aspx.cs" Inherits="ControlPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>פאנל ניהול - Ride it</title>

    <style type="text/css">
        .optionCP {
            margin: 0 0 0 120px;
            width: 150px;
            float: right;
            padding: 0px 0 90px 0;
        }

        h6.labelCP {
            margin: 0 25px 0 0;
        }

        #contentHolder {
            margin: 59px 92px 0 0;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" runat="Server">
    <div id="user_pnl">
        <%=sessAbnd %>
    </div>

    <h1>פאנל ניהול</h1>

    <div id="contentHolder">
        <%=protectedStr %>

    </div>
</asp:Content>
