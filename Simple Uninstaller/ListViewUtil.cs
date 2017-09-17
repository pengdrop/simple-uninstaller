using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleUninstaller
{
    /// <summary>
    /// 리스트뷰 컨트롤 대한 부가 기능을 담은 클래스
    /// </summary>
    class ListViewUtil
    {
        public static int GetIndexByDisplayIndex(ListView ListView, int DisplayIndex)
        {
            foreach (ColumnHeader Column in ListView.Columns)
            {
                if (Column.DisplayIndex == DisplayIndex)
                    return Column.Index;
            }
            return -1;
        }

        private struct ListViewTagInformation
        {
            public bool isLockedUpdate;
        }

        public static void LockUpdate(ListView ListView)
        {
            ListViewTagInformation lvtiTemp;
            if (ListView.Tag is ListViewTagInformation)
                lvtiTemp = (ListViewTagInformation)ListView.Tag;
            else
                lvtiTemp = new ListViewTagInformation();

            lvtiTemp.isLockedUpdate = true;
            ListView.Tag = lvtiTemp;
            ListView.BeginUpdate();
        }
        public static void UnlockUpdate(ListView ListView)
        {
            ListViewTagInformation lvtiTemp;
            if (ListView.Tag is ListViewTagInformation)
                lvtiTemp = (ListViewTagInformation)ListView.Tag;
            else
                lvtiTemp = new ListViewTagInformation();

            lvtiTemp.isLockedUpdate = false;
            ListView.Tag = lvtiTemp;
            ListView.EndUpdate();
        }
        public static bool IsLockedUpdate(ListView ListView)
        {
            ListViewTagInformation lvtiTemp;
            if (ListView.Tag is ListViewTagInformation)
                lvtiTemp = (ListViewTagInformation)ListView.Tag;
            else
                lvtiTemp = new ListViewTagInformation();

            return lvtiTemp.isLockedUpdate;
        }


        private struct ListViewItemTagInformation
        {
            public int SoftwareInformationIndex;
        }

        public static SoftwareInformation GetSoftwareInformationOfList(ListViewItem ListViewItem, List<SoftwareInformation> SoftwareInformationList)
        {
            ListViewItemTagInformation lvitiTemp = (ListViewItemTagInformation)ListViewItem.Tag;
            return SoftwareInformationList[lvitiTemp.SoftwareInformationIndex];
        }
        public static int GetSoftwareInformationIndex(ListViewItem ListViewItem)
        {
            ListViewItemTagInformation lvitiTemp;
            if (ListViewItem.Tag is ListViewItemTagInformation)
                lvitiTemp = (ListViewItemTagInformation)ListViewItem.Tag;
            else
                lvitiTemp = new ListViewItemTagInformation();

            return lvitiTemp.SoftwareInformationIndex;
        }
        public static void SetSoftwareInformationIndexOfList(ListViewItem ListViewItem, int SoftwareInformationIndex)
        {
            ListViewItemTagInformation lvitiTemp;
            if (ListViewItem.Tag is ListViewItemTagInformation)
                lvitiTemp = (ListViewItemTagInformation)ListViewItem.Tag;
            else
                lvitiTemp = new ListViewItemTagInformation();

            lvitiTemp.SoftwareInformationIndex = SoftwareInformationIndex;
            ListViewItem.Tag = lvitiTemp;
        }
    }

    /// <summary>
    /// 리스트뷰 컨트롤의 컬럼헤더 대한 부가 기능을 담은 클래스
    /// </summary>
    class ColumnHeaderUtil
    {
        private struct ColumnHeaderInformation
        {
            public string Text;
            public int Width;
            public bool Visible;
            public int DisplayIndex;
            public ToolStripMenuItem View;
        }
        private static List<ColumnHeaderInformation> chiForAdd = new List<ColumnHeaderInformation>();

        public static void Add(string Text, int Width, bool Visible, int DisplayIndex, ToolStripMenuItem View)
        {
            ColumnHeaderInformation chiTemp = new ColumnHeaderInformation();
            chiTemp.Text = Text;
            chiTemp.Width = Width;
            chiTemp.Visible = Visible;
            chiTemp.View = View;
            chiTemp.DisplayIndex = DisplayIndex;
            chiForAdd.Add(chiTemp);
        }
        public static void Create(ListView ListView)
        {
            ListView.Columns.Clear();
            foreach (ColumnHeaderInformation info in chiForAdd)
            {
                info.View.Checked = info.Visible;
                if (info.Visible)
                {
                    ColumnHeader chTemp = new ColumnHeader();
                    chTemp.Text = info.Text;
                    chTemp.Width = info.Width;
                    ListView.Columns.Add(chTemp);
                }
            }
            int i = 0;
            foreach (ColumnHeaderInformation info in chiForAdd)
            {
                if (info.Visible && info.DisplayIndex >= 0 && info.DisplayIndex < ListView.Columns.Count)
                {
                    ListView.Columns[i++].DisplayIndex = info.DisplayIndex;
                }
            }
            chiForAdd.Clear();
        }
    }
}
