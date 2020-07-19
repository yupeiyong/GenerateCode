using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Helpers
{
    public class OpenFile
    {
        public static void Open(string filePath)
        {
            //声明一个程序信息类
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();

            //设置外部程序名
            Info.FileName = "notepad.exe";

            //设置外部程序的启动参数(命令行参数)为test.txt
            Info.Arguments = filePath;

            ////设置外部程序工作目录为  C:\
            //Info.WorkingDirectory = "C:\\";

            //声明一个程序类
            System.Diagnostics.Process Proc;

            try
            {
                //
                //启动外部程序
                //
                Proc = System.Diagnostics.Process.Start(Info);
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                Console.WriteLine("系统找不到指定的程序文件.\r{0}", e);
                return;
            }
        }
    }
}
