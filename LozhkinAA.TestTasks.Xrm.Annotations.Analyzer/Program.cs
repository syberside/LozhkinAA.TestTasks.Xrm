using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using LozhkinAA.TestTasks.Xrm.Annotations;
using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.EntityFramework;
using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Helpers;
using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Services.Abstract;
using LozhkinAA.TestTasks.Xrm.Annotations.Services;
using LozhkinAA.TestTasks.Xrm.Annotations.Services.Abstract;

[assembly: Annotation("real named annotation", "test comment")]

namespace LozhkinAA.TestTasks.Xrm.Annotations.Analyzer
{
    [Annotation("EDEC767C-3946-4F3C-B06F-4173B2DDC193", "test comment 2")]
    internal class Program
    {
        private const int OTHER_ERROR_CODE = 1;
        private const int WRONG_COMMAND_LINE_ARGUMENTS = 2;


        private static void Main(string[] args)
        {
            Console.WriteLine("Assembly Annotations Analizer by Alexander Lozhkin");
            try
            {
                if (args.Length != 1)
                {
                    PrintUsage();
                    Environment.ExitCode = WRONG_COMMAND_LINE_ARGUMENTS;
                }
                else
                {
                    var filename = args.First();
                    //composition root
                    var service = new AnnotationService(new AnnotattionsContext());
                    var provider = new DefaultAnnotationInfoProvider();
                    //method injection
                    App(filename, service, provider);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error ocured: {0}", ex);
                Environment.ExitCode = OTHER_ERROR_CODE;
                Console.ResetColor();
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void PrintUsage()
        {
            var filename = Process.GetCurrentProcess().MainModule.ModuleName;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Usage: {0} assemblyFileName", filename);
            Console.WriteLine("Example #1: {0} MyAssembly.dll", filename);
            Console.WriteLine(@"Example #2: {0} c:\temp\Assembly.dll", filename);
            Console.ResetColor();
        }

        private static void App(string filename, IAnnotationDetailsEditService service, IAnnotationInfoProvider provider)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service");
            }
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename");
            }
            //translate filename to full path
            var fileInfo = new FileInfo(filename);
            //extracts info
            var annotations = provider.ExtractFrom(fileInfo.FullName);
            //convert annotations to descriptions
            var descriptions = annotations.ToDescriptions();
            foreach (var description in descriptions)
            {
                var wasAdded = service.TryAdd(description);
                if (wasAdded)
                {
                    //this was new annotation
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Change annotation was accepted: {0} ({1})", description.Id, description.Comment);
                    Console.ResetColor();
                }
                else
                {
                    //annotation already added to db
                    Console.WriteLine("Change annotation was denied: {0} ({1})", description.Id, description.Comment);
                }
            }
        }
    }
}