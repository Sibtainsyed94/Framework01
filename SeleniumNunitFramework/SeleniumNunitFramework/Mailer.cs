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

namespace SeleniumNunitFramework
{
  class Mailer
  {
    private readonly System.Net.Mail.SmtpClient _client;
    private readonly List<MailAddress> _receptients;
    public Mailer(
      List<string> receptients,
      string host = "locahost",
      int port = 465,
      string username = null,
      string password = null
    ) {
      _client = new System.Net.Mail.SmtpClient(host, port);
      if(username != null)
      {
        _client.Credentials = new NetworkCredential(username, password);
        _receptients = receptients.Select(r => new MailAddress(r)).ToList();
      }
    }

    public void SendMail(
      string subject,
      string body,
      List<string> attachments
    ) {
      MailMessage message = new MailMessage {
        Subject = subject
      };
      _receptients.ForEach(x => {
        message.To.Add(x);
      });
      attachments.ForEach(x => {
        var f = File.OpenRead(x);
        var at = new Attachment(f, MediaTypeNames.Application.Octet);
        message.Attachments.Add(at);
      });
      message.Body = body;
      try {
        _client.Send(message);
      } catch {
        Console.WriteLine("Failed to send email");
      }
    }
  }
}
