using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace org.millions.idea.ccdl.utiltiy
{
    public class CmdUtil
    {
        private static StringBuilder sortOutput = null;
        private static Process sortProcess;


        public static string Execute(String cmdLine)
        {
            System.Diagnostics.Process pro = new System.Diagnostics.Process();
            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.Arguments = "/c " + cmdLine;    //设定程式执行参数
            pro.StartInfo.UseShellExecute = false;  //这两个设置可以将输出内容返回
            pro.StartInfo.RedirectStandardError = true; //重定向错误输出
            pro.StartInfo.RedirectStandardInput = true;//重定向标准输入
            pro.StartInfo.RedirectStandardOutput = true;//这两个设置可以将输出内容返回
            pro.StartInfo.CreateNoWindow = true;  //设置不显示窗口
           // pro.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pro.Start();
           // pro.WaitForExit();
           // pro.StandardInput.WriteLine(命令);
           // pro.StandardInput.WriteLine("exit");
            return pro.StandardOutput.ReadToEnd(); 
        }

        public static void Call(IList<String> cmdLine, Action<object, DataReceivedEventArgs> func)
        {
            if (sortProcess != null)
            {
                sortProcess.Close();
            }
            sortProcess = new Process();
            sortOutput = new StringBuilder("");
            sortProcess.StartInfo.FileName = "cmd.exe";
            sortProcess.StartInfo.UseShellExecute = false;// 必须禁用操作系统外壳程序  
            sortProcess.StartInfo.RedirectStandardOutput = true;
            sortProcess.StartInfo.RedirectStandardError = true; //重定向错误输出
            sortProcess.StartInfo.CreateNoWindow = true;  //设置不显示窗口
            sortProcess.StartInfo.RedirectStandardInput = true;
            //sortProcess.StartInfo.Arguments = "/c " + cmdLine;    //设定程式执行参数
            sortProcess.Start();
            foreach (var item in cmdLine)
            {
                sortProcess.StandardInput.WriteLine(item);
            }

            sortProcess.BeginOutputReadLine();// 异步获取命令行内容  
            sortProcess.OutputDataReceived += new DataReceivedEventHandler(func); // 为异步获取订阅事件  
        }



        public static void Call( Action<Process, StringBuilder> func)
        {
            if (sortProcess != null)
            {
                sortProcess.Close();
            }
            sortProcess = new Process();
            sortOutput = new StringBuilder("");
            sortProcess.StartInfo.FileName = "cmd.exe";
            sortProcess.StartInfo.UseShellExecute = false;// 必须禁用操作系统外壳程序  
            sortProcess.StartInfo.RedirectStandardOutput = true;
            sortProcess.StartInfo.RedirectStandardError = true; //重定向错误输出
            sortProcess.StartInfo.CreateNoWindow = true;  //设置不显示窗口
            sortProcess.StartInfo.RedirectStandardInput = true;
            func(sortProcess, sortOutput);
            //sortProcess.StartInfo.Arguments = "/c " + cmdLine;    //设定程式执行参数
            
        }
    }
}
