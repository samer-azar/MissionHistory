using Microsoft.Win32;
using MissionHistory.Helper;
using MissionHistory.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MissionHistory.View
{
    public partial class Map : Form
    {
        #region GlobalVariables
        Hospital _Hospital;
        string _URL;
        #endregion

        #region Constructors
        public Map()
        {
            InitializeComponent();

            _URL = "http://maps.google.com/maps?q={0},{1}&ll={0},{1}&spn=0&t=k";
            ShowWebPage(string.Format(_URL, 33.50011, 35.50011));
        }

        public Map(Hospital hospital)
        {
            _Hospital = hospital;
            InitializeComponent();

            //Set the IE version registery of the current app to IE 11 Edge
            var appName = Process.GetCurrentProcess().ProcessName + ".exe";
            SetIE11EdgeKeyforWebBrowserControl(appName);

            _URL = "http://maps.google.com/maps?q={0},{1}&ll={0},{1}&spn=0&t=k";
            _URL = string.Format(_URL, _Hospital.Latitude, _Hospital.Longitude);
            ShowWebPage(_URL);

            this.Size = new Size(1100, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = string.Format("Map - {0} / {1}", _Hospital.Name, _Hospital.NameArabic);
        }

        #endregion

        #region Methods

        private void SetIE11EdgeKeyforWebBrowserControl(string appName)
        {
            RegistryKey Regkey = null;
            try
            {
                // For 64 bit machine
                if (Environment.Is64BitOperatingSystem)
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                else  //For 32 bit machine
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);

                // If the path is not correct or
                // if the user haven't priviledges to access the registry
                if (Regkey == null)
                {
                    //MessageBox.Show("Application Settings Failed - Address Not found");
                    return;
                }

                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                // Check if key is already present
                if (FindAppkey == "1101")
                {
                    //MessageBox.Show("Required Application Settings Present");
                    Regkey.Close();
                    return;
                }

                // If a key is not present add the key, Key value 8000 (decimal)
                if (string.IsNullOrEmpty(FindAppkey))
                    Regkey.SetValue(appName, unchecked((int)0x2AF9), RegistryValueKind.DWord);

                // Check for the key after adding
                FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                //if (FindAppkey == "1101")
                //MessageBox.Show("Application Settings Applied Successfully");
                //else
                //MessageBox.Show("Application Settings Failed, Ref: " + FindAppkey);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Application Settings Failed");
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the Registry
                if (Regkey != null)
                    Regkey.Close();
            }
        }

        private void ShowWebPage(string url)
        {
            webBrowser.Url = new Uri(url);
        }

        private void btnSendCoordinates_Click(object sender, EventArgs e)
        {
            try
            {
                string emailAddress = txtEmail.Text.Trim();
                if (emailAddress != string.Empty)
                {
                    if (EmailSender.IsValidEmail(emailAddress))
                    {
                        string message = string.Format("<h4><font color='black'>This is an automated message showing hospital details</font></h4>" +
                                                        "Name: {0}<BR>" +
                                                        "Phone Number: {1}<BR>" +
                                                        "Location: {2}<BR>" +
                                                        "Google Map: <a href='{3}'>Click on this link</a>",
                                                        _Hospital.Name + " - " + _Hospital.NameArabic,
                                                        _Hospital.PhoneNumber1 + "&nbsp;&nbsp;&nbsp;&nbsp;" + _Hospital.PhoneNumber2,
                                                        _Hospital.Location,
                                                        _URL);
                        EmailSender.SendEmailMessage(emailAddress, string.Empty, string.Empty, "Hospital Info", message, null);
                        MessageBox.Show(string.Format(MessageConstants.EmailSent, emailAddress), "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(MessageConstants.EmailInvalidInput, "إنتباه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show(MessageConstants.EmailEmptyInput, "إنتباه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(MessageConstants.EmailFailedToSend, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        
        #endregion


    }
}
