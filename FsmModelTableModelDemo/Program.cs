using System;
using System.IO;
using System.Reflection;

namespace FsmModelTableModelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var fileName = Path.Combine(
                dirName is null ? "" : dirName,
                "tablemodel.json"
            );

            //var tableModel = TableModelLoader.Load(fileName);

            Console.WriteLine("Demo run...");
        }
    }
}
