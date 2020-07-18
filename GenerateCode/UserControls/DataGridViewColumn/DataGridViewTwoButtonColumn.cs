using System.Drawing;
using System.Windows.Forms;
using Winform.Properties;

namespace Winform.UserControls.DataGridViewColumn
{
    /// <summary>
    ///     对象名称：DataGridView操作按钮列（修改、删除）
    ///     对象说明：通过本类可以实现，在DataGridView控件中，显示一个分别包含修改和删除两个图片按钮的列。
    ///     编写日期：2010/06/20 03:15:28
    /// </summary>
    public class DataGridViewTwoButtonColumn : System.Windows.Forms.DataGridViewColumn
    {
        public DataGridViewTwoButtonColumn(Bitmap leftBtnBitmap, Bitmap leftBtnMouseOverBitmap, Bitmap rightBtnBitmap, Bitmap rightBtnMouseOverBitmap)
        {
            CellTemplate = new DataGridViewTwoButtonCell(leftBtnBitmap,leftBtnMouseOverBitmap,rightBtnBitmap,rightBtnMouseOverBitmap);
        }
    }

    /// <summary>
    ///     DataGridView操作按钮单元格，继承自DataGridViewButtonCell类。使用本自定义列或单元格前，请确保包含了4张图片。
    /// </summary>
    internal class DataGridViewTwoButtonCell : DataGridViewButtonCell
    {
        private static Image _leftBtnImage = Resources.BtnModify; // 左按钮背景图片
        private static Image _rightBtnImage = Resources.BtnDelete; // 右按钮背景图片

        private static Pen _leftBtnPen = new Pen(Color.FromArgb(135, 163, 193)); // 左按钮边框颜色
        private static Pen _rightBtnPen = new Pen(Color.FromArgb(162, 144, 77)); // 右按钮边框颜色

        private static int _nowColIndex; // 当前列序号
        private static int _nowRowIndex; // 当前行序号
        private bool _mouseOnRightButton; // 鼠标是否移动到右按钮上
        private bool _mouseOnLeftButton; // 鼠标是否移动到左按钮上

        private static Image LeftButtonBitmap { get; set; } // 左按钮背景图片
        private static Image LeftButtonMouseOverBitmap { get; set; } // 鼠标移动到左按钮时的背景图片

        private static Image RightButtonBitmap { get; set; } // 右按钮背景图片
        private static Image RightButtonMouseOverBitmap { get; set; } // 鼠标移动到右按钮时的背景图片

        public DataGridViewTwoButtonCell()
        {
        }

        public DataGridViewTwoButtonCell(Bitmap leftBtnBitmap,Bitmap leftBtnMouseOverBitmap,Bitmap rightBtnBitmap,Bitmap rightBtnMouseOverBitmap)
        {
            LeftButtonBitmap = leftBtnBitmap;
            LeftButtonMouseOverBitmap = leftBtnMouseOverBitmap;
            _leftBtnImage = leftBtnBitmap;

            RightButtonBitmap = rightBtnBitmap;
            RightButtonMouseOverBitmap = rightBtnMouseOverBitmap;
            _rightBtnImage = rightBtnBitmap;
        }
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
            if (_mouseOnLeftButton) // 鼠标移动到左按钮上，更换背景及边框颜色
            {
                _leftBtnImage = LeftButtonMouseOverBitmap;
                _leftBtnPen = new Pen(Color.FromArgb(162, 144, 77));
            }
            else
            {
                _leftBtnImage =LeftButtonBitmap;
                _leftBtnPen = new Pen(Color.FromArgb(135, 163, 193));
            }

            if (_mouseOnRightButton) // 鼠标移动到右按钮上，更换背景及边框颜色
            {
                _rightBtnImage = RightButtonMouseOverBitmap;
                _rightBtnPen = new Pen(Color.FromArgb(162, 144, 77));
            }
            else
            {
                _rightBtnImage = RightButtonBitmap;
                _rightBtnPen = new Pen(Color.FromArgb(135, 163, 193));
            }

            if (clearBackground) // 是否需要重绘单元格的背景颜色
            {
                //Brush brushCellBack = (rowIndex == this.DataGridView.CurrentRow.Index) ? new SolidBrush(cellStyle.SelectionBackColor) : new SolidBrush(cellStyle.BackColor);
                //graphics.FillRectangle(brushCellBack, cellBounds.X + 1, cellBounds.Y + 1, cellBounds.Width - 2, cellBounds.Height - 2);

                //单元格背景色，保持原来颜色
                Brush brushCellBack = new SolidBrush(cellStyle.BackColor);
                graphics.FillRectangle(brushCellBack, cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height);
            }

            var recModify = new Rectangle(
                cellBounds.GetLeftImagePositionX(_leftBtnImage.Width,_rightBtnImage.Width),
                cellBounds.GetCenterImagePositionY(_leftBtnImage.Height),
                _leftBtnImage.Width,
                _leftBtnImage.Height);

            var recDelete = new Rectangle(
                cellBounds.GetRightImagePositionX(_leftBtnImage.Width, _rightBtnImage.Width),
                cellBounds.GetCenterImagePositionY(_rightBtnImage.Height),
                _rightBtnImage.Width, 
                _rightBtnImage.Height);

            graphics.DrawImage(_leftBtnImage, recModify);
            graphics.DrawImage(_rightBtnImage, recDelete);

            graphics.DrawRectangle(_leftBtnPen, recModify.X, recModify.Y - 1, recModify.Width, recModify.Height);
            graphics.DrawRectangle(_rightBtnPen, recDelete.X, recDelete.Y - 1, recDelete.Width, recDelete.Height);
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
            var recLeft = new Rectangle(
                cellBounds.GetLeftImagePositionX(_leftBtnImage.Width, _rightBtnImage.Width),
                cellBounds.GetCenterImagePositionY(_leftBtnImage.Height),
                _leftBtnImage.Width,
                _leftBtnImage.Height);

            var recRight = new Rectangle(
                cellBounds.GetRightImagePositionX(_leftBtnImage.Width, _rightBtnImage.Width),
                cellBounds.GetCenterImagePositionY(_rightBtnImage.Height),
                _rightBtnImage.Width,
                _rightBtnImage.Height);

            var paintCellBounds = DataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            paintCellBounds.Width = DataGridView.Columns[_nowColIndex].Width;
            paintCellBounds.Height = DataGridView.Rows[_nowRowIndex].Height;

            if (recLeft.IsInRect(e.X, e.Y)) // 鼠标移动到左按钮上
            {
                if (!_mouseOnLeftButton)
                {
                    _mouseOnLeftButton = true;
                    PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex,
                        DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Hand;
                }
            }
            else
            {
                if (_mouseOnLeftButton)
                {
                    _mouseOnLeftButton = false;
                    PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex,
                        DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Default;
                }
            }


            if (recRight.IsInRect(e.X, e.Y)) // 鼠标移动到到右按钮上
            {
                if (!_mouseOnRightButton)
                {
                    _mouseOnRightButton = true;
                    PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, e.RowIndex,
                        DataGridView.RowTemplate.DefaultCellStyle, false);
                    DataGridView.Cursor = Cursors.Hand;
                }
            }
            else
            {
                if (_mouseOnRightButton)
                {
                    _mouseOnRightButton = false;
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
            if (_mouseOnLeftButton || _mouseOnRightButton)
            {
                _mouseOnLeftButton = false;
                _mouseOnRightButton = false;

                var paintCellBounds = DataGridView.GetCellDisplayRectangle(_nowColIndex, _nowRowIndex, true);

                paintCellBounds.Width = DataGridView.Columns[_nowColIndex].Width;
                paintCellBounds.Height = DataGridView.Rows[_nowRowIndex].Height;

                PrivatePaint(DataGridView.CreateGraphics(), paintCellBounds, _nowRowIndex,
                    DataGridView.RowTemplate.DefaultCellStyle, false);
                DataGridView.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        ///     判断用户是否单击了左按钮，DataGridView发生CellMouseClick事件时，
        ///     因本单元格中有两个按钮，本方法通过坐标判断用户是否单击了左按钮。
        /// </summary>
        public static bool IsLeftButtonClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return false;
            if (sender is DataGridView)
            {
                var dgvGrid = (DataGridView) sender;
                if (dgvGrid.Columns[e.ColumnIndex] is DataGridViewTwoButtonColumn)
                {
                    var cellBounds = dgvGrid[e.ColumnIndex, e.RowIndex].ContentBounds;
                    var recLeft = new Rectangle(
                        cellBounds.GetLeftImagePositionX(_leftBtnImage.Width, _rightBtnImage.Width),
                        cellBounds.GetCenterImagePositionY(_leftBtnImage.Height),
                        _leftBtnImage.Width,
                        _leftBtnImage.Height);

                    if (recLeft.IsInRect(e.X, e.Y))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     判断用户是否单击了右按钮，DataGridView发生CellMouseClick事件时，
        ///     因本单元格中有两个按钮，本方法通过坐标判断用户是否单击了右按钮。
        /// </summary>
        public static bool IsRightButtonClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return false;
            if (sender is DataGridView)
            {
                var dgvGrid = (DataGridView) sender;
                if (dgvGrid.Columns[e.ColumnIndex] is DataGridViewTwoButtonColumn)
                {
                    var cellBounds = dgvGrid[e.ColumnIndex, e.RowIndex].ContentBounds;
                    var recRight = new Rectangle(
                        cellBounds.GetRightImagePositionX(_leftBtnImage.Width, _rightBtnImage.Width),
                        cellBounds.GetCenterImagePositionY(_rightBtnImage.Height),
                        _rightBtnImage.Width,
                        _rightBtnImage.Height);

                    if (recRight.IsInRect(e.X, e.Y))
                        return true;
                }
            }
            return false;
        }
    }
}