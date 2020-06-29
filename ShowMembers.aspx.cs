using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ShowMembers : System.Web.UI.Page
{
    public string showMembersAdmin;
    public string connGuest;
    public string controlPanel;
    public string sessAbnd;
    public string hideSer = "";
    public string str = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["page"] == null)
        {
            Session["searchQ"] = "";
            Session["serValue"] = "";
            Response.Redirect("ShowMembers.aspx?page=1");
        }
        if (Session["isAdmin"] == "0" || Session["isAdmin"] == null)//אם הקלינט לא אדמין
        {
            Response.Redirect("adminErr.aspx");
            Response.End();
        }
        else
        {
            controlPanel = "<a href='ControlPanel.aspx'>פאנל ניהול</a>|";
            sessAbnd = "<a href='LogOut.aspx'>התנתק</a>";
        }

        
        string strQuery = "SELECT * FROM members";
        string str = Request.Form["ckType"];

        Session["ckTypeAutoFill"] = str;

        bool flag = true;
        string[] arr = null;
        if (str != "" && str != null)
        {
            arr = str.Split(',');
        }
        else
            flag = false;

        if (Request.Form["find"] != "" && Request.Form["find"] != null)
        {
            if (Request.Form["search"] != "" && flag)
            {
                string query = "SELECT COUNT(fName) FROM members";
                strQuery = "SELECT * FROM members";
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == 0)
                    {
                        strQuery += " WHERE ";
                        query += " WHERE ";
                    }
                    else
                    {
                        strQuery += " OR ";
                        query += " OR ";
                    }

                    string idSelect = arr[i] + "Select";
                    if (Request.Form[idSelect] == "מתחיל")
                    {
                        strQuery += arr[i] + " LIKE '" + Request.Form["search"] + "%'";
                        query += arr[i] + " LIKE '" + Request.Form["search"] + "%'";
                    }
                    else if (Request.Form[idSelect] == "מסתיים")
                    {
                        strQuery += arr[i] + " LIKE '%" + Request.Form["search"] + "'";
                        query += arr[i] + " LIKE '%" + Request.Form["search"] + "'";
                    }
                    else
                    {
                        strQuery += arr[i] + " LIKE '%" + Request.Form["search"] + "%'";
                        query += arr[i] + " LIKE '%" + Request.Form["search"] + "%'";
                    }
                }

                object obj = db.ReturnObject(query);
                if (int.Parse(obj.ToString()) <= 0)
                {
                    str += "לא נמצאו משתמשים";
                }
                else
                {
                    Session["searchQ"] = strQuery;
                    Session["serValue"] = Request.Form["search"];
                    Session["searchStr"] = Request.Form["find"];
                    SearchUsr(strQuery);
                    hideSer = "<script type='text/javascript'>showSearch(\'show\')</script>";
                }
                
            }
            else
            {
                strQuery = "SELECT * FROM members";
                SearchUsr(strQuery);
            }

        }
        else if (Session["searchQ"] != null && Session["searchQ"] != "")
        {
            SearchUsr(Session["searchQ"].ToString());
            hideSer = "<script type='text/javascript'>showSearch(\'show\')</script>";
        }
        else
        {
            strQuery = "SELECT * FROM members";
            SearchUsr(strQuery);
            hideSer = "<script type='text/javascript'>document.getElementById('hiddenContainer').style.display = 'none'</script>";
        }

    }

    private void SearchUsr(string strQuery)
    {
        DataSet ds = db.ShowTable(strQuery, "members");

        str += "<div id='tableWrapper'><table class='oddEven'>";
        str += "<tr class='trFirstRow'> <td> # </td> <td> שם פרטי </td><td> שם משפחה </td><td> סיסמא </td><td> אימייל </td><td> מנהל </td><td> איזור </td><td> מגדר </td><td>מחק</td><td>עדכן</td> </tr>";
        
        int counter = 0;

        int numObj = 8;
        int numUsers = ds.Tables["members"].Rows.Count + 1;
        int page = (int.Parse(Request.QueryString["page"].ToString()) - 1) * numObj;//מספר אובייקטים
        int numObjHelp = numObj;

        int numPage = ds.Tables["members"].Rows.Count / numObj;
        if (ds.Tables["members"].Rows.Count % numObj != 0)
            numPage++;

        if (ds.Tables["members"].Rows.Count % numObj != 0 && int.Parse(Request.QueryString["page"].ToString()) == numPage)
        {
            numObjHelp = ds.Tables["members"].Rows.Count % numObj;
        }


        if (int.Parse(Request.QueryString["page"]) > 0 && int.Parse(Request.QueryString["page"]) <= numPage)
        {

            for (int i = page; i < page + numObjHelp; i++)
            {
                counter++;
                string trClassOddEven = "even";

                if (counter % 2 == 0)
                    trClassOddEven = "odd";
                else
                    trClassOddEven = "even";

                str += "<tr class='" + trClassOddEven + "'>";

                str += "<td style='font-size: 14px;'>" + (i + 1) + "</td>";
                str += "<td>" + ds.Tables["members"].Rows[i]["fName"].ToString() + "</td>";
                str += "<td>" + ds.Tables["members"].Rows[i]["lName"].ToString() + "</td>";
                str += "<td><input type='password' name='pass" + i + "' id='pass" + i + "' readonly='readonly' size='12' value='" + ds.Tables["members"].Rows[i]["pass"].ToString() + "' style='background: none; border: none;text-align: center;' onmouseover='ShowPass(" + i + ")' onmouseout='HidePass(" + i + ")' /></td>";
                str += "<td>" + ds.Tables["members"].Rows[i]["mail"].ToString() + "</td>";
                string admin = "לא";
                if (ds.Tables["members"].Rows[i]["isAdmin"].ToString() == "1")
                {
                    admin = "<b>כן</b>";
                }
                str += "<td>" + admin + "</td>";
                str += "<td>" + ds.Tables["members"].Rows[i]["gender"].ToString() + "</td>";
                str += "<td>" + ds.Tables["members"].Rows[i]["city"].ToString() + "</td>";
                string linkDel = "Delete.aspx?mail=" + ds.Tables["members"].Rows[i]["mail"].ToString();
                str += "<td class='aDel'><a href='Delete.aspx?mail=" + ds.Tables["members"].Rows[i]["mail"].ToString() + "'>מחק</a></td>";
                str += "<td class='aDel'><a href='Update.aspx?mail=" + ds.Tables["members"].Rows[i]["mail"].ToString() + "'>עדכן</a></td>";

                str += "</tr>";
            }
            str += "</table></div>";
            if (ds.Tables["members"].Rows.Count < 1)
            {
                str += "לא נמצאו משתמשים";
            }

            if (numPage > 4)
            {
                str += "<div style='background: url(images/minimal-pagination-tray.png)no-repeat;margin: 23px 310px 0 0; font-size: 15px; width: 375px; height: 39px;font-weight: bold;font-family: arial, tahoma;'>";
            }
            else if(numPage == 4)
            {
                str += "<div style='background: url(images/minimal-pagination-tray-4.png)no-repeat;margin: 23px 310px 0 0; font-size: 15px; width: 340px; height: 39px;font-weight: bold;font-family: arial, tahoma;'>";
            }
            else if(numPage == 3)
            {
                str += "<div style='background: url(images/minimal-pagination-tray-3.png)no-repeat;margin: 23px 310px 0 0; font-size: 15px; width: 375px; height: 39px;font-weight: bold;font-family: arial, tahoma;'>";
            }
            else if(numPage == 2)
            {
                str += "<div style='background: url(images/minimal-pagination-tray-2.png)no-repeat;margin: 23px 310px 0 0; font-size: 15px; width: 375px; height: 39px;font-weight: bold;font-family: arial, tahoma;'>";
            }
            else if (numPage == 1)
            {
                str += "<div style='background: url(images/minimal-pagination-tray-1.png)no-repeat;margin: 23px 310px 0 0; font-size: 15px; width: 375px; height: 39px;font-weight: bold;font-family: arial, tahoma;'>";
            }
            str += "<a href='ShowMembers.aspx?page=" + (int.Parse(Request.QueryString["page"]) - 1) + "' ><div style='background: url(images/minimal-pagination-back.png)no-repeat;text-align: left; width: 51px; height: 41px;float:left;'></div></a>&nbsp;&nbsp;";
            int start = int.Parse(Request.QueryString["page"]) - 2;
            int end = int.Parse(Request.QueryString["page"]) + 2;
            if (int.Parse(Request.QueryString["page"]) -2 <0)//דף 2 ו 1
            {
                start = 1;
                end += 2;
            }
            else if (int.Parse(Request.QueryString["page"]) - 2 < 1)
            {
                start = 1;
                end += 1;
            }

            if (int.Parse(Request.QueryString["page"]) +2 > numPage)
            {
                end = numPage;
                start = start - 1;
            }
            if (int.Parse(Request.QueryString["page"]) +1 > numPage)
            {
                end = numPage;
                start = start - 1;
            }
            if (numPage > 4)
            {

                for (int i = start; i <= end; i++)
                {
                    if (i > 9 && i < 100)
                    {
                        if (int.Parse(Request.QueryString["page"]) == i)
                        {
                            str += "<div style='background: url(images/minimal-pagination-active.png)no-repeat;color: rgb(0, 134, 209);text-align: left;width: 28px;padding: 9px 0px 0 10px;height: 26px;float: left;margin: 2px 0px 0 4px;'>" + i + "</div>&nbsp;&nbsp;";
                        }
                        else
                        {
                            str += "<a href='ShowMembers.aspx?page=" + i + "' ><div style='background: url(images/minimal-pagination.png)no-repeat;text-align: left;padding: 11px 0px 0 13px;width: 29px;height: 29px;float:left;'>" + i + "</div></a>&nbsp;&nbsp;";
                        }
                    }
                    else
                    {
                        if (int.Parse(Request.QueryString["page"]) == i)
                        {
                            str += "<div style='background: url(images/minimal-pagination-active.png)no-repeat;color: rgb(0, 134, 209);text-align: left;width: 24px;padding: 9px 0px 0 15px;height: 26px;float: left;margin: 2px 0px 0 4px;'>" + i + "</div>&nbsp;&nbsp;";
                        }
                        else
                        {
                            str += "<a href='ShowMembers.aspx?page=" + i + "' ><div style='background: url(images/minimal-pagination.png)no-repeat;text-align: left;padding: 10px 0px 0 17px; width: 23px; height: 41px;float:left;'>" + i + "</div></a>&nbsp;&nbsp;";
                        }
                    }
                } 
            }
            else
            {
                for (int i = 1; i <= numPage; i++)
                {
                    if (int.Parse(Request.QueryString["page"]) == i)
                    {
                        str += "<div style='background: url(images/minimal-pagination-active.png)no-repeat;color: rgb(0, 134, 209);text-align: left;width: 24px;padding: 9px 0px 0 15px;height: 26px;float: left;margin: 2px 0px 0 4px;'>" + i + "</div>&nbsp;&nbsp;";
                    }
                    else
                    {
                        str += "<a href='ShowMembers.aspx?page=" + i + "' ><div style='background: url(images/minimal-pagination.png)no-repeat;text-align: left; width: 23px;padding: 10px 0px 0 17px; height: 41px;float:left;'>" + i + "</div></a>&nbsp;&nbsp;";
                    }
                }
            }

            str += "<div style='background: url(images/minimal-pagination-periods.png)no-repeat;width: 13px;height: 4px;float:left;margin: 24px 0px 0 7px;'></div>";

            if (numPage > 9 && numPage < 100)
            {
                str += "<a href='ShowMembers.aspx?page=" + numPage + "' ><div style='background: url(images/minimal-pagination.png)no-repeat;padding: 11px 0px 0 13px;text-align: left; width: 29px; height: 29px;float:left;margin: 0 0px 0 5px;'>" + numPage + "</div></a>&nbsp;&nbsp;";
            }
            else
            {
                str += "<a href='ShowMembers.aspx?page=" + numPage + "' ><div style='background: url(images/minimal-pagination.png)no-repeat;padding: 10px 0px 0 17px;text-align: left; width: 23px; height: 41px;float:left;margin: 0 0px 0 5px;'>" + numPage + "</div></a>&nbsp;&nbsp;";
            }

            if (numPage > 4)
            {
                if (numPage > 9)
                {
                    str += "<a href='ShowMembers.aspx?page=" + (int.Parse(Request.QueryString["page"]) + 1) + "' ><div style='background: url(images/minimal-paginatio-next.png)no-repeat;text-align: left; width: 51px; height: 41px;margin: -58px 0 0 0;'></div></a>&nbsp;&nbsp;";
                }
                else
                {
                    str += "<a href='ShowMembers.aspx?page=" + (int.Parse(Request.QueryString["page"]) + 1) + "' ><div style='background: url(images/minimal-paginatio-next.png)no-repeat;text-align: left; width: 51px; height: 41px;margin: -18px 0 0 0;'></div></a>&nbsp;&nbsp;";
                }
            }
            else
            {
                if (numPage != 4)
                {
                    str += "<a href='ShowMembers.aspx?page=" + (int.Parse(Request.QueryString["page"]) + 1) + "' ><div style='background: url(images/minimal-paginatio-next.png)no-repeat;text-align: left; width: 51px; height: 41px;float: left;margin: 0px 0 0 0;'></div></a>&nbsp;&nbsp;";
                }
                else
                {
                    str += "<a href='ShowMembers.aspx?page=" + (int.Parse(Request.QueryString["page"]) + 1) + "' ><div style='background: url(images/minimal-paginatio-next.png)no-repeat;text-align: left; width: 51px; height: 41px;float: left;margin: -19px 0 0 0;'></div></a>&nbsp;&nbsp;";
                }
            }
            str += "</div>";
        }
        else if (int.Parse(Request.QueryString["page"]) < 1)
        {
            Response.Redirect("ShowMembers.aspx?page=1");
        }
        else if (int.Parse(Request.QueryString["page"]) > numPage)
        {
            Response.Redirect("ShowMembers.aspx?page=" + numPage);
        }
    }
}