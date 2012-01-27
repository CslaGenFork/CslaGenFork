using System.Drawing;
using CslaGenerator.Metadata;
using WeifenLuo.WinFormsUI.Docking;

namespace CslaGenerator.Controls
{
    public partial class GenerationReportViewer : DockContent
    {
        public GenerationReportViewer(GenerationReportCollection source, string title)
        {
            InitializeComponent();

            Icon = Icon.FromHandle(Properties.Resources.Output.GetHicon());
            DockAreas = DockAreas.DockBottom |
                        DockAreas.Float;
            Text = title;
            generationReportCollectionBindingSource.DataSource = source;
        }
    }
}
