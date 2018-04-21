using System;

namespace ConsoleSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                WriteHelp();
                return;
            }

            string sampleName = args[0];
            var type = Type.GetType($"ConsoleSamples.Samples.{sampleName}");
            if (type == null)
            {
                WriteHelp();
                return;
            }
            var instance = (SampleBase)Activator.CreateInstance(type);
            instance.Run();
            Wait();
        }

        private static void Wait()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void WriteHelp()
        {
            Console.WriteLine("Usage: ConsoleSamples SAMPLE_NAME");
            Console.WriteLine("SAMPLE_NAME is one of following posibilities:");
            foreach(var type in typeof(Program).Assembly.GetTypes())
            {
                if (!type.FullName.StartsWith("ConsoleSamples.Samples."))
                    continue;

                Console.WriteLine(type.Name);
            }
            Console.WriteLine("If you run samples from Visual Studio, you can choose exmaple from Profile selector (combo-box with preselected ConsoleSamples)");
            Wait();
        }
    }
}
