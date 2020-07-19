﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Models
{
    public class GenerateSettings
    {
        /// <summary>
        /// 模板文件名
        /// </summary>
        public string TemplateFileName { get; set; }

        /// <summary>
        /// 生成到的目标文件夹
        /// </summary>
        public string DestPath { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string Extention { get; set; }

        /// <summary>
        /// 如果存在文件，是否覆盖
        /// </summary>
        public bool OverWrite { get; set; }

        /// <summary>
        /// 是否生成代码
        /// </summary>
        public bool IsGenerate { get; set; }
    }
}
