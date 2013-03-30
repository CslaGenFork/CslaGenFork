using System.Collections.Generic;
using System.Windows.Forms;

namespace CslaGenerator.Metadata
{
    public class CslaGeneratorUnitLayout
    {
        public CslaGeneratorUnitLayout()
        {
            ProjectListFilterText = string.Empty;
            ProjectListFilterType = string.Empty;
            ProjectListSortMode = string.Empty;
            ProjectListSelectedObjects = new List<string>();
            ObjectCollapsedCategories = new List<string>();
            ObjectPropertySort = PropertySort.Categorized;
            ObjectSelectedGridItem = string.Empty;
            SchemaExpandedTrees = new List<string>();
            SchemaSelectedTree = string.Empty;
            SchemaExpandedNodes = new List<string>();
            SchemaSelectedNode = string.Empty;
            SchemaSelectedSprocSubNode = string.Empty;
            ActiveDocument = string.Empty;
            RelationsBuilderTab = string.Empty;
            RelationsBuilderSelectedObject = string.Empty;
            RelationsBuilderCollapsedCategories = new List<string>();
            RelationsBuilderPropertySort = PropertySort.Categorized;
            RelationsBuilderSelectedGridItem = string.Empty;
            ProjectPropertiesSubTab = string.Empty;
            ProjectPropertiesMainTab = string.Empty;
            LayoutFileVersion = "1.0";
        }

        public string ProjectListFilterText { get; set; }

        public string ProjectListFilterType { get; set; }

        public string ProjectListSortMode { get; set; }

        public List<string> ProjectListSelectedObjects { get; set; }

        public List<string> ObjectCollapsedCategories { get; set; }

        public PropertySort ObjectPropertySort { get; set; }

        public string ObjectSelectedGridItem { get; set; }

        public List<string> SchemaExpandedTrees { get; set; }

        public string SchemaSelectedTree { get; set; }

        public List<string> SchemaExpandedNodes { get; set; }

        public string SchemaSelectedNode { get; set; }

        public string SchemaSelectedSprocSubNode { get; set; }

        public string ActiveDocument { get; set; }

        public string RelationsBuilderTab { get; set; }

        public string RelationsBuilderSelectedObject { get; set; }

        public List<string> RelationsBuilderCollapsedCategories { get; set; }

        public PropertySort RelationsBuilderPropertySort { get; set; }

        public string RelationsBuilderSelectedGridItem { get; set; }

        public string ProjectPropertiesMainTab { get; set; }

        public string ProjectPropertiesSubTab { get; set; }

        public string LayoutFileVersion { get; set; }
    }
}
