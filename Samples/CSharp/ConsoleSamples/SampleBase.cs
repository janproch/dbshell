using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSamples
{
    public abstract class SampleBase
    {
        public abstract void Run();

        public string ProviderString => @"sqlite://Data Source=Chinook_Sqlite.sqlite";
    }
}
