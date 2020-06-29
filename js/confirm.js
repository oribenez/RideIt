function ConfirmDel(link) {
    var answer = confirm("האם אתה בטוח שהינך רוצה למחוק את משתמש זה")
    if (answer) {
        location.href = link;
    }
    else {
        alert("המשתמש שבחרת לא ימחק");
    }
}