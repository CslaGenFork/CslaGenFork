using WeifenLuo.WinFormsUI.Docking;

namespace CslaGenerator.Controls
{
    public partial class ObjectInfo : DockContent
    {
        public ObjectInfo()
        {
            InitializeComponent();
            propertyGrid.SelectedObject = propertyGrid;
        }
    }
}
