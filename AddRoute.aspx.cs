﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

public partial class AddRoute : System.Web.UI.Page
{
    public string showMembersAdmin;
    public string sessAbnd;

    public string insertValid;
    static string file;
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bigFile = false;
        if (Session["isAdmin"] == "1")//אם הקלינט הוא מנהל
        {
            showMembersAdmin = "<a href='ControlPanel.aspx'>פאנל ניהול</a> | ";
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";
        }
        else//אם הקלינט הוא לא מנהל
        {
            Response.Redirect("adminErr.aspx");
            Response.End();
        }

        if (Request.Form["title"] != "" && Request.Form["title"] != null)
        {
            //הכנסת קובץ
            //בדיקה אם הוכנס קובץ
            if (Request.Files[0].FileName != "")
            {
                //נותן את גודל כל הקבצים
                if (Request.ContentLength != 0)
                {
                    //קליטת גודל הקובץ לפי MB
                    int Size = Request.Files[0].ContentLength / 1024;
                    if (Size <= 50)//אם הובץ עולה מעל 50 MB
                    {
                        //נתיב הקובץ המלא
                        string LocalFile = Request.Files[0].FileName;

                        //מיקום האות הראשונה של הקובץ
                        int LastIndex = LocalFile.LastIndexOf(@"\") + 1;

                        //שם הקובץ
                        file = LocalFile.Substring(LastIndex, LocalFile.Length - LastIndex);
                        
                        //נתיב קובץ מלא חדש
                        string Path = @"C:\Users\אורי\Desktop\RIDEIT010513 _0000\images\tips_img\" + file;

                        //שמירת הקובץ בנתיב החדש
                        Request.Files[0].SaveAs(Path);
                        
                    }
                    else
                    {
                        insertValid = "הקובץ גדול מידי";
                        bigFile = true;
                    }
                }
                else
                {
                    insertValid = "בעיה לא ידועה";
                }
            }
            else
            {
                //שינוי לתמונת ברירת המחדל
                file = "missingImg.png";
            }

            //במידה והקובץ עלה
            if (!bigFile)
            {
                DateTime dt = DateTime.Now;

                //קליטת הנתונים וקריאה לפונקציה
                string currDate = dt.Day + "/" + dt.Month + "/" + dt.Year;
                InsertRoute(Request.Form["title"].Trim(), currDate, Request.Form["txtKm"].Trim(), Request.Form["txtTime"].Trim(), Request.Form["selectHardness"], Request.Form["selectArea"], Request.Form["content"].Trim());
            }
            
        }
        Response.Redirect("ControlPanel.aspx");
    }

    void InsertRoute(string title, string date, string km, string time, string hardness, string area, string content)
    {
        //אתחול המשתנים
        XmlElement articleEle, imgEle, titleEle, dateEle, kmEle, timeEle, hardnessEle, areaEle, contentEle;

        //יצירת אלמנט קובץ XML
        XmlDocument doc = new XmlDocument();

        //נתיב קובץ הXML
        string XMLfile = Server.MapPath("XML/XMLroutes.xml");

        //פתיחת הקובץ
        doc.Load(XMLfile);

        //יצירת אלמנטים
        imgEle = doc.CreateElement("img");
        titleEle = doc.CreateElement("title");
        dateEle = doc.CreateElement("date");
        kmEle = doc.CreateElement("km");
        timeEle = doc.CreateElement("time");
        hardnessEle = doc.CreateElement("hardness");
        areaEle = doc.CreateElement("area");
        contentEle = doc.CreateElement("content");
        articleEle = doc.CreateElement("article");

        //הכנסת המידע אל האלמנטים
        imgEle.InnerText = file;
        titleEle.InnerText = title;
        dateEle.InnerText = date;
        kmEle.InnerText = km;
        timeEle.InnerText = time;
        hardnessEle.InnerText = hardness;
        areaEle.InnerText = area;
        contentEle.InnerText = content;

        //שינוי האלמנטים לילדים של 'כתבה'
        articleEle.AppendChild(imgEle);
        articleEle.AppendChild(titleEle);
        articleEle.AppendChild(dateEle);
        articleEle.AppendChild(kmEle);
        articleEle.AppendChild(timeEle);
        articleEle.AppendChild(hardnessEle);
        articleEle.AppendChild(areaEle);
        articleEle.AppendChild(contentEle);

        //לשאול את מאיר
        doc.DocumentElement.InsertBefore(articleEle, doc.DocumentElement.FirstChild);
        FileStream fsxml = new FileStream(XMLfile, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
        //שמירת הקובץ וסגירתו
        doc.Save(fsxml);
        fsxml.Close();

        insertValid = "הנתונים הוכנסו בהצלחה";
        Response.Redirect("ControlPanel.aspx");
    }
}