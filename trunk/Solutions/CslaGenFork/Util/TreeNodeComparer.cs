using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
namespace CslaGenerator.Util
{
	/// <summary>
	/// Summary description for TreeNodeComparer.
	/// </summary>
	public class TreeNodeComparer : IComparer, IComparer<TreeNode>
	{
	    public int Compare(object x, object y)
		{
			return Compare((TreeNode)x,(TreeNode)y);
		}

        #region IComparer<TreeNode> Members

        public int Compare(TreeNode x, TreeNode y)
        {
            return CaseInsensitiveComparer.Default.Compare(x.Text, y.Text);
        }

        #endregion
	}
}
