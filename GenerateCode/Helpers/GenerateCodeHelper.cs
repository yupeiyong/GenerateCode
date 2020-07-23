using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Winform.Models;

namespace Winform.Helpers
{
    public class GenerateCodeHelper
    {
        public static string GenerateCode(string modelFileName, List<GenerateSettings> settings)
        {
            var root = AppDomain.CurrentDomain.BaseDirectory + @"\Temps";
            var rootDir = new DirectoryInfo(root);
            if (!rootDir.Exists)
                rootDir.Create();

            var fInfo = new FileInfo(modelFileName);
            if (!fInfo.Exists)
                throw new Exception($"{modelFileName}文件不存在！");

            var shortName = fInfo.Name;
            //类名
            var className = shortName.Replace(fInfo.Extension, "");
            //类名首字母小写
            var firstLowerClassName = className.Substring(0, 1).ToLower() + className.Substring(1);

            var content = File.ReadAllText(modelFileName);
            //类型描述，一般是中文，如果没有就使用类名
            var classDescription = className;
            var match = Regex.Match(content, @"\[Description\(" + "\"(.*)\"" + @"\)\]\s*\r\n\s*public\s*class");
            if (match.Success)
            {
                classDescription = match.Groups[1].Value;
            }
            //命名空间
            var modelNameSpace = string.Empty;
            var nameSpaceMatch = Regex.Match(content, @"namespace\s{1,3}(.*)");
            if (nameSpaceMatch.Success)
            {
                modelNameSpace = nameSpaceMatch.Groups[1].Value.Trim();
            }
            //命名空间去掉根，如Service.Prodcut=>Product
            var noRootNameSpace = modelNameSpace;
            if (noRootNameSpace.Contains("."))
            {
                var index = noRootNameSpace.IndexOf(".");
                noRootNameSpace = noRootNameSpace.Substring(index + 1);
            }
            //字段正则匹配
            var fieldParterrn = @"(/// <summary>\s*\r\n\s*///\s*(.*)\s*/// </summary>\s*.)?public\s*([A-Za-z0-9]*\??)\s*([A-Za-z0-9]*)\s*{\s*get;.*";
            var fieldMatchs = Regex.Matches(content, fieldParterrn);
            var fieldParameters = new List<ModelFieldParameters>();
            foreach (Match m in fieldMatchs)
            {
                if (m.Success)
                {
                    var parameter = new ModelFieldParameters
                    {
                        Annotation = m.Groups[2].Value.Replace("\r", "").Replace("\n", ""),
                        FieldType = m.Groups[3].Value,
                        Name = m.Groups[4].Value
                    };
                    fieldParameters.Add(parameter);
                }
            }

            var result = new StringBuilder();
            foreach (var setting in settings)
            {
                var tempContent = File.ReadAllText(Path.Combine(root, setting.TemplateFileName));
                //读取路径设置
                var pathBeginIndex = tempContent.IndexOf("<##save_FilePath_Begin##>");
                var pathEndIndex = tempContent.IndexOf("<##save_FilePath_End##>");
                if (pathBeginIndex < 0 || pathEndIndex <= 0)
                {
                    throw new Exception($"{setting.TemplateFileName},路径的开始和结束标志没有设置！");
                }
                //读取路径
                var path = tempContent.Substring(pathBeginIndex + "<##save_FilePath_Begin##>".Length, pathEndIndex - (pathBeginIndex + "<##save_FilePath_Begin##>".Length));

                var destFileName = path.Replace("<##Model_Class_Name##>", className).
                    Replace("<##model_Class_Name##>", firstLowerClassName).
                    Replace(".<##Model_Namespace_Not_Root##>", noRootNameSpace.Replace(".", @"\")).
                    Replace("<##Model_Namespace_Not_Root##>", noRootNameSpace.Replace(".", @"\"));

                //文件存在，并且不允许覆盖，不执行生成
                if (File.Exists(destFileName) && !setting.OverWrite)
                    continue;

                var dInfo=new FileInfo(destFileName);
                var dir = dInfo.Directory;
                if(!dir.Exists)
                    dir.Create();

                var tempBeginIndex = tempContent.IndexOf("<##template_Begin##>");
                var tempEndIndex = tempContent.IndexOf("<##template_End##>");
                if (tempBeginIndex < 0 || tempEndIndex <= 0)
                {
                    throw new Exception($"{setting.TemplateFileName},模板的开始和结束标志没有设置！");
                }

                tempContent = tempContent.Substring(tempBeginIndex + "<##template_Begin##>".Length, tempEndIndex-(tempBeginIndex + "<##template_Begin##>".Length));
                tempContent = tempContent.Replace("<##Model_Class_Name##>", className).Replace("<##Model_Class_Name##>", firstLowerClassName).Replace("<##Model_Description##>", classDescription);

                var fieldStartIndex = tempContent.IndexOf("<##field_Write_Begin##>");
                if (fieldStartIndex >= 0)
                {
                    var fieldEndIndex = tempContent.IndexOf("<##field_Write_End##>");
                    if (fieldEndIndex <= 0)
                        throw new Exception("字段写入没有结束标志！");

                    var nextIndex = fieldEndIndex + "<##field_Write_End##>".Length;
                    var fieldTempContent = tempContent.Substring(fieldStartIndex, nextIndex - fieldStartIndex);

                    var newFieldTempContent = fieldTempContent.Replace("<##field_Write_Begin##>", "").Replace("<##field_Write_End##>", "");
                    var sb = new StringBuilder();
                    foreach (var fParameter in fieldParameters)
                    {
                        sb.Append(GetFieldContent(newFieldTempContent, fParameter, className));
                    }

                    tempContent = tempContent.Replace(fieldTempContent, sb.ToString());
                }
                File.WriteAllText(destFileName, tempContent, Encoding.UTF8);
                result.AppendLine($"{destFileName}生成成功！");
            }

            return result.ToString();
        }

        private static string GetFieldContent(string temp, ModelFieldParameters parameter, string className)
        {
            var str = temp.Replace("<##field_Annotation##>", parameter.Annotation);
            str = str.Replace("<##field_Name##>", parameter.Name);
            str = str.Replace("<##Model_Class_Name##>", className);
            if (str.Contains("<##html_Field_Type##>"))
            {
                switch (parameter.FieldType)
                {
                    case "long":
                    case "int":
                    case "short":
                    case "double":
                    case "float":
                    case "long?":
                    case "int?":
                    case "short?":
                    case "double?":
                    case "float?":
                        str = str.Replace("<##html_Field_Type##>", "number");
                        break;
                    case "DateTime":
                    case "DateTime?":
                        str = str.Replace("<##html_Field_Type##>", "datetime");
                        break;
                    default:
                        str = str.Replace("<##html_Field_Type##>", "text");
                        break;
                }
            }

            if (str.Contains("<##field_Type##>"))
            {
                str = str.Replace("<##field_Type##>", parameter.FieldType);
            }

            return str;
        }

    }
}
