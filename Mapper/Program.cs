using System;
using Mapper.Mappers;
using Mapper.Objects;

namespace Mapper
{
    class Program
    {
        static void Main()
        {
            const int tries = 1000000;
            TestMapper(new UnoptimizedMapper(), "Unoptimized", tries);
            TestMapper(new OptimizedMapper(), "Optimized", tries);
            TestMapper(new DynamicCodeMapper(), "Dynamic", tries);
            TestMapper(new MapperLcg(), "Lcg", tries);
        }

        private static void TestMapper(ObjectCopyBase mapper, string mapperName, long triesCount)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();

            for (var i = 0; i < triesCount; i++)
            {
                mapper.Copy(new Source(), new Destination());
            }

            watch.Stop();

            Console.WriteLine($"{mapperName}:");
            PrintResult(watch.ElapsedMilliseconds, triesCount);

            watch.Reset();

            Console.WriteLine("//--------------------------------//");
        }

        private static void PrintResult(long totalTime, long triesCount = 1000000)
        {
            Console.WriteLine($"Total time: {totalTime}; time per one iteration: {(double)totalTime/triesCount}");
        }
    }
}
