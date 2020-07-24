using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Models
{
    /// <summary>
    /// 数据模型的参数
    /// </summary>
    public class ModelParameter
    {
        /// <summary>
        /// 模型类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 模型的描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 首字母小写的类名
        /// </summary>
        public string FirstLowerModelName => ClassName.Substring(0, 1).ToLower() + ClassName.Substring(1);

        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }

        public string NoRootNameSpace { get; set; }


        /// <summary>
        /// 字段
        /// </summary>
        public List<ModelFieldParameters> FieldParameterses { get; set; }
    }
}
