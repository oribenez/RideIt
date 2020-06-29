
var rndNum;
var numTries;
var limit = 100;

function Random() {
    var num = Math.floor(Math.random() * limit) + 1;
    return num;
}
function NewGame() {
    rndNum = Random();
    numTries = 0;
    document.fGame.output.value='אני חושב על מספר בין 1 ל' + limit +' , קח את הזמן ותנחש מספר.....';
    document.fGame.tries.value = numTries;
    document.fGame.highLow.value = '';
    document.fGame.inputNum.value = '';
}
function Game(number) {
    if (number == rndNum) {
        numTries++;
        document.fGame.output.value = 'ניחשת נכון את המספר ' + rndNum + ' ב-' + numTries + 'ניחושים... התחל משחק חדש ';
        document.fGame.highLow.value = 'כל הכבוד';
        document.getElementById('goodJob').src = "images/congrats.gif";
    }
    else {
        numTries++;
        document.fGame.output.value = 'זה לא המספר  ' + number + ' . נסה שוב....';
        if (rndNum > number) {
            document.fGame.highLow.value = 'גבוה יותר';
        }
        else {
            document.fGame.highLow.value = 'נמוך יותר';
        }

        
    }
    document.fGame.tries.value = numTries;
}