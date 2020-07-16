using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace PythonExecuteBP
{
    class Program
    {
   
        static void Main(string[] args)
        {

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                }
            };


            process.Start();
            
            // Pass multiple commands to cmd.exe
            var sw = process.StandardInput;
                                   
            // I use Anaconda here. Or better to switch to IronPython?
            sw.WriteLine("cd C:\\Users\\Admin\\Anaconda3\\Scripts");
            // Activate a certain env: choose from 'conda info --env'
            var env_str = "base";
            sw.WriteLine("activate.bat");
            sw.WriteLine("activate {0}", env_str);

            // Execute a script
            sw.WriteLine("python C:\\Users\\Admin\\source\\repos\\PythonExecuteBP\\PythonExecuteBP\\test.py");
              
            

             //read multiple output lines
           while (!process.StandardOutput.EndOfStream)
            {
                var line = process.StandardOutput.ReadLine();
                Console.WriteLine(line);
                if (line.Contains("End of processing"))
                {
                    Console.WriteLine("");
                    Console.ReadLine();
                    sw.Close();
                }

                
                //Console.WriteLine("expected output is 0.78041");
            }
           
        }
    }
}
