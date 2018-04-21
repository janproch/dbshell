using DbShell.All;
using DbShell.Core;

namespace ConsoleSamples.Samples
{
    public class ExportToCsv : SampleBase
    {
        public override void Run()
        {
            var copy = new CopyTable
            {
                Connection = ProviderString,
                Source = new Table { Name = "album" },
                Target = new File { Name = "album.csv" },
            };

            copy.Run();
        }
    }
}
