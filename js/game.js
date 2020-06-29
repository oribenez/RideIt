var listQ = new Array();
listQ[0] = 'Quest0';
listQ[1] = 'Quest1';
listQ[2] = 'Quest2';
listQ[3] = 'Quest3';
listQ[4] = 'Quest4';
listQ[5] = 'Quest5';
listQ[6] = 'Quest6';
listQ[7] = 'Quest7';
listQ[8] = 'Quest8';
listQ[9] = 'Quest9';
listQ[10] = 'Quest10';
listQ[11] = 'Quest11';
listQ[12] = 'Quest12';
listQ[13] = 'Quest13';
listQ[14] = 'Quest14';
listQ[15] = 'Quest15';

var listQEzer = new Array();
for (var i = 0; i < listQ.length; i++) {
    listQEzer[i] = 0;
}

function Start() {
    for (var i = 0; i < listQEzer.length; i++) {

        var rnd = Math.floor(Math.random() * listQ.length);//מספר רנדומלי
        for (var j = 0; j < listQEzer.length; j++) {

            while (arr[i] == rnd) {
                rnd = Math.floor(Math.random() * listQ.length);//מספר רנדומלי
                j = -1;//איפוס
            }
        }
        listQEzer[i] = rnd;
    }

    document.getElementsByClassName('radioAns').type = "radio";
}



function Triv() {
    
    /*
    var rnd = Math.floor(Math.random() * 16);
    document.getElementById('quest').innerHTML = "שאלה " + numQ + ": " + listQ[rnd] + " ?";
    document.getElementById('play').style.display = 'none';
    document.getElementById('gameForm').style.display = 'block';
    document.getElementById('goodBad').style.display = 'block';
    listQPast[0] = listQ[rnd];
    Answers();
    */

    

    if (numQPast > 15) {
        alert("Game - Over");
        document.getElementById('quest').style.display = 'none';
        document.getElementById('ans').style.display = 'none';

    }
    document.getElementById('quest').innerHTML = "שאלה " + numQ + ": " + listQ[rnd] + " ?";
    numQ++;
    document.getElementById('ans').style.display = 'block';
}

var counter = 0;
function Answers(){
    //ansA = document.getElementById('ansA').value;

    document.getElementById('quest').style.display = 'block';
    document.getElementById('quest').innerHTML = listQ[listQEzer[counter]];

    counter++;

    var flagRadio = false;
    var a = document.getElementsByName("ans");
    for (i = 0; i < a.length; i++)  // הרדיו כפתורי מערך על מעבר
    {
        if (a[i].checked) //   מסומן שנבדק הכפתור אם  
            flagRadio = true;
    }
    if (flagRadio == false) {//אם אף כפתור לא נבדק
        document.getElementById('error_gender').innerHTML = "<img src='images/no.png'> בחר מגדר";
        return false;
    }
}