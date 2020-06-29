<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ReloadImg() {
            var rnd = Math.floor(Math.random() * 3) + 1;
            document.getElementById("random_img").src = "images/rld_img/img" + rnd + ".jpg";
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" runat="Server">
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

    <img width="960" height="510" id="random_img" src="images/rld_img/img3.jpg" alt="" />

    <script type="text/javascript">
        ReloadImg();
    </script>
    
    <div id="article">
        
        <h1><a href="AboutUs.aspx" style="color: #565045;font-size: 30px;font-weight: normal;margin: 5px 0 15px 0;">קצת עלינו</a></h1>
        
        <p><a href="AboutUs.aspx" style="color: #aea586;font-size: 17px;font-weight: normal;line-height: 26px;margin: 0;">
            חברה להדרכות טיולים, פעילויות שטח עממיות והדרכות על אופניים- קבוצת אופניים מקצועית אשר פועלת פועלת בכל הארץ ובמיוחד באזור מודיעין במרכז הארץ והעמקים בצפון הארץ. אך נותנת שירותים ארציים הפרושים בכל הארץ. ושמה לה למטרה ליצור תשתית לרכיבת אופניים מקצוענית ועממית וכן לקדם פיתוח תרבות רכיבה בארץ.
סגל החברה מורכב מסגל מדריכי הקבוצה, מדריכים מנוסים ומוסמכים ע"י מנהל הספורט כמו גם אנשי שטח 
</a>
        </p>
        <div id="divider"></div>

        <div class="block">

            <h1>רכיבות</h1>
            <p style="font-size: 12px; line-height: 20px;">
                חברה להדרכות טיולים, פעילויות שטח עממיות והדרכות על אופניים- קבוצת אופניים מקצועית אשר פועלת פועלת בכל הארץ ובמיוחד באזור מודיעין במרכז הארץ והעמקים בצפון הארץ. אך נותנת שירותים ארציים הפרושים בכל
            </p>
            <br />
            <img src="images/block_rides_pic.png" alt="" />
        </div>

        <div class="block">

            <h1>מסלולים</h1>
            <p style="font-size: 12px; line-height: 20px;">
                חברה להדרכות טיולים, פעילויות שטח עממיות והדרכות על אופניים- קבוצת אופניים מקצועית אשר פועלת פועלת בכל הארץ ובמיוחד באזור מודיעין במרכז הארץ והעמקים בצפון הארץ. אך נותנת שירותים ארציים הפרושים בכל
            </p>
            <br />
            <img src="images/block_roads_pic.png" alt="" />
        </div>

        <div class="block">

            <h1>טיפים</h1>
            <p style="font-size: 12px; line-height: 20px;">
                חברה להדרכות טיולים, פעילויות שטח עממיות והדרכות על אופניים- קבוצת אופניים מקצועית אשר פועלת פועלת בכל הארץ ובמיוחד באזור מודיעין במרכז הארץ והעמקים בצפון הארץ. אך נותנת שירותים ארציים הפרושים בכל
            </p>
            <br />
            <img src="images/block_tips_pic.png" alt="" />
        </div>

    </div>
</asp:Content>
