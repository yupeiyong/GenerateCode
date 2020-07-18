using Winform.Properties;

namespace Winform.UserControls.DataGridViewColumn
{
    /// <summary>
    ///     对象名称：DataGridView操作按钮列（修改、删除）
    ///     对象说明：通过本类可以实现，在DataGridView控件中，显示一个分别包含修改和删除两个图片按钮的列。
    ///     编写日期：2010/06/20 03:15:28
    /// </summary>
    public class DataGridViewActionButtonColumn : DataGridViewTwoButtonColumn
    {
        public DataGridViewActionButtonColumn():base(Resources.BtnModify, Resources.BtnModify02, Resources.BtnDelete, Resources.BtnDelete02)
        {
            HeaderText = "操作";
        }
    }
}