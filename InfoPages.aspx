<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InfoPages.aspx.cs" Inherits="InfoPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        ul li a {
            color: rgb(29, 147, 177);
        }
        ul li a:hover {
            color: rgb(29, 147, 177);
            text-decoration: underline;
        }
        ul {
            line-height:27px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" Runat="Server">

    <h1>מידע נוסף</h1>
    <ul>
        <li><a href="BenGurion.aspx">בן גוריון</a></li>
        <li><a href="MenahemBegin.aspx">מנחם בגין</a></li>

    </ul>

</asp:Content>

