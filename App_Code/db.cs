using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;   //  DataSet עבור אובייקט מסוג
using System.Data.OleDb;  //  Access עבור מסד נתונים מסוג
//using System.Data.SqlClient;  //  SqlServer עבור מסד נתונים מסוג


public class db
{

    //  פונקציה שמבצעת:  הוספה, עדכון, מחיקה
    public static int InsertUpdateDelete(string strSql)
    {

        // 1)   Access 2007 - 2010 נתיב של מסד הנתונים עבור
        // מחרוזת ההתחברות
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='|DataDirectory|\Database.accdb';Persist Security Info=True";
        
        // 2)  אובייקט התקשרות אל מסד הנתונים
        OleDbConnection con = new OleDbConnection(connectionString);
       
        // 3)  אובייקט שמבצע את השאילתא
        OleDbCommand cmd = new OleDbCommand(strSql, con);

        con.Open();// פתיחת החיבור

        int row = cmd.ExecuteNonQuery();// ביצוע השאילתא

        con.Close(); // סגירת החיבור

        return row; // מחזיר מספר השורות שהושפעו
    }

    //    DataBase  הצגת הטבלה מתוך 
    public static DataSet ShowTable(string strSql, string tableName)
    {
        // 1)   Access 2007 - 2010 נתיב של מסד הנתונים עבור
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='|DataDirectory|\Database.accdb';Persist Security Info=True";
       
        // 2)  אובייקט התקשרות אל מסד הנתונים
        OleDbConnection con = new OleDbConnection(connectionString);
       
        // 3)  אובייקט שמבצע את השאילתא
        OleDbCommand cmd = new OleDbCommand(strSql, con);

        // פתיחת העתק של מודל טבלאי
        DataSet ds = new DataSet();

        //   DataSet     פתיחת אובייקט מתווך בין מסד הנתונים אל
        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

        // בנתונים ממסד הנתונים DataSet  מילוי 
        adapter.Fill(ds, tableName);

        //  DataSet  מחזיר
        return ds;
    }

    //    DataBase  פונקציה שמבצעת שאילתות מתמטיות מתוך 
    public static Object ReturnObject(string strSql)
    {
        // 1)   Access 2007 - 2010 נתיב של מסד הנתונים עבור
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='|DataDirectory|\Database.accdb';Persist Security Info=True";
       
        // 2)  אובייקט התקשרות אל מסד הנתונים
        OleDbConnection con = new OleDbConnection(connectionString);
       
        // 3)  אובייקט שמבצע את השאילתא
        OleDbCommand cmd = new OleDbCommand(strSql, con);

        con.Open();// פתיחת החיבור

        //COUNT, MAX, MIN , AVG, SUM  שאילתות: של 
        object obj = cmd.ExecuteScalar();

        con.Close(); // סגירת החיבור
        return obj;
    }




}
