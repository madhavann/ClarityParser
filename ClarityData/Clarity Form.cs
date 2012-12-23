using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClarityData.Properties;
using Microsoft.Office.Interop.Outlook;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Configuration;

namespace ClarityData
{
    public partial class ClarityDataParser : Form
    {
        public ClarityDataParser()
        {
            InitializeComponent();
        }

        private void GetClarityReportClick(object sender, EventArgs e)
        {
            var cfGet=new ClarityFunctions();
            cfGet.GetAttachments(lblStatusOutput);
            
        }

        private void ParseReportClick(object sender, EventArgs e)
        {
         
            var sbOutput = new StringBuilder();
            var doc = new HtmlDocument();
            var filepathcollection = Directory.GetFiles(ConfigurationManager.AppSettings["FileSaveLocation"], "*.html");
            sbOutput.Append(
                "StartDate,EndDate,Agency,Agency,Company,Contact,gpslmail,E-mail,MailBox,Contractor Representative,NameField,Associate Name,Contractor #Field,Contractor #,E-mail,AssociateEmail,Time Sheet Period,MondayField,MondayActual,MondayDuration,Tuesday,TuesdayActual,TuesdayDuration,Wednesday,WednesdayActual,WednesdayDuration,Thursday,ThursdayActual,ThursdayDuration,Friday,FridayActual,FridayDuration,Saturday,SaturdayActual,SaturdayDuration,Sunday,SundayActual,SundayDuration,TotalField,TotalNumberofdays,Submittedby,Approved ByField,Approved By,ApprovedTime");
            sbOutput.AppendLine();
            foreach (var filepath in filepathcollection)
            {
                var filename = filepath.Split('\\').Last();
                var startdate = filename.Substring(filename.Length - 26, 10);
                var enddate = filename.Substring(filename.Length - 15, 10);
                lblStatusOutput.Text = Resources.ClarityDataParser_ParseReportClick_Processing_File_ +filepath;
                var srFile = new StreamReader(filepath); 
                doc.Load(srFile);
                sbOutput.Append(startdate + "," + enddate + ",");

                var table = doc.DocumentNode.SelectNodes("//table")[0];
                foreach (
                    var data in
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
                srFile.Close();
                if (File.Exists(ConfigurationManager.AppSettings["ArchiveLocation"] + filename))
                    File.Delete(ConfigurationManager.AppSettings["ArchiveLocation"] + filename);
                File.Move(filepath, ConfigurationManager.AppSettings["ArchiveLocation"]+filename);
            }

            var swCSVFile = new StreamWriter(ConfigurationManager.AppSettings["FileSaveLocation"] + ConfigurationManager.AppSettings["ReportFileName"] + DateTime.Today.ToString("dd-MM-yyyy") + Resources.ClarityDataParser_ParseReportClick__csv, true);
            swCSVFile.Write(sbOutput);
            swCSVFile.Close();
            lblStatusOutput.Text = Resources.ClarityDataParser_ParseReportClick_Output_file_ready + ConfigurationManager.AppSettings["FileSaveLocation"] + ConfigurationManager.AppSettings["ReportFileName"] + DateTime.Today.ToString("dd-MM-yyyy") + Resources.ClarityDataParser_ParseReportClick__csv;
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            var frm = new Form {Text = Resources.ClarityDataParser_aboutToolStripMenuItem_Click_Product_is_freeware};
            frm.ShowDialog();
        }

        private void CloseOutlookClick(object sender, EventArgs e)
        {
            var cfGet = new ClarityFunctions(); 
            cfGet.Closeoutlook();
            Dispose(true);
        }
        

      
    }
    public class ClarityFunctions
    {
        private readonly Microsoft.Office.Interop.Outlook.Application _oApp;
        public ClarityFunctions()
        {
            _oApp = new Microsoft.Office.Interop.Outlook.Application();
        }
        
        public void GetAttachments(Label lblStatusOutput)
        {
            
            
            var ns = _oApp.GetNamespace("MAPI");
            var inBox = ns.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            var inBoxItems = inBox.Folders["Clarity"].Items.Restrict("[Unread] = true");
            inBoxItems.Sort("Received",0);
            if (inBoxItems.Count <= 0)
                lblStatusOutput.Text = Resources.ClarityFunctions_GetAttachments_No_New_mails;
            else
            {
                do
                {

                    MailItem newEmail = inBoxItems.GetFirst();

                    for (int i = 1; i <= newEmail.Attachments.Count; i++)
                    {
                        newEmail.Attachments[i].SaveAsFile
                            ( ConfigurationManager.AppSettings["FileSaveLocation"] +newEmail.Attachments[i].FileName);
                    }
                    newEmail.UnRead = false;
                    inBoxItems = inBox.Folders["Clarity"].Items.Restrict("[Unread] = true");
                    inBoxItems.Sort("Received", 0);
                
                    lblStatusOutput.Text= Resources.ClarityFunctions_GetAttachments_Getting_Attachment__ + newEmail.Subject +
                                   Resources.ClarityFunctions_GetAttachments_ + inBoxItems.Count;
                } while (inBox.Folders["Clarity"].Items.Restrict("[Unread] = true").Count > 0);
            
            
            
            lblStatusOutput.Text = Resources.ClarityFunctions_GetAttachments_Mail_attachments_downloaded;
            }
            MessageBox.Show(Resources.ClarityFunctions_GetAttachments__Ready_to_process_the_file__);
        }
        public void Closeoutlook()
        {
            _oApp.Quit();
        }
    }
}
