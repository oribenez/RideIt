

/*מה שרשום בתוך התיבת טקסט*/
var mailStr = "אימייל";
var passStr = "סיסמא";

var mail = document.getElementById("mail");
var pass = document.getElementById("pass");

//function loginText() {
//    
//    mail.value = mailStr;

//    pass.type = 'text';
//    pass.value = passStr;
//}

function loginEmpty(str) {
    if (str.id == "txtLoginMail") {
        if (str.value == mailStr) {
            str.value = "";
        }
    }
    
    if (str.id == "txtLoginPass") {
        if (str.value == passStr) {
            str.value = "";
            str.type = "password"
        }
    }
}

function loginBack(str) {
    if (str.value == "") {
        if (str.id == "txtLoginMail") {
            str.value = mailStr;
        }
        else if (str.id == "txtLoginPass") {
            str.value = passStr;
            str.type = "text"
        }
    }

}

/*#########################*/


function Valid() {
    var mail = document.getElementById("txtLoginMail").value;
    var pass = document.getElementById("txtLoginPass").value;

    if (mail == "אימייל") {
        document.getElementById("error_mail").innerHTML = "<img src='images/no.png'>הכנס אימייל";
        return false;
    }
    document.getElementById("error_mail").innerHTML = "";

    if (pass == "סיסמא") {
        document.getElementById("error_pass").innerHTML = "<img src='images/no.png'>הכנס סיסמא";
        return false;
    }
    document.getElementById("error_pass").innerHTML = "";
    return true;
}