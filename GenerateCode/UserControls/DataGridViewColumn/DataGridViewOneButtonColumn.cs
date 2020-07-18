using System.Drawing;
using System.Windows.Forms;

namespace Winform.UserControls.DataGridViewColumn
{
    /// <summary>
    ///     对象名称：DataGridView操作按钮列（查看详细）
    ///     对象说明：通过本类可以实现，在DataGridView控件中，显示一个图片按钮的列。
    /// </summary>
    public class DataGridViewOneButtonColumn : System.Windows.Forms.DataGridViewColumn
    {
        public DataGridViewOneButtonColumn(Bitmap cellButtonBitmap,Bitmap cellButtonMouseOverBitmap)
        {
            CellTemplate = new DataGridViewOneButtonCell(cellButtonBitmap, cellButtonMouseOverBitmap);
        }
    }

    /// <summary>
    ///     DataGridView操作按钮单元格，继承自DataGridViewButtonCell类。使用本自定义列或单元格前。
    /// </summary>
    public class DataGridViewOneButtonCell : DataGridViewButtonCell
    {
        private static Image _imgButton;
        private static Pen _penButton = new Pen(Color.FromArgb(135, 163, 193)); // 按钮边框颜色
        private static int _nowColIndex; // 当前列序号
        private static int _nowRowIndex; // 当前行序号
        private bool _mouseOnButton; // 鼠标是否移动到按钮上

        public DataGridViewOneButtonCell()
        {
        }
        public DataGridViewOneButtonCell(Bitmap btnBitmap, Bitmap btnButtonMouseOverBitmap)
        {
            ButtonBitmap = btnBitmap;
            ButtonMouseOverBitmap = btnButtonMouseOverBitmap;
            _imgButton = btnBitmap;
        }

        private static Image ButtonBitmap { get; set; } // 按钮背景图片
        private static Image ButtonMouseOverBitmap { get; set; } // 鼠标移动到按钮时的背景图片


        /// <summary>
        ///     对单元格的重绘事件进行的方法重写。
        /// </summary>
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates cellState,
            object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            cellBounds = PrivatePaint(graphics, cellBounds, rowIndex, cellStyle, true);
            PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            _nowColIndex = DataGridView.Columns.Count - 1;
        }

        /// <summary>
        ///     私有的单元格重绘方法，根据鼠标是否移动到按钮上，对按钮的不同背景和边框进行绘制。
        /// </summary>
        private Rectangle PrivatePaint(Graphics graphics, Rectangle cellBounds, int rowIndex,
            DataGridViewCellStyle cellStyle, bool clearBackground)
        {
            if (_mouseOnButton) // 鼠标移动到查看详细按钮上，更换背景及边框颜色
            {
                _imgButton = ButtonMouseOverBitmap;
                _penButton = new Pen(Color.FromArgb(162, 144, 77));
            }
            else
            {
                _imgButton = ButtonBitmap;
                _penButton = new Pen(Color.FromArgb(135, 163, 193));
            }


            if (clearBackground) // 是否需要重绘单元格的背景颜色
            {
                //Brush brushCellBack = (rowIndex == DataGridView.CurrentRow.Index)
                //    ? new SolidBrush(cellStyle.SelectionBackColor)
                //    : new SolidBrush(cellStyle.BackColor);
                //graphics.FillRectangle(brushCellBack, cellBounds.X + 1, cellBounds.Y + 1, cellBounds.Width - 2,
                //    cellBounds.Height - 2);

                //单元格背景色，保持原来颜色
                Brush brushCellBack = new SolidBrush(cellStyle.BackColor);
                graphics.FillRectangle(brushCellBack, cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height);
            }

            var recDetail = new Rectangle(
                cellBounds.GetCenterImagePositionX(_imgButton.Width),
                cellBounds.GetCenterImagePositionY(_imgButton.Height),
                _imgButton.Width,
                _imgButton.Height);

            graphics.DrawImage(_imgButton, recDetail);
            graphics.DrawRectangle(_penButton, recDetail.X, recDetail.Y - 1, recDetail.Width, recDetail.Height);
            return cellBounds;
        }

        /// <summary>
        ///     鼠标移动到单元格内时的事件处理，通过坐标判断鼠标是否移动到了修改或删除按钮上，并调用私有的重绘方法进行重绘。
        /// </summary>
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
            if (DataGridView == null) return;

            _nowColIndex = e.ColumnIndex;
            _nowRowIndex = e.RowIndex;

            var cellBounds = DataGridView[e.ColumnIndex, e.RowIndex].ContentBounds;
            var recDetail = new Rectangle(
                cellBounds.GetCenterImagePositionX(_imgButton.Width),
                cellBounds.GetCenterImagePositionY(_imgButton.Height),
                _imgButton.Width,
                _imgButton.Height);

            var paintCellBounds = DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            paintCellBounds.Width = DataGridView.Columns[_nowColIndex].Width;
            paintCellBounds.Height = DataGridView.Rows[_nowRowIndex].Height;

            if (recDetail.IsInRect(e.X, e.Y)) // 鼠标移动到查看详细按钮上
            {
                if (!_mouseOnButton)
                {
                    _mouseOnButton = true;
                    PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex,
                        DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Hand;
                }
            }
            else
            {
                if (_mouseOnButton)
                {
                    _mouseOnButton = false;
                    PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex,
                        DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        ///     鼠标从单元格内移出时的事件处理，调用私有的重绘方法进行重绘。
        /// </summary>
        protected override void OnMouseLeave(int rowIndex)
        {
            if (_mouseOnButton)
            {
                _mouseOnButton = false;

                var paintCellBounds = DataGridView.GetCellDisplayRectangle(_nowColIndex, _nowRowIndex, true);

                paintCellBounds.Width = DataGridView.Columns[_nowColIndex].Width;
                paintCellBounds.Height = DataGridView.Rows[_nowRowIndex].Height;

                PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, _nowRowIndex,
                    DataGridView.RowTemplate.DefaultCellStyle, false);
                DataGridView.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        ///     判断用户是否单击了查看详细按钮，DataGridView发生CellMouseClick事件时，
        ///     本方法通过坐标判断用户是否单击了按钮。
        /// </summary>
        public static bool IsButtonClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return false;
            var view = sender as DataGridView;
            var dgvGrid = view;
            if (dgvGrid?.Columns[e.ColumnIndex] is DataGridViewOneButtonColumn)
            {
                var cellBounds = dgvGrid[e.ColumnIndex, e.RowIndex].ContentBounds;
                var recDetail = new Rectangle(
                    cellBounds.GetCenterImagePositionX(_imgButton.Width),
                    cellBounds.GetCenterImagePositionY(_imgButton.Height),
                    _imgButton.Width,
                    _imgButton.Height);

                if (recDetail.IsInRect(e.X, e.Y))
                    return true;
            }
            return false;
        }
    }
}