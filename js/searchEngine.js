function showSearch(strVisible) {
    if (strVisible == "show") {
        document.getElementById("hiddenContainer").style.display = "block";
        document.getElementById("btnShow").type = "hidden";
    }
    else {
        location.href = "ShowMembers.aspx";
    }
}


function disableSelect(num) {
    if (num == 1) {
        if (document.getElementById("fName").checked) {
            document.getElementById("fNameSelect").disabled = false;
        }
        else {
            document.getElementById("fNameSelect").disabled = true;
        }
    }
    else if (num == 2)
    {
        if (document.getElementById("lName").checked) {
            document.getElementById("lNameSelect").disabled = false;
        }
        else {
            document.getElementById("lNameSelect").disabled = true;
        }
    }
    else if(num == 3) {
        if (document.getElementById("mail").checked) {
            document.getElementById("mailSelect").disabled = false;
        }
        else {
            document.getElementById("mailSelect").disabled = true;
        }
    }
    else if (num == 4) {
        if (document.getElementById("city").checked) {
            document.getElementById("citySelect").disabled = false;
        }
        else {
            document.getElementById("citySelect").disabled = true;
        }
    }
}


function ShowPass(num) {
    document.getElementById("pass" + num).type = "text";
    document.getElementById("pass" + num).style.color = "white";
}

function HidePass(num) {
    document.getElementById("pass" + num).type = "password";
    document.getElementById("pass" + num).style.color = "#4d4d4d";
}