using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

public class MailHelper
{
    private string from;
    private string to;
    private string bcc;
    private string cc;
    private string subject;
    private string body;
    /// <summary>
    /// Sends an mail message
    /// </summary>
    /// <param name="from">Sender address</param>
    /// <param name="to">Recepient address</param>
    /// <param name="bcc">Bcc recepient</param>
    /// <param name="cc">Cc recepient</param>
    /// <param name="subject">Subject of mail message</param>
    /// <param name="body">Body of mail message</param>
    
    public MailHelper(string from, string to, string bcc, string cc, string subject, string body)
    {
        this.from = from;
        this.to = to;
        this.bcc = bcc;
        this.cc = cc;
        this.subject = subject;
        this.body = body;
    }

    
   public void SendMailMessage()
   {
      // יצירת אובייקט אימייל
      MailMessage mMailMessage = new MailMessage();

      // השמת מוען
      mMailMessage.From = new MailAddress(this.from);

      // השמת נמען
      mMailMessage.To.Add(new MailAddress(this.to));

      // בודק אם הוכנס Bcc
      if (this.bcc != null && this.bcc != "")
      {
         // השמת Bcc
         mMailMessage.Bcc.Add(new MailAddress(this.bcc));
      }

      // בודק אם הוכנס Cc
      if (this.cc != null && this.cc != "")
      {
         // השמת CC
          mMailMessage.CC.Add(new MailAddress(this.cc));
      }       
       
       // השמת נושא
      mMailMessage.Subject = subject;

      // השמת תוכן
      mMailMessage.Body = body;

      // אם הפורמט גוף הוא מסוג טקסט או HTML
      mMailMessage.IsBodyHtml = true;

      // אם האימייל חשוב
      mMailMessage.Priority = MailPriority.High;

      // הצהרה על SmtpClient
      SmtpClient mSmtpClient = new SmtpClient();

      // שליחת האימייל
      mSmtpClient.Send(mMailMessage);
   }
}
