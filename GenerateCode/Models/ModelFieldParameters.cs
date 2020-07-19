using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Models
{
    /// <summary>
    /// 数据模型的字段参数
    /// </summary>
    public class ModelFieldParameters
    {
        /// <summary>
        /// 字段类型，如：int、string
        /// </summary>
        public string FieldType { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public string Annotation { get; set; }
    }
}
