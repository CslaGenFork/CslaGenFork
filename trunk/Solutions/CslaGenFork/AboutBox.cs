using System;
using System.Reflection;
using System.Windows.Forms;

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
            lblAppTitle.Text = GetAttr<AssemblyTitleAttribute>().Title;
            lblAppDescription.Text = GetAttr<AssemblyDescriptionAttribute>().Description;
            lblAppCopyright.Text = GetAttr<AssemblyCopyrightAttribute>().Copyright;
            lblAssyVersion.Text = Assembly.GetExecutingAssembly().FullName.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("=", " ");
            lblAssyVersion.Text += @" (Final)";
        }

        private T GetAttr<T>() {            
            return ((T) Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (T), false)[0]);
        }

        /*private string GetVersion() {
            return GetBuildDate().ToString("yyyy'-'MM'-'dd");
        }

        /// <summary>
        /// Returns the build date for the assembly that calls this function. Extracts the date
        /// from the Linker's timestamp in the PE header.
        /// </summary>
        private DateTime GetBuildDate()
        {
            const int peHeaderOffset = 60;
            const int linkerTimestampOffset = 8;
            DateTime linkerDate = new DateTime(1970, 1, 1);
            byte[] data = new byte[2048];
            try
            {
                using (Stream s = new FileStream(Assembly.GetCallingAssembly().Location, FileMode.Open, FileAccess.Read))
                {
                    s.Read(data, 0, 2048);
                }
                int peTimestampOffset = BitConverter.ToInt32(data, peHeaderOffset) + linkerTimestampOffset;
                int epochSeconds = BitConverter.ToInt32(data, peTimestampOffset);
                linkerDate = linkerDate.AddSeconds(epochSeconds);
                linkerDate = linkerDate.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(linkerDate).Hours);
            }
            catch
            {
                linkerDate.AddDays(10);
            }
            return linkerDate;
        }*/

        private void Button_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
