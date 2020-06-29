<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TicTacToe.aspx.cs" Inherits="TicTacToe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/game.js"></script>

    <script type="text/javascript">
        //משתנים גלובליים
        var o = "images/o.png";//מקום התמונה של O
        var x = "images/x.png";//מיקום התמונה של X
        var blank = "images/blank.jpg";//מיקום התמונה הריקה
        var numChoices = 0;//מספר הבחירות
        var winner = '';
        var reset = false;

        var humenArr = new Array(9);
        for (var i = 0; i < humenArr.length; i++) {
            humenArr[i] = false;
        }

        var computerArr = new Array(9);
        for (var i = 0; i < computer.length; i++) {
            computerArr[i] = false;
        }

        var win = false;//אם מישהו זכה

        /*תהליך כללי*/
        function Process(place) {
            

                HumenChoice(place);
                if (numChoices >= 3)
                    Victory('h');


                if (!reset) {
                    ComputerChoice();
                    if (numChoices >= 3)
                        Victory('c');

                }
                else
                    reset = false;
        }

        /*בחירה של האיש*/
        function HumenChoice(place) {
            var choice = document.getElementById(place);

            if (choice.src.
                Of(blank) != -1) {//אם הבחירה שווה לריק
                numChoices++;
                Choices(place, 'h');
                choice.src = x;//השמת הבחירה של האיש
                choice.style.cursor = 'default';
            }
            else {//אם המקום שנבחר תפוס
                alert("אינך יכול להציב במקום זה... בחר שוב");
            }
        }

        /*בחירה של המחשב*/
        function ComputerChoice() {
            var pattern = "ABCDEFGHI";

            var rnd = Math.floor(Math.random() * 9);
            var place = pattern.charAt(rnd);
            var choice = document.getElementById(place);

            while (choice.src.lastIndexOf(blank) == -1 && numChoices != 5) {
                rnd = Math.floor(Math.random() * 9);
                place = pattern.charAt(rnd);
                choice = document.getElementById(place);
            }
            Choices(place, 'c');
            choice.src = o;//השמת הבחירה של האיש
            choice.style.cursor = 'default';//שינוי תצוגת עכבר ל ברירת המחדל
        }
        // C B A
        // F E D
        // I H G

        // 2 1 0
        // 5 4 3
        // 8 7 6

        // 0 = A
        // 1 = B
        // 2 = C
        // 3 = D
        // 4 = E
        // 5 = F
        // 6 = G
        // 7 = H
        // 8 = I

        /*בדיקה אם מישהו ניצח*/
        function Victory(who) {
            if (who == 'h') {//אם האיש ניצח
                if (humenArr[0] && humenArr[1] && humenArr[2]) {//שורה עליונה
                    win = true;
                    alert("שורה עליונה");
                }
                else if (humenArr[3] && humenArr[4] && humenArr[5]) {//שורה אמצעית
                    win = true;
                    alert("שורה אמצעית");
                }
                else if (humenArr[6] && humenArr[7] && humenArr[8]) {//שורה תחתונה
                    win = true;
                    alert("שורה תחתונה");
                }
                else if (humenArr[0] && humenArr[3] && humenArr[6]) {//טור ימני
                    win = true;
                    alert("טור ימני");
                }
                else if (humenArr[1] && humenArr[4] && humenArr[7]) {//טור אמצעי
                    win = true;
                    alert("טור אמצעי");
                }
                else if (humenArr[2] && humenArr[5] && humenArr[8]) {//טור שמאלי
                    win = true;
                    alert("טור שמאלי");
                }
                else if (humenArr[2] && humenArr[4] && humenArr[6]) {//אלכסון ראשי
                    win = true;
                    alert("אלכסון ראשי");
                }
                else if (humenArr[0] && humenArr[4] && humenArr[8]) {//אלכסון משני
                    win = true;
                    alert("אלכסון משני");
                }
            }
            else {//אם המחשב ניצח
                if (computerArr[0] && computerArr[1] && computerArr[2]) {//שורה עליונה
                    win = true;
                    alert("שורה עליונה");
                }
                else if (computerArr[3] && computerArr[4] && computerArr[5]) {//שורה אמצעית
                    win = true;
                    alert("שורה אמצעית");
                }
                else if (computerArr[6] && computerArr[7] && computerArr[8]) {//שורה תחתונה
                    win = true;
                    alert("שורה תחתונה");
                }
                else if (computerArr[0] && computerArr[3] && computerArr[6]) {//טור ימני
                    win = true;
                    alert("טור ימני");
                }
                else if (computerArr[1] && computerArr[4] && computerArr[7]) {//טור אמצעי
                    win = true;
                    alert("טור אמצעי");
                }
                else if (computerArr[2] && computerArr[5] && computerArr[8]) {//טור שמאלי
                    win = true;
                    alert("טור שמאלי");
                }
                else if (computerArr[2] && computerArr[4] && computerArr[6]) {//אלכסון ראשי
                    win = true;
                    alert("אלכסון ראשי");
                }
                else if (computerArr[0] && computerArr[4] && computerArr[8]) {//אלכסון משני
                    win = true;
                    alert("אלכסון משני");
                }
            }

            if (win) {
                Winner(who);
            }
        }

        /*המנצח*/
        function Winner(who) {
            if (who == 'h') {
                alert("הידד, ניצחת אותי");
                document.getElementById("humen").value++;
                
            }
            else if (who == 'c') {
                alert("ניצחתי אותך יאפסס..");
                document.getElementById("computer").value++;
            }
            else {
                alert("זה תיקו, אל תדאג משחק הבא אני מפרק אותך");
                document.getElementById("ties").value++;
            }
            Reset(who);
        }

        /*מיקומים שנבחרו*/
        function Choices(place, who) {
            if (who == 'h') {
                if (place == 'A') humenArr[0] = true;
                else if (place == 'B') humenArr[1] = true;
                else if (place == 'C') humenArr[2] = true;
                else if (place == 'D') humenArr[3] = true;
                else if (place == 'E') humenArr[4] = true;
                else if (place == 'F') humenArr[5] = true;
                else if (place == 'G') humenArr[6] = true;
                else if (place == 'H') humenArr[7] = true;
                else if (place == 'I') humenArr[8] = true;
            }
            else {
                if (place == 'A') computerArr[0] = true;
                else if (place == 'B') computerArr[1] = true;
                else if (place == 'C') computerArr[2] = true;
                else if (place == 'D') computerArr[3] = true;
                else if (place == 'E') computerArr[4] = true;
                else if (place == 'F') computerArr[5] = true;
                else if (place == 'G') computerArr[6] = true;
                else if (place == 'H') computerArr[7] = true;
                else if (place == 'I') computerArr[8] = true;
            }
        }

        /*אתחול המשחק*/
        function Reset(who) {
            document.getElementById("A").src = blank;
            document.getElementById("B").src = blank;
            document.getElementById("C").src = blank;
            document.getElementById("D").src = blank;
            document.getElementById("E").src = blank;
            document.getElementById("F").src = blank;
            document.getElementById("G").src = blank;
            document.getElementById("H").src = blank;
            document.getElementById("I").src = blank;

            numChoices = 0;//מספר הבחירות
            alert(humenArr.length);
            for (var i = 0; i < humenArr.length; i++) {

                humenArr[i] = false;
            }
            alert(computerArr.length);
            for (var i = 0; i < computer.length; i++) {
                computerArr[i] = false;
            }

            //שינוי תצוגת עכבר ל ברירת המחדל
            document.getElementById("A").style.cursor = 'pointer';
            document.getElementById("B").style.cursor = 'pointer';
            document.getElementById("C").style.cursor = 'pointer';
            document.getElementById("D").style.cursor = 'pointer';
            document.getElementById("E").style.cursor = 'pointer';
            document.getElementById("F").style.cursor = 'pointer';
            document.getElementById("G").style.cursor = 'pointer';
            document.getElementById("H").style.cursor = 'pointer';
            document.getElementById("I").style.cursor = 'pointer';
            if (who == 'h')
            reset = true;
            win = false;
            winner = who;
            who = '';
        }

        function Help() {
            alert("אתה משחק את ה-X והמחשב הוא O .\nבחר את הריבוע בו אתה רוצה שיהיה ה-X.\nאתה לא יכול לשים את ה-X בריבוע שתפוס כבר.\nהמנצח הוא השחקן הראשון שסימן שלושה ריבועים בשורה/טור/אלכסון.\n")
        }

    </script>

    <%--<script type="text/javascript">
        var x = "o.png";
        var o = "x.png";
        var blank = "blank.jpg";

        var a = 0;
        var b = 0;
        var c = 0;
        var d = 0;
        var e = 0;
        var f = 0;
        var g = 0;
        var h = 0;
        var i = 0;



        var pause = 0;
        var all = 0;
        var a = 0;
        var b = 0;
        var c = 0;
        var d = 0;
        var e = 0;
        var f = 0;
        var g = 0;
        var h = 0;
        var i = 0;
        var temp = "";
        var ok = 0;
        var cf = 0;
        var choice = 9;
        var aRandomNumber = 0;
        var comp = 0;
        var t = 0;
        var wn = 0;
        var ls = 0;
        var ts = 0;
        function logicOne() {
            if ((a == 1) && (b == 1) && (c == 1)) all = 1;
            if ((a == 1) && (d == 1) && (g == 1)) all = 1;
            if ((a == 1) && (e == 1) && (i == 1)) all = 1;
            if ((b == 1) && (e == 1) && (h == 1)) all = 1;
            if ((d == 1) && (e == 1) && (f == 1)) all = 1;
            if ((g == 1) && (h == 1) && (i == 1)) all = 1;
            if ((c == 1) && (f == 1) && (i == 1)) all = 1;
            if ((g == 1) && (e == 1) && (c == 1)) all = 1;
            if ((a == 2) && (b == 2) && (c == 2)) all = 2;
            if ((a == 2) && (d == 2) && (g == 2)) all = 2;
            if ((a == 2) && (e == 2) && (i == 2)) all = 2;
            if ((b == 2) && (e == 2) && (h == 2)) all = 2;
            if ((d == 2) && (e == 2) && (f == 2)) all = 2;
            if ((g == 2) && (h == 2) && (i == 2)) all = 2;
            if ((c == 2) && (f == 2) && (i == 2)) all = 2;
            if ((g == 2) && (e == 2) && (c == 2)) all = 2;
            if ((a != 0) && (b != 0) && (c != 0) && (d != 0) && (e != 0) && (f != 0) && (g != 0) && (h != 0) && (i != 0) && (all == 0)) all = 3;
        }
        function logicTwo() {
            if ((a == 2) && (b == 2) && (c == 0) && (temp == "")) temp = "C";
            if ((a == 2) && (b == 0) && (c == 2) && (temp == "")) temp = "B";
            if ((a == 0) && (b == 2) && (c == 2) && (temp == "")) temp = "A";
            if ((a == 2) && (d == 2) && (g == 0) && (temp == "")) temp = "G";
            if ((a == 2) && (d == 0) && (g == 2) && (temp == "")) temp = "D";
            if ((a == 0) && (d == 2) && (g == 2) && (temp == "")) temp = "A";
            if ((a == 2) && (e == 2) && (i == 0) && (temp == "")) temp = "I";
            if ((a == 2) && (e == 0) && (i == 2) && (temp == "")) temp = "E";
            if ((a == 0) && (e == 2) && (i == 2) && (temp == "")) temp = "A";
            if ((b == 2) && (e == 2) && (h == 0) && (temp == "")) temp = "H";
            if ((b == 2) && (e == 0) && (h == 2) && (temp == "")) temp = "E";
            if ((b == 0) && (e == 2) && (h == 2) && (temp == "")) temp = "B";
            if ((d == 2) && (e == 2) && (f == 0) && (temp == "")) temp = "F";
            if ((d == 2) && (e == 0) && (f == 2) && (temp == "")) temp = "E";
            if ((d == 0) && (e == 2) && (f == 2) && (temp == "")) temp = "D";
            if ((g == 2) && (h == 2) && (i == 0) && (temp == "")) temp = "I";
            if ((g == 2) && (h == 0) && (i == 2) && (temp == "")) temp = "H";
            if ((g == 0) && (h == 2) && (i == 2) && (temp == "")) temp = "G";
            if ((c == 2) && (f == 2) && (i == 0) && (temp == "")) temp = "I";
            if ((c == 2) && (f == 0) && (i == 2) && (temp == "")) temp = "F";
            if ((c == 0) && (f == 2) && (i == 2) && (temp == "")) temp = "C";
            if ((g == 2) && (e == 2) && (c == 0) && (temp == "")) temp = "C";
            if ((g == 2) && (e == 0) && (c == 2) && (temp == "")) temp = "E";
            if ((g == 0) && (e == 2) && (c == 2) && (temp == "")) temp = "G";
        }
        function logicThree() {
            if ((a == 1) && (b == 1) && (c == 0) && (temp == "")) temp = "C";
            if ((a == 1) && (b == 0) && (c == 1) && (temp == "")) temp = "B";
            if ((a == 0) && (b == 1) && (c == 1) && (temp == "")) temp = "A";
            if ((a == 1) && (d == 1) && (g == 0) && (temp == "")) temp = "G";
            if ((a == 1) && (d == 0) && (g == 1) && (temp == "")) temp = "D";
            if ((a == 0) && (d == 1) && (g == 1) && (temp == "")) temp = "A";
            if ((a == 1) && (e == 1) && (i == 0) && (temp == "")) temp = "I";
            if ((a == 1) && (e == 0) && (i == 1) && (temp == "")) temp = "E";
            if ((a == 0) && (e == 1) && (i == 1) && (temp == "")) temp = "A";
            if ((b == 1) && (e == 1) && (h == 0) && (temp == "")) temp = "H";
            if ((b == 1) && (e == 0) && (h == 1) && (temp == "")) temp = "E";
            if ((b == 0) && (e == 1) && (h == 1) && (temp == "")) temp = "B";
            if ((d == 1) && (e == 1) && (f == 0) && (temp == "")) temp = "F";
            if ((d == 1) && (e == 0) && (f == 1) && (temp == "")) temp = "E";
            if ((d == 0) && (e == 1) && (f == 1) && (temp == "")) temp = "D";
            if ((g == 1) && (h == 1) && (i == 0) && (temp == "")) temp = "I";
            if ((g == 1) && (h == 0) && (i == 1) && (temp == "")) temp = "H";
            if ((g == 0) && (h == 1) && (i == 1) && (temp == "")) temp = "G";
            if ((c == 1) && (f == 1) && (i == 0) && (temp == "")) temp = "I";
            if ((c == 1) && (f == 0) && (i == 1) && (temp == "")) temp = "F";
            if ((c == 0) && (f == 1) && (i == 1) && (temp == "")) temp = "C";
            if ((g == 1) && (e == 1) && (c == 0) && (temp == "")) temp = "C";
            if ((g == 1) && (e == 0) && (c == 1) && (temp == "")) temp = "E";
            if ((g == 0) && (e == 1) && (c == 1) && (temp == "")) temp = "G";
        }
        function clearOut() {
            document.game.you.value = "0";
            document.game.computer.value = "0";
            document.game.ties.value = "0";
        }
        function checkSpace() {
            if ((temp == "A") && (a == 0)) {
                ok = 1;
                if (cf == 0) a = 1;
                if (cf == 1) a = 2;
            }
            if ((temp == "B") && (b == 0)) {
                ok = 1;
                if (cf == 0) b = 1;
                if (cf == 1) b = 2;
            }
            if ((temp == "C") && (c == 0)) {
                ok = 1;
                if (cf == 0) c = 1;
                if (cf == 1) c = 2;
            }
            if ((temp == "D") && (d == 0)) {
                ok = 1;
                if (cf == 0) d = 1;
                if (cf == 1) d = 2;
            }
            if ((temp == "E") && (e == 0)) {
                ok = 1;
                if (cf == 0) e = 1;
                if (cf == 1) e = 2;
            }
            if ((temp == "F") && (f == 0)) {
                ok = 1
                if (cf == 0) f = 1;
                if (cf == 1) f = 2;
            }
            if ((temp == "G") && (g == 0)) {
                ok = 1
                if (cf == 0) g = 1;
                if (cf == 1) g = 2;
            }
            if ((temp == "H") && (h == 0)) {
                ok = 1;
                if (cf == 0) h = 1;
                if (cf == 1) h = 2;
            }
            if ((temp == "I") && (i == 0)) {
                ok = 1;
                if (cf == 0) i = 1;
                if (cf == 1) i = 2;
            }
        }
        function yourChoice(chName) {
            pause = 0;
            if (all != 0) ended();
            if (all == 0) {
                cf = 0;
                ok = 0;
                temp = chName;
                checkSpace();
                if (ok == 1) {
                    document.images[chName].src = x;
                }
                if (ok == 0) taken();
                process();
                if ((all == 0) && (pause == 0)) myChoice();
            }
        }
        function taken() {
            alert("This cell in not empty! Try another")
            pause = 1;
        }
        function myChoice() {
            temp = "";
            ok = 0;
            cf = 1;
            logicTwo();
            logicThree();
            checkSpace();
            while (ok == 0) {
                aRandomNumber = Math.random()
                comp = Math.round((choice - 1) * aRandomNumber) + 1;
                if (comp == 1) temp = "A";
                if (comp == 2) temp = "B";
                if (comp == 3) temp = "C";
                if (comp == 4) temp = "D";
                if (comp == 5) temp = "E";
                if (comp == 6) temp = "F";
                if (comp == 7) temp = "G";
                if (comp == 8) temp = "H";
                if (comp == 9) temp = "I";
                checkSpace();
            }
            document.images[temp].src = o;
            process();
        }
        function ended() {
            alert("Game over! To play once more press a button 'New Game'")
        }
        function process() {
            logicOne();
            if (all == 1) { alert("You win!"); wn++; }
            if (all == 2) { alert("You lose!"); ls++; }
            if (all == 3) { alert("Draw!"); ts++; }
            if (all != 0) {
                document.game.you.value = wn;
                document.game.computer.value = ls;
                document.game.ties.value = ts;
            }
        }
        function playAgain() {
            if (all == 0) {
                if (confirm("Âû óâåðåíû ?")) reset();
            }
            if (all > 0) reset();
        }
        function reset() {
            all = 0;
            a = 0;
            b = 0;
            c = 0;
            d = 0;
            e = 0;
            f = 0;
            g = 0;
            h = 0;
            i = 0;
            temp = "";
            ok = 0;
            cf = 0;
            choice = 9;
            aRandomNumber = 0;
            comp = 0;
            document.images.A.src = blank;
            document.images.B.src = blank;
            document.images.C.src = blank;
            document.images.D.src = blank;
            document.images.E.src = blank;
            document.images.F.src = blank;
            document.images.G.src = blank;
            document.images.H.src = blank;
            document.images.I.src = blank;
            if (t == 0) { t = 2; myChoice(); }
            t--;
        }
        var ie4 = (document.all) ? true : false;
        var nn4 = (document.layers) ? true : false;
</script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SectionContentPlaceHolder" runat="Server">
    <form name="game" id="game">
        <table border="1" style="background: white; border-collapse: collapse;">
            <tr>
                <td>
                    <img src="images/blank.jpg" border="0" height="100" width="100" id="A" alt="Top-Right" onclick="Process('A');" style="cursor: pointer;" /></td>
                <td>
                    <img src="images/blank.jpg" border="0" height="100" width="100" id="B" alt="Top-Center" onclick="Process('B');" style="cursor: pointer;" /></td>
                <td>
                    <img src="images/blank.jpg" border="0" height="100" width="100" id="C" alt="Top-Left" onclick="Process('C');" style="cursor: pointer;" /></td>
            </tr>
            <tr>
                <td>
                    <img src="images/blank.jpg" border="0" height="100" width="100" id="D" alt="Middle-Right" onclick="Process('D');" style="cursor: pointer;" /></td>
                <td>
                    <img src="images/blank.jpg" border="0" height="100" width="100" id="E" alt="Middle-Center" onclick="Process('E');" style="cursor: pointer;" /></td>
                <td>
                    <img src="images/blank.jpg" border="0" height="100" width="100" id="F" alt="Middle-Left" onclick="Process('F');" style="cursor: pointer;" /></td>
            </tr>
            <tr>
                <td>
                    <img src="images/blank.jpg" border="0" height="100" width="100" id="G" alt="Bottom-Right" onclick="Process('G');" style="cursor: pointer;" /></td>
                <td>
                    <img src="images/blank.jpg" border="0" height="100" width="100" id="H" alt="Bottom-Center" onclick="Process('H');" style="cursor: pointer;" /></td>
                <td>
                    <img src="images/blank.jpg" border="0" height="100" width="100" id="I" alt="Bottom-Left" onclick="Process('I');" style="cursor: pointer;" /></td>
            </tr>
        </table>

        <table>
            <tr>
                <td>אני</td>
                <td>
                    <input type="text" size="5" id="humen" value="0" /></td>
            </tr>
            <tr>
                <td>המחשב</td>
                <td>
                    <input type="text" size="5" id="computer" value="0" /></td>
            </tr>
            <tr>
                <td>תיקו</td>
                <td>
                    <input type="text" size="5" id="ties" value="0" /></td>
            </tr>
        </table>

        <input type="button" value="Play Again" onclick="PlayAgain();" />
        &nbsp;&nbsp;
        <input type="button" value="Game Help" onclick="Help();" />

    </form>


</asp:Content>

