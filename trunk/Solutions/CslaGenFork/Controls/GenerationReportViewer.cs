using System.Drawing;
using CslaGenerator.Metadata;
using Equin.ApplicationFramework;// http://sourceforge.net/projects/blw/ - BSD license
using WeifenLuo.WinFormsUI.Docking;// http://sourceforge.net/projects/dockpanelsuite/ - MIT license

namespace CslaGenerator.Controls
{
    public partial class GenerationReportViewer : DockContent
    {
        private BindingListView<GenerationReport> _sorted;

        public GenerationReportViewer()
        {
            InitializeComponent();

            Icon = Icon.FromHandle(Properties.Resources.Output.GetHicon());
            DockAreas = DockAreas.DockBottom |
                        DockAreas.Float;
        }

        public void Fill(GenerationReportCollection source)
        {
            // Create a view of the items
            _sorted = new BindingListView<GenerationReport>(source);
            _sorted.ApplySort("ObjectName ASC");
            // Make the grid display this view
            generationReportCollectionBindingSource.DataSource = _sorted;
        }

        public void Empty()
        {
            generationReportCollectionBindingSource.DataSource = null;
        }
    }
}
