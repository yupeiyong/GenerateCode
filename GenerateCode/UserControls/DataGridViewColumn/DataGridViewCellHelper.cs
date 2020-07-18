using System.Drawing;

namespace Winform.UserControls.DataGridViewColumn
{
    public static class DataGridViewCellHelper
    {
        /// <summary>
        ///     取在矩形框中图片居中时的X值
        ///     请确保单元格宽度大于图片宽度
        /// </summary>
        /// <param name="cellBound"></param>
        /// <param name="imageWidth"></param>
        /// <returns></returns>
        public static int GetCenterImagePositionX(this Rectangle cellBound, int imageWidth)
        {
            return cellBound.Location.X + (cellBound.Width - imageWidth) / 2;
        }

        /// <summary>
        ///     取在矩形框中图片居中时的Y值
        /// </summary>
        /// <param name="cellBound"></param>
        /// <param name="imageHeight"></param>
        /// <returns></returns>
        public static int GetCenterImagePositionY(this Rectangle cellBound, int imageHeight)
        {
            return cellBound.Location.Y + (cellBound.Height - imageHeight) / 2;
        }

        ///// <summary>
        /////     取在矩形框中左边图片左边居中时的X值
        /////     请确保单元格宽度大于图片宽度
        ///// </summary>
        ///// <param name="cellBound"></param>
        ///// <param name="imageWidth"></param>
        ///// <returns></returns>
        //public static int GetLeftImagePositionX(this Rectangle cellBound, int imageWidth)
        //{
        //    return cellBound.Location.X + cellBound.Width/2 - imageWidth - 2;
        //}

        ///// <summary>
        /////     取在矩形框中右边图片右边居中时的X值
        /////     请确保单元格宽度大于图片宽度
        ///// </summary>
        ///// <param name="cellBound"></param>
        ///// <param name="imageWidth"></param>
        ///// <returns></returns>
        //public static int GetRightImagePositionX(this Rectangle cellBound, int imageWidth)
        //{
        //    return cellBound.Location.X + cellBound.Width/2 + 2;
        //}

        /// <summary>
        ///     取在矩形框中左边图片左边居中时的X值
        ///     请确保单元格宽度大于图片宽度
        /// </summary>
        /// <param name="cellBound"></param>
        /// <param name="leftImageWidth"></param>
        /// <param name="rightImageWidth"></param>
        /// <returns></returns>
        public static int GetLeftImagePositionX(this Rectangle cellBound, int leftImageWidth, int rightImageWidth)
        {
            //两张图片宽度+图片之间的间隔
            var imgTotalWidth = leftImageWidth + rightImageWidth + 2 * 2;
            return cellBound.Location.X + (cellBound.Width - imgTotalWidth) / 2;
        }

        /// <summary>
        ///     取在矩形框中右边图片右边居中时的X值
        ///     请确保单元格宽度大于图片宽度
        /// </summary>
        /// <param name="cellBound"></param>
        /// <param name="leftImageWidth"></param>
        /// <param name="rightImageWidth"></param>
        /// <returns></returns>
        public static int GetRightImagePositionX(this Rectangle cellBound, int leftImageWidth, int rightImageWidth)
        {
            //两张图片宽度+图片之间的间隔
            var imgTotalWidth = leftImageWidth + rightImageWidth + 2 * 2;
            //左边图片离单元格距离+图片宽度+左右图片间隔
            return cellBound.Location.X + (cellBound.Width - imgTotalWidth) / 2 + leftImageWidth + 4;
        }

        /// <summary>
        ///     判断鼠标坐标是否在指定的区域内。
        /// </summary>
        public static bool IsInRect(this Rectangle area, int x, int y)
        {
            if (x > area.Left && x < area.Right && y > area.Top && y < area.Bottom)
                return true;
            return false;
        }
    }
}