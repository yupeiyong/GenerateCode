using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform.Helpers
{
    public static class DataGridViewHelper
    {
        /// <summary>
        ///     将集合转换为数据表
        /// </summary>
        /// <typeparam name="T">绑定到DataGridView的模型</typeparam>
        /// <param name="dgv"></param>
        /// <param name="ignoreColumns">忽略的列名</param>
        /// <returns></returns>
        public static void SetColumns<T>(DataGridView dgv, List<string> ignoreColumns) where T : class
        {
            var type = typeof(T);
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var properties = ignoreColumns != null
                ? type.GetProperties(flags).Where(p => ignoreColumns.All(c => c != p.Name)).ToList()
                : type.GetProperties(flags).ToList();

            dgv.Columns.Clear();
            var columns = new SortedList<int, DataGridViewColumn>();
            for (var i = 0; i < properties.Count; i++)
            {
                var property = properties[i];

                var descriptionAttribute = property.GetCustomAttribute<DescriptionAttribute>();

                //列头
                var headerText = descriptionAttribute == null ? property.Name : descriptionAttribute.Description;

                var order = i;
                columns.Add(order,
                    new DataGridViewTextBoxColumn
                    {
                        Name = "Col" + property.Name,
                        DataPropertyName = property.Name,
                        HeaderText = headerText
                    });
            }

            dgv.Columns.AddRange(columns.Values.ToArray());
        }

        /// <summary>
        /// 自动适应列宽
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="ignoreColumns"></param>
        public static void AutoSizeColumns(this DataGridView dgv, List<string> ignoreColumns)
        {
            if (dgv == null || dgv.Columns.Count == 0) return;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (ignoreColumns.Any(c => c == col.Name))
                    continue;

                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }
    }
}
