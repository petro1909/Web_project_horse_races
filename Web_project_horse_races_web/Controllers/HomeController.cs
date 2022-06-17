using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Web_project_horse_races_web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        static string GetCurrentProcesses()
        {
            Thread.Sleep(10000);
            var currProcess = Process.GetCurrentProcess();
            return $"-> PID: {currProcess.Id}\tName: {currProcess.ProcessName}\n" + GetProcess(currProcess) + GetThreads(currProcess);
        }

        static StringBuilder GetProcess(Process p)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                result.Append($"\tProcess {p.Id}\n {p.ProcessName}\n {p.MachineName}\n {p.MainModule}\n");
                result.Append("\tProcess Modules :");
                foreach (ProcessModule m in p.Modules)
                {
                    result.Append($"\t\tFile Name: {m.FileName} Base Address: {m.BaseAddress} Memory Size: {m.ModuleMemorySize} Module Name: {m.ModuleName}\n");
                }
                return result;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Such process does not exist {e.Message}");
                return default;
            }
            catch (Win32Exception e)
            {
                Console.WriteLine($"Can't work with {p.ProcessName} {e.Message}");
                return default;
            }
        }
        static StringBuilder GetThreads(Process p)
        {
            StringBuilder result = new StringBuilder();
            foreach (ProcessThread t in p.Threads)
            {
                result.Append($"\t\tId: {t.Id} State: {t.ThreadState} Priority: {t.CurrentPriority} StartAddress {t.StartAddress} Start Time {t.StartTime}");
            }
            return result;
        }

        public static StringBuilder DisplayDADStats()
        {
            StringBuilder result = new StringBuilder();
            AppDomain defaultAD = AppDomain.CurrentDomain;
            result.Append($"Name of this domain {defaultAD.FriendlyName}\n" +
                $"ID of domain in this process {defaultAD.Id}\n" +
                $"Is this the default domain? {defaultAD.IsDefaultAppDomain()}\n" +
                $"Base directory of this domain {defaultAD.BaseDirectory}\n");
            //foreach (Assembly ass in defaultAD.GetAssemblies())
            //{
            //    //result.Append($"\t FullName: {ass.FullName}, Location: {ass.Location}");
            //    foreach (Type t in ass.ExportedTypes)
            //    {
            //        result.Append($"\t\t{t.FullName}");
            //    }
            //}
            return result;
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
