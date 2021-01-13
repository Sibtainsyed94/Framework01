using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.Helpers
{
  static class Mailer
  {
    private static SmtpClient generateMailer() {
      string host = System.Configuration.ConfigurationManager.AppSettings["MailHost"];
      int port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MailPort"]);
      var client = new System.Net.Mail.SmtpClient(host, port);
      try {
        string username = System.Configuration.ConfigurationManager.AppSettings["MailUsername"];
        string password = System.Configuration.ConfigurationManager.AppSettings["MailPassword"];
        client.Credentials = new NetworkCredential(username, password);
      } catch { }
      return client;
    }

    public static void SendMail(
      string subject,
      string body,
      List<string> attachments
    ) {
      var client = generateMailer();
      MailMessage message = new MailMessage {
        Subject = subject
      };
      var receptients = System.Configuration.ConfigurationManager.AppSettings["MailReceptients"]
        .Split(';').ToList();
      receptients.ForEach(x => {
        message.To.Add(x);
      });
      attachments.ForEach(x => {
        var f = File.OpenRead(x);
        var at = new Attachment(f, MediaTypeNames.Application.Octet);
        message.Attachments.Add(at);
      });
      message.Body = body;
      try {
        client.Send(message);
      } catch {
        Console.WriteLine("Failed to send email");
      }
    }
  }
}
