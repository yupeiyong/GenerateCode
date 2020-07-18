using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.UI;

namespace GenerateCode
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 全局异常注册
            ApplicationEventHandlerClass appEvents = new ApplicationEventHandlerClass();
            Application.ThreadException += new ThreadExceptionEventHandler(appEvents.OnThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIParent1());
        }

        // 全局异常处理
        public class ApplicationEventHandlerClass
        {
            public void OnThreadException(object sender, ThreadExceptionEventArgs e)
            {
                FormSysMessage.ShowException(e.Exception); // 调用FormSysMessage窗体，显示异常信息。
            }
        }

    }
}
