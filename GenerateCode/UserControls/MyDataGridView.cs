using System.Drawing;
using System.Windows.Forms;

namespace Winform.UserControls
{

    public class MyDataGridView : DataGridView
    {

        public MyDataGridView()
        {
            //设置双缓冲减少控件闪烁
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }


        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);

            //当前行的矩形位置
            var rec1 = e.RowBounds;

            //获取写入行号的矩形位置
            var rec = new Rectangle(rec1.Location.X, rec1.Location.Y, RowHeadersWidth - 4, rec1.Height);

            //画布
            var g = e.Graphics;

            //行号
            var rowNum = (e.RowIndex + 1).ToString();

            //字体
            var f = RowHeadersDefaultCellStyle.Font;

            //字体颜色
            var c = RowHeadersDefaultCellStyle.ForeColor;

            //对齐方式为垂直居中+靠右
            var flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Right;

            //画上行号
            TextRenderer.DrawText(g, rowNum, f, rec, c, flags);
        }

    }

}