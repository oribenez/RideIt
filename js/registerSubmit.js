/*--בהפעלת הפונקציה כל השדות של השגיאה ינוקו--*/
function CleanAllField() {
    document.getElementById('validRegFName').innerHTML = "";
    document.getElementById('validRegLName').innerHTML = "";
    document.getElementById('validRegPass').innerHTML = "";
    document.getElementById('validRegPassConfirm').innerHTML = "";
    document.getElementById('validRegMail').innerHTML = "";
    document.getElementById('validRegAge').innerHTML = "";
    document.getElementById('validRegCity').innerHTML = "";
    document.getElementById('validRegGender').innerHTML = "";
    document.getElementById('validRegHobby').innerHTML = "";
    document.getElementById('validRegInfo').innerHTML = "";
}

/*--בעת לחיצה על כפתור שלח, הפונקציה תבדוק אם השדות נכונים ואם לא תחזיר שקר--*/
function subRegAllErr() {

    if (document.getElementById("txtRegFName").value == "") {//בדיקה אם השם ריק
        document.getElementById('validRegFName').innerHTML = "<img src='images/no.png'> מלא שם פרטי ";

        return false;
    }

    if (document.getElementById("txtRegLName").value == "") {//בדיקה אם השם ריק
        document.getElementById('validRegLName').innerHTML = "<img src='images/no.png'> מלא שם משפחה ";

        return false;
    }

    if (document.getElementById("txtRegPass").value == "") {//בדיקה אם הסיסמא ריקה
        document.getElementById('validRegPassConfirm').innerHTML = "<img src='images/no.png'> הכנס סיסמא";

        return false;
    }

    if (document.getElementById("txtRegMail").value == "") {//בדיקה אם האימייל ריק
        document.getElementById('validRegMail').innerHTML = "<img src='images/no.png'> מלא את האימייל";

        return false;
    }

    if (document.getElementById("selectBirthDateDay").selectedIndex == 0 || document.getElementById("selectBirthDateMonth").selectedIndex == 0 || document.getElementById("selectBirthDateYear").selectedIndex == 0) {
        document.getElementById('validRegBirth').innerHTML = "<img src='images/no.png'> הכנס תאריך";
        return false;
    }

    if (document.getElementById("selectRegCity").selectedIndex == 0) {
        document.getElementById('validRegCity').innerHTML = "<img src='images/no.png'> הכנס איזור";

        return false;
    }

    var g = document.getElementsByName("radioRegGender");
    if (radioBtn(g) == 0) {//בדיקה אם נבחר כפתור
        document.getElementById('validRegGender').innerHTML = "<img src='images/no.png'> בחר מגדר";

        return false;
    }

    var count = 0;
    var h = document.getElementsByName("ckBoxRegHobby");

    if (radioBtn(h) <= 1) {//בדיקה אם סומן פחות מ 2 תיבות
        document.getElementById('validRegHobby').innerHTML = "<img src='images/no.png'> בחר 2 תחביב";

        return false;
    }

    //if (document.getElementById("txtAreaRegInfo").value == "") {
    //    document.getElementById('validRegInfo').innerHTML = "<img src='images/no.png'> הכנס מידע על עצמך";

    //    return false;
    //}


    return true;
    
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

/*txtRegFname------txtRegFname------txtRegFname------txtRegFname------*/
function txtRegFNameErr() {
    document.getElementById("txtRegFName").value = CleanStr(document.getElementById("txtRegFName").value);
    var txtRegFName = document.getElementById("txtRegFName").value;
    if (txtRegFName == "") {//בדיקה אם השם ריק
        return false;
    }

    if (txtRegFName.length == 1) {//בדיקה אם השם קטן מ 2
        document.getElementById('validRegFName').innerHTML = "<img src='images/no.png'> שם פרטי חייב להיות גדול מ 1";
        return false;
    }

    if (txtRegFName.length > 10) {//בדיקה אם השם ארוך יותר מ 10
        document.getElementById('validRegFName').innerHTML = "<img src='images/no.png'> שם פרטי חייב להיות קטן מ 10";
        return false;
    }

    if (!CheckHebEng(txtRegFName)) {//בדיקה אם השם בעברית או באנגלית
        document.getElementById('validRegFName').innerHTML = "<img src='images/no.png'> שם פרטי יכול להכיל רק אותיות";
        return false;
    }

    document.getElementById('validRegFName').innerHTML = "<img src='images/yes.png'>";
}

/*txtRegLName------txtRegLName------txtRegLName------txtRegLName------*/
function txtRegLNameErr() {
    document.getElementById("txtRegLName").value = CleanStr(document.getElementById("txtRegLName").value);
    var txtRegLName = document.getElementById("txtRegLName").value;
    if (txtRegLName == "") {//בדיקה אם שם המשפחה ריק
        return false;
    }

    var txtRegLNameLength = document.getElementById("txtRegLName").value.length;
    if (txtRegLNameLength == 1) {//בדיקה אם שם המשפחה קטן מ 2
        document.getElementById('validRegLName').innerHTML = "<img src='images/no.png'> שם משפחה חייב להיות גדול מ 1";

        return false;
    }

    if (txtRegLNameLength > 10) {//בדיקה אם שם המשפחה גדול מ 10
        document.getElementById('validRegLName').innerHTML = "<img src='images/no.png'> שם משפחה חייב להיות קטן מ-10";
        return false;
    }

    if (!CheckHebEng(txtRegLName)) {// בדיקה אם השם משפחה בנוי בעברית או באנגלית בלבד
        document.getElementById('validRegLName').innerHTML = "<img src='images/no.png'> שם משפחה מכיל רק אותיות";
        return false;
    }

    if (Space(txtRegLName) > 3) {//בדיקה שאין יותר מ 3 רווחים בשם המשפחה
        document.getElementById('validRegLName').innerHTML = "<img src='images/no.png'> אסור יותר מ-3 רווחים";
        return false;
    }
                               
    
    document.getElementById('validRegLName').innerHTML = "<img src='images/yes.png'>";
}

/*txtRegPass------txtRegPass------txtRegPass------*/
function txtRegPassErr() {
    var txtRegPass = document.getElementById("txtRegPass").value;
    if (txtRegPass == "") {//בדיקה אם הסיסמא לא ריקה
        return false;
    }
    
    if (!PasswordStrength()) {//בדיקת חוזק סיסמא, אם מוחזר שקר אז הסיסמא חלשה
        document.getElementById('validRegPassConfirm').innerHTML = "<img src='images/no.png'> סיסמא חלשה מידי";
        return false;
    }
    
    if (Space(txtRegPass) >= 1) {//בדיקה שאין רווחים בכלל בסיסמא
        document.getElementById('validRegPassConfirm').innerHTML = "<img src='images/no.png'> אסור רווחים";
        return false;
    }
}

/*PassConfirm-----PassConfirm-----PassConfirm-----*/
function txtRegPassConfirmErr() {
    var txtRegPass = document.getElementById("txtRegPass").value;
    var txtRegPassConfirm = document.getElementById("txtRegPassConfirm").value;

    if (txtRegPassConfirm == "") {//בדיקה אם הסיסמא לא ריקה
        return false;
    }

    if (txtRegPassConfirm != txtRegPass) {//בדיקה שהסיסמאות שוות
        document.getElementById('validRegPassConfirm').innerHTML = "<img src='images/no.png'> הסיסמאות לא תואמות";
        return false;
    }
    document.getElementById('validRegPassConfirm').innerHTML = "";
}


/*txtRegMail-------txtRegMail-------txtRegMail-------*/
function txtRegMailErr() {
    document.getElementById("txtRegMail").value = CleanStr(document.getElementById("txtRegMail").value);
    var txtRegMail = document.getElementById("txtRegMail").value;
    if (txtRegMail == "") {//בדיקה שהאימייל לא ריק
        return false;
    }

    if (txtRegMail.indexOf("@") < 2 || txtRegMail.indexOf("@") != txtRegMail.lastIndexOf("@") ||  txtRegMail.indexOf("@") >= txtRegMail.length-2) {//בודק את מיקום ה'שטרודל' ב אימייל
        document.getElementById('validRegMail').innerHTML = "<img src='images/no.png'> אימייל לא תקין";
        return false;
    }

    if (txtRegMail.indexOf("@.") != -1 || txtRegMail.indexOf(".@") != -1) {
        document.getElementById('validRegMail').innerHTML = "<img src='images/no.png'> אסור נקודה ליד שטרודל";
        return false;
    }

    if (!EmailValid(txtRegMail)) {//בדיקה שהאימייל באנגלית, ועם תווים בלבד
        document.getElementById('validRegMail').innerHTML = "<img src='images/no.png'> מה אתה מנסה לעבוד עלי? האימייל לא תקין.";
        return false;
    }

    if (Space(txtRegMail) > 0) {//בדיקה אם יש רווחים מיותרים
        document.getElementById('validRegMail').innerHTML = "<img src='images/no.png'> אסור רווחים";
        return false;
    }

    var txtRegMailEnd = txtRegMail.substring(txtRegMail.lastIndexOf('.') + 1);
    if (txtRegMailEnd != 'com' && txtRegMailEnd != 'net' && txtRegMailEnd != 'il' && txtRegMailEnd != 'org' && txtRegMailEnd != 'gov' && txtRegMailEnd != 'biz' && txtRegMailEnd != 'info') {
        document.getElementById('validRegMail').innerHTML = "<img src='images/no.png'> סיומת לא חוקית";
        return false;
    }

    document.getElementById('validRegMail').innerHTML = "<img src='images/yes.png'>";
}

/*Age------Age------Age------Age----*/
function selectRegBirthErr() {

    var selectBirthDateDay = document.getElementById("selectBirthDateDay").selectedIndex;
    if (selectBirthDateDay == 0) {
        return false;
    }

    document.getElementById('validRegBirth').innerHTML = "";
}

/*City--------City--------City--------*/
function selectRegCityErr() {
    var selectRegCityMikum = document.getElementById("selectRegCity").selectedIndex;
    if (selectRegCityMikum == 0) {//בדיקת מיקום מגורים
        return false;
    }

    document.getElementById('validRegCity').innerHTML = "<img src='images/yes.png'>";
}

/*Gender--------Gender--------Gender--------*/
function radioRegGenderErr() {
    var g = document.getElementsByName("radioRegGender");
    if (radioBtn(g) == 0) {//בדיקה אם נבחר כפתור
        return false;
    }

    document.getElementById('validRegGender').innerHTML = "";
}

/*Hobby------Hobby------Hobby------Hobby------*/
function ckBoxRegHobbyErr() {
    var count = 0;
    var h = document.getElementsByName("ckBoxRegHobby");

    if (radioBtn(h) <= 1) {//בדיקה אם סומן פחות מ 2 תיבות
        return false;
    }

    document.getElementById('validRegHobby').innerHTML = "";
}

/*Info-------Info-------Info-------Info-------*/
function txtAreaRegInfoErr() {
    document.getElementById("txtAreaRegInfo").value = CleanStr(document.getElementById("txtAreaRegInfo").value);
    var txtAreaRegInfo = document.getElementById("txtAreaRegInfo").value;
    
    //if (txtAreaRegInfo == "") {
    //    return false;
    //}
    NumTav();

    //document.getElementById('validRegInfo').innerHTML = "<img src='images/yes.png'>";
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

/*--בדיקה כמה פעמים סומן הכפתור--*/
function radioBtn(radioCheckbox) {

    var count = 0;
    for (i = 0; i < radioCheckbox.length; i++)  // הסימון תיבות מערך על מעבר
        if (radioCheckbox[i].checked) //   מסומנת תיבה אם   
            count++;

    return count;
}

///////////////////////////////////////////////

function AllOne(str, i, n) {
    if (n == 0) {
        if (!(str.charAt(i) >= 'A' && str.charAt(i) <= 'Z')) {//אם זה באנגלית(גדולה) זה יכנס וישלח אמת
            return false;
        }
        return true;
    }
    if (n == 1) {
        if (!(str.charAt(i) >= 'a' && str.charAt(i) <= 'z')) {//אם זה באנגלית(קטנה) זה יכנס וישלח אמת
            return false;
        }
        return true;
    }
    if (n == 2) {
        if (!(str.charAt(i) >= '0' && str.charAt(i) <= '9')) {//אם זה מספר זה יכנס וישלח אמת
            return false;
        }
        return true;
    }
    if (n == 3) {
        if (!(str.charAt(i) >= 'א' && str.charAt(i) <= 'ת')) {//אם זה בעברית זה יכנס וישלח אמת
            return false;
        }
        return true;
    }
}
//////////////////////////////////////////////
/*-----בדיקה שהאימייל רק באנגלית----*/
function EmailValid(str) {
    for (i = 0; i < str.length; i++) {
        if (str.charAt(i) != '@' && str.charAt(i) != '.') {
            if (!AllOne(str, i, 0) && !AllOne(str, i, 1) && !AllOne(str, i, 2)) {
                return false;
            }
        }
    }
    return true;
}

/*---- בדיקה שהמחרוזת בעברית או באנגלית-----*/
function CheckHebEng(str) {
    for (var i = 0; i < str.length; i++) {
        if (!AllOne(str, i, 0) && !AllOne(str, i, 1) && !AllOne(str, i, 3) && str.charAt(i) != ' ') {
            return false;
        }
    }
    return true;
}

/*----בדיקה אם סיסמא חזקה----*/
function PasswordStrength() {
    var txtRegPass = document.getElementById("txtRegPass").value;
    
    var score = 0;
    var pattern = "/^!'#%&'()*,-:;?@[]\_{|}$<>";

    var flagNum = false;
    var flagSign = false;
    var flagSmall = false;
    var flagBig = false;

    for (i = 0; i < txtRegPass.length && !(flagSign && flagNum && flagSmall && flagBig); i++) {
        //בדיקה אם יש סימן אחד לפחות בתוך הסיסמא
        for (j = 0; j < pattern.length && !flagSign; j++) {
            if (txtRegPass.charAt(i) == pattern.charAt(j))
                flagSign = true;
        }

        //בדיקה אם יש לפחות מספר אחד
        for (var j = 0; j <= 9 && !flagNum; j++) {
            if (txtRegPass.charAt(i) == j)
                flagNum = true;
        }
        
        //בדיקה שיש אות קטנה באנגלית (אחת לפחות)1
        if (txtRegPass.charAt(i) >= 'a' && txtRegPass.charAt(i) <= 'z')
            flagSmall = true;

        //בדיקה שיש אות גדולה באנגלית (אחת לפחות)1
        if (txtRegPass.charAt(i) >= 'A' && txtRegPass.charAt(i) <= 'Z')
            flagBig = true;
    }

    if (txtRegPass.length != 0) {
        score++;
    }
    if (txtRegPass.length > 4)
        score++;

    if(txtRegPass.length > 9)
        score++

    if (flagSign)
        score+=2;

    if (flagNum)
        score+=2;

    if (flagSmall)
        score++;

    if (flagBig)
        score+=2;

    if (txtRegPass.length > 5 && txtRegPass.length < 9 && flagSign && (flagNum || flagSmall || flagBig)) {
        document.getElementById('validRegPass').innerHTML = "<div style='color: green; font-weight: bold;'> חזקה </div>";
    }
    else if (txtRegPass.length >= 9 && flagSign && (flagNum || flagSmall || flagBig)) {
        document.getElementById('validRegPass').innerHTML = "<div style='color: purple; font-weight: bold;'> חזקה מאוד </div>";
    }
    else if (!isNaN(txtRegPass) && txtRegPass.length > 7) {
        document.getElementById('validRegPass').innerHTML = "<div style='color: green; font-weight: bold;'> חזקה </div>";
    }
    else {
        if (score == 0)
            document.getElementById('validRegPass').innerHTML = "";

        if (score <= 5 && score >= 1) {
            document.getElementById('validRegPass').innerHTML = "<div style='color: red; font-weight: bold;'> חלשה </div>";
            return false;
        }

        if (score == 6) {
            document.getElementById('validRegPass').innerHTML = "<div style='color: orange; font-weight: bold;'> בינונית</div>";
        }

        if (score >= 7 && score <= 8) {
            document.getElementById('validRegPass').innerHTML = "<div style='color: green; font-weight: bold;'> חזקה </div>";
        }

        if (score >= 9 && score <= 10) {
            document.getElementById('validRegPass').innerHTML = "<div style='color: aqua; font-weight: bold;'> חזקה מאוד </div>";
        }
    }
    return true;
}

/*-----פונקציה שבודקת את מספר התווים ב txtAreaRegInfo------*/
function NumTav() {
    var txtAreaRegInfo = document.getElementById("txtAreaRegInfo").value;
    var limitNum = 125;

    if (txtAreaRegInfo.length > limitNum) {
        txtAreaRegInfo = txtAreaRegInfo.substring(0, limitNum);
        document.getElementById("txtAreaRegInfo").value = txtAreaRegInfo;
    }
    else {
        var hisov = limitNum - txtAreaRegInfo.length;
        document.getElementById('tav').innerHTML = "תווים: " + hisov;
    }
}

/*--פונקציה שסופרת את מספר הרווחים--*/
function Space(str){
    var counter = 0;

    for (var i = 0; i < str.length; i++)
        if (str.charAt(i) == ' ')
            counter++;

    return counter;
}

/*--פונקציה שמוחקת לי את כל הרווחים בתחילת ובסוף משפט--*/
function CleanStr(str) {

    while (str.substring(0, 1) == ' ') //מוחק את הרווחים בתחילת המחרוזת
    {
        str = str.substring(1, str.length);
    }

    while (str.substring(str.length - 1, str.length) == ' ') //מוחק את הרווחים בסוף המחרוזת
    {
        str = str.substring(0, str.length - 1);
    }

    return str;
}