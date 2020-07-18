using Winform.Properties;
using WinForm.UI.UserControls.DataGridViewColumn;

namespace Winform.UserControls.DataGridViewColumn
{
    /// <summary>
    /// 对象名称：DataGridView操作按钮列（查看详细）
    /// 对象说明：通过本类可以实现，在DataGridView控件中，显示一个名为“查看详细”图片按钮的列。
    /// </summary>
    public sealed class DataGridViewDetailButtonColumn : DataGridViewOneButtonColumn
    {
        public DataGridViewDetailButtonColumn():base(Resources.BtnView, Resources.BtnView02)
        {
            this.HeaderText = "操作";
        }
    }
}
