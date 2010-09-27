using System;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace CslaGenerator
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            this.lblAppTitle.Text = GetAttr<AssemblyTitleAttribute>().Title;
            this.lblAppDescription.Text = GetAttr<AssemblyDescriptionAttribute>().Description;
            this.lblAppCopyright.Text = GetAttr<AssemblyCopyrightAttribute>().Copyright;
            this.lblAssyVersion.Text = Assembly.GetExecutingAssembly().FullName.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("=", " ");
        }
        
        private T GetAttr<T>() {            
            return ((T)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), false)[0]);
        }

        private string GetVersion() {
            return GetBuildDate().ToString("yyyy'-'MM'-'dd");
        }

        /// <summary>
        /// Returns the build date for the assembly that calls this function. Extracts the date
        /// from the Linker's timestamp in the PE header.
        /// </summary>
        private DateTime GetBuildDate()
        {
            const int PE_HEADER_OFFSET = 60;
            const int LINKER_TIMESTAMP_OFFSET = 8;
            DateTime linkerDate = new DateTime(1970, 1, 1);
            byte[] data = new byte[2048];
            try
            {
                using (Stream s = new FileStream(Assembly.GetCallingAssembly().Location, FileMode.Open, FileAccess.Read))
                {
                    s.Read(data, 0, 2048);
                }
                int peTimestampOffset = BitConverter.ToInt32(data, PE_HEADER_OFFSET) + LINKER_TIMESTAMP_OFFSET;
                int epochSeconds = BitConverter.ToInt32(data, peTimestampOffset);
                linkerDate = linkerDate.AddSeconds(epochSeconds);
                linkerDate = linkerDate.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(linkerDate).Hours);
            }
            catch
            {
                linkerDate.AddDays(10);
            }
            return linkerDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
