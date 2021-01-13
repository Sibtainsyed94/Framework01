﻿using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitFramework.Helpers
{
  class JiraGenerateIssue {
    static void CreateIssue(
      string summary,
      List<string> attachments = null
    ) {
      var host = System.Configuration.ConfigurationManager.AppSettings["JiraHost"];
      var username = System.Configuration.ConfigurationManager.AppSettings["JiraUsername"];
      var password = System.Configuration.ConfigurationManager.AppSettings["JiraPassword"];
      var project = System.Configuration.ConfigurationManager.AppSettings["JiraProject"];
      var jira = Jira.CreateRestClient(host, username, password);
      var issue = jira.CreateIssue(project);
      issue.Type = "Bug";
      issue.Summary = summary;
      issue.Reporter = "Test Script";
      if(attachments != null && attachments.Count > 0) {
        attachments.ForEach(x => {
          var f = File.ReadAllBytes(x);
          issue.AddAttachment("Evidence", f);
        });
      }
      issue.SaveChanges();
    }
  }
}