using MSI.Afterburner;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace DeveGpuFanSpeedController
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Gogo(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex}");
            }
        }

        public static void Gogo(string[] args)
        {
            if (args.Length == 1)
            {
                SetFanSpeed(args.First());
            }
            else if (args.Length == 2)
            {
                SetFanSpeed(args.First());

                var processName = args[1];

                int maxWaitForProcessStart = 10;
                bool processStarted = false;
                while (!(processStarted = Process.GetProcessesByName(processName).Any()) && maxWaitForProcessStart > 0)
                {
                    Thread.Sleep(1000);
                    maxWaitForProcessStart--;
                    Console.WriteLine($"Waiting for process {processName} to start... Seconds remaining: {maxWaitForProcessStart}");
                }

                if (processStarted)
                {
                    Console.WriteLine($"Process {processName} is running. Waiting for it to exit...");
                }

                while (Process.GetProcessesByName(processName).Any())
                {
                    Thread.Sleep(1000);
                }

                Console.WriteLine($"Process {processName} exited.");

                SetFanSpeed("auto");
            }
            else
            {
                DisplayError();
            }
        }

        public static void SetFanSpeed(string arg)
        {
            try
            {
                if (arg.Equals("auto", StringComparison.OrdinalIgnoreCase))
                {
                    ControlMemory control = new ControlMemory();

                    var gpu = control.GpuEntries.First();
                    gpu.FanFlagsCur = MACM_SHARED_MEMORY_GPU_ENTRY_FAN_FLAG.AUTO;
                    Console.WriteLine("Setting Fan Speed to AUTO");
                    control.CommitChanges();
                }
                else if (uint.TryParse(arg, out uint resultParse))
                {
                    if (resultParse >= 0 && resultParse <= 100)
                    {
                        ControlMemory control = new ControlMemory();

                        var gpu = control.GpuEntries.First();
                        gpu.FanFlagsCur = MACM_SHARED_MEMORY_GPU_ENTRY_FAN_FLAG.None;
                        gpu.FanSpeedCur = resultParse;
                        Console.WriteLine($"Setting Fan Speed to {resultParse}");
                        control.CommitChanges();
                    }
                    else
                    {
                        DisplayError();
                    }
                }
                else
                {
                    DisplayError();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while setting fan value.");
                throw;
            }
        }

        public static void DisplayError()
        {
            Console.WriteLine($"Provide a number between 0 and 100 or AUTO.{Environment.NewLine}Or provide a number between 0 and 100 followed by a process name (E.g. mspaint). The program will now run the fan at full speed and put it back to auto when the process closes.");
        }
    }
}
