using System;
using System.Windows.Forms;
using System.Collections;

namespace SimpleUninstaller
{
    class ListViewItemComparer : IComparer
    {
        private int ColumnIndex;
        private string ColumnName;
        private SortOrder SortType = SortOrder.Ascending;

        public ListViewItemComparer(int ColumnIndex, string ColumnName, SortOrder SortType)
        {
            this.ColumnIndex = ColumnIndex;
            this.ColumnName = ColumnName;
            this.SortType = SortType;
        }

        public int Compare(object x, object y)
        {
            dynamic Value_x = null;
            dynamic Value_y = null;

            // listview item to struct index
            SoftwareInformation siX = ListViewUtil.GetSoftwareInformationOfList((ListViewItem)x, Global.siMain);
            SoftwareInformation siY = ListViewUtil.GetSoftwareInformationOfList((ListViewItem)y, Global.siMain);

            // col name to struct info
            switch (ColumnName)
            {
                case "Name": // strDisplayName
                    Value_x = siX.strDisplayName;
                    Value_y = siY.strDisplayName;
                    break;

                case "Publisher": // strPublisher
                    Value_x = siX.strPublisher;
                    Value_y = siY.strPublisher;
                    break;

                case "Version": // strDisplayVersion
                    Value_x = siX.strDisplayVersion;
                    Value_y = siY.strDisplayVersion;
                    break;

                case "Install Time": // dtLastWriteTime
                    Value_x = siX.dtLastWriteTime;
                    Value_y = siY.dtLastWriteTime;
                    break;

                case "Size": // lngFileLocationSize
                    Value_x = siX.lngFileLocationSize;
                    Value_y = siY.lngFileLocationSize;
                    break;

                case "Help Link": // strHelpLink
                    Value_x = siX.strHelpLink;
                    Value_y = siY.strHelpLink;
                    break;

                case "Support Link": // strSupportLink
                    Value_x = siX.strSupportLink;
                    Value_y = siY.strSupportLink;
                    break;

                case "File Location": // strFileLocation
                    Value_x = siX.strFileLocation;
                    Value_y = siY.strFileLocation;
                    break;

                case "Registry Location": // strRegistryLocation
                    Value_x = siX.strRegistryLocation;
                    Value_y = siY.strRegistryLocation;
                    break;
            }

            if (SortType == SortOrder.Ascending) // asc
            {
                if (Value_x is string || Value_x is null)
                {
                    return String.Compare((string)Value_x, (string)Value_y);
                }
                else if (Value_x is DateTime)
                {
                    return DateTime.Compare((DateTime)Value_x, (DateTime)Value_y);
                }
                else if (Value_x is long)
                {
                    if (Value_x < Value_y) return -1;
                    else if (Value_x > Value_y) return 1;
                    else return 0;
                }
                else
                {
                    return 0;
                }
            }
            else if(SortType == SortOrder.Descending) // desc
            {
                if (Value_x is string || Value_x is null)
                {
                    return String.Compare((string)Value_y, (string)Value_x);
                }
                else if (Value_x is DateTime)
                {
                    return DateTime.Compare((DateTime)Value_y, (DateTime)Value_x);
                }
                else if (Value_x is long)
                {
                    if (Value_x > Value_y) return -1;
                    else if (Value_x < Value_y) return 1;
                    else return 0;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                //MessageBox.Show("unknown sort type");
                return 0;
            }
        }
    }
}
