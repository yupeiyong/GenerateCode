using Winform.Properties;
using WinForm.UI.UserControls.DataGridViewColumn;

namespace Winform.UserControls.DataGridViewColumn
{
    /// <summary>
    ///     对象名称：DataGridView操作按钮列（删除）
    ///     对象说明：通过本类可以实现，在DataGridView控件中，显示一个删除图片按钮的列。
    ///     编写日期：2019-02-15
    /// </summary>
    public class DataGridViewDeleteButtonColumn : DataGridViewOneButtonColumn
    {
        public DataGridViewDeleteButtonColumn():base(Resources.BtnDelete, Resources.BtnDelete02)
        {
            HeaderText = "操作";
        }
    }
}