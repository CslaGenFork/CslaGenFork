using System.Windows.Forms;
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

        #region Manage state

        internal void GetState()
        {
            GeneratorController.Current.CurrentUnitLayout.ObjectPropertySort = propertyGrid.PropertySort;
            if (propertyGrid.SelectedGridItem.PropertyDescriptor != null)
                GeneratorController.Current.CurrentUnitLayout.ObjectSelectedGridItem = propertyGrid.SelectedGridItem.PropertyDescriptor.Name;

            if (propertyGrid.PropertySort != PropertySort.Alphabetical)
            {
                GeneratorController.Current.CurrentUnitLayout.ObjectCollapsedCategories.Clear();
                var root = propertyGrid.SelectedGridItem;
                while (root.Parent != null)
                {
                    root = root.Parent;
                }

                foreach (var item in root.GridItems)
                {
                    var gridItem = item as GridItem;
                    if (gridItem != null && !gridItem.Expanded)
                        GeneratorController.Current.CurrentUnitLayout.ObjectCollapsedCategories.Add(gridItem.Label);
                }
            }
        }

        internal void SetState()
        {
            propertyGrid.PropertySort = GeneratorController.Current.CurrentUnitLayout.ObjectPropertySort;

            var root = propertyGrid.SelectedGridItem;
            while (root.Parent != null)
            {
                root = root.Parent;
            }

            foreach (var item in root.GridItems)
            {
                var gridItem = item as GridItem;
                if (gridItem != null)
                {
                    gridItem.Expanded = !IsObjectCategoryCollapsed(gridItem.Label);

                    foreach (var subItem in gridItem.GridItems)
                    {
                        var subGridItem = subItem as GridItem;
                        if (subGridItem != null && subGridItem.PropertyDescriptor != null)
                        {
                            if (subGridItem.PropertyDescriptor.Name == GeneratorController.Current.CurrentUnitLayout.ObjectSelectedGridItem)
                                subGridItem.Select();
                        }
                    }
                }
            }
        }

        private static bool IsObjectCategoryCollapsed(string gridItem)
        {
            foreach (var category in GeneratorController.Current.CurrentUnitLayout.ObjectCollapsedCategories)
            {
                if (category == gridItem)
                    return true;
            }

            return false;
        }

        #endregion
    }
}
