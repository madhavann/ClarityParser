using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Microsoft.Office.Interop.Outlook;

namespace Clarity
{
    public partial class ThisAddIn
    {
        private void ThisAddInStartup(object sender, EventArgs e)
        {
            MAPIFolder inBox = Application.ActiveExplorer().Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            Items inBoxItems = inBox.Folders["Clarity"].Items;
            inBoxItems = inBoxItems.Restrict("[Unread] = true");
            foreach (
                MailItem newEmail in inBoxItems.OfType<MailItem>().Where(newEmail => newEmail.Attachments.Count > 0))
            {
                for (int i = 1;i <= newEmail.Attachments.Count;i++)
                {
                    newEmail.Attachments[i].SaveAsFile
                        (@"C:\TestFileSave\" +
                         newEmail.Attachments[i].FileName);
                }
                newEmail.UnRead = false;
            }
            ParseFile();
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
        }

        private static void ParseFile()
        {
            var sbOutput = new StringBuilder();
            var doc = new HtmlDocument();
            string[] filepathcollection = Directory.GetFiles(@"C:\TestFileSave\", "*.html");
            sbOutput.Append(
                "StartDate,EndDate,Agency,Agency,Company,Contact,gpslmail,E-mail,MailBox,Contractor Representative,NameField,Associate Name,Contractor #Field,Contractor #,E-mail,AssociateEmail,Time Sheet Period,MondayField,MondayActual,MondayDuration,Tuesday,TuesdayActual,TuesdayDuration,Wednesday,WednesdayActual,WednesdayDuration,Thursday,ThursdayActual,ThursdayDuration,Friday,FridayActual,FridayDuration,Saturday,SaturdayActual,SaturdayDuration,Sunday,SundayActual,SundayDuration,TotalField,TotalNumberofdays,Submittedby,Approved ByField,Approved By,ApprovedTime");
            sbOutput.AppendLine();
            foreach (string filepath in filepathcollection)
            {
                string filename = filepath.Split('\\').Last();
                string startdate = filename.Substring(filename.Length - 26, 10);
                string enddate = filename.Substring(filename.Length - 15, 10);
                doc.Load(new StreamReader(filepath));
                sbOutput.Append(startdate + "," + enddate + ",");

                HtmlNode table = doc.DocumentNode.SelectNodes("//table")[0];
                foreach (
                    string data in
                        table.SelectNodes("tbody").SelectMany(tbody => (from row in tbody.SelectNodes("tr|div")
                                                                        from cell in row.SelectNodes("th|td")
                                                                        select
                                                                            cell.InnerText.Replace("\n", String.Empty).
                                                                            Replace("\t", String.Empty).Replace("\r",
                                                                                                                String.
                                                                                                                    Empty)
                                                                            .Replace("&nbsp", "0").Replace("days",
                                                                                                           string.Empty)
                                                                            .Trim()
                                                                        into data where data.Length > 0
                                                                        select Regex.Replace(data, @"\s +", ","))))
                {
                    sbOutput.Append(data + ",");
                }
                sbOutput.AppendLine();
            }

            var swCSVFile = new StreamWriter(@"C:\TestFileSave\TimeReport.csv");
            swCSVFile.Write(sbOutput);
            swCSVFile.Close();
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += ThisAddInStartup;
            Shutdown += ThisAddIn_Shutdown;
        }

        #endregion
    }
}