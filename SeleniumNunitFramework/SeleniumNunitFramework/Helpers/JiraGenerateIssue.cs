using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.Helpers
{
  public class JiraGenerateIssue {
    public static void CreateIssue(
      string summary,
      List<string> attachments = null
    ) {
      var host = System.Configuration.ConfigurationManager.AppSettings["JiraHost"];
      var username = System.Configuration.ConfigurationManager.AppSettings["JiraUsername"];
      var password = System.Configuration.ConfigurationManager.AppSettings["JiraPassword"];
      var project = System.Configuration.ConfigurationManager.AppSettings["JiraProject"];
      var reporter_id = System.Configuration.ConfigurationManager.AppSettings["JiraReporterId"];
      var settings = new JiraRestClientSettings();
      settings.EnableUserPrivacyMode = true;
      var jira = Jira.CreateRestClient(host, username, password, settings);
      var issue = jira.CreateIssue(project);
      issue.Type = "Bug";
      issue.Summary = summary;
      issue.Reporter = reporter_id;
      issue.SaveChanges();
      if(attachments != null && attachments.Count > 0) {
        attachments.ForEach(x => {
          var f = File.ReadAllBytes(x);
          issue.AddAttachment("Evidence", f);
        });
      }
    }
  }
}
