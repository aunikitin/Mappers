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
            
            var unoptimizedMapper = new UnoptimizedMapper();
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (var i = 0; i < tries; i++)
            {
                unoptimizedMapper.Copy(new Source(), new Destination());
            }

            watch.Stop();

            Console.WriteLine("Unoptimized:");
            PrintResult(watch.ElapsedMilliseconds, tries);

            watch.Reset();

            Console.WriteLine("//--------------------------------//");

            var optimizedMapper = new OptimizedMapper();
            watch.Start();

            for (var i = 0; i < tries; i++)
            {
                optimizedMapper.Copy(new Source(), new Destination());
            }

            watch.Stop();

            Console.WriteLine("Optimized:");
            PrintResult(watch.ElapsedMilliseconds, tries);

            watch.Reset();

            Console.WriteLine("//--------------------------------//");

            var dynamicCodeMapper = new DynamicCodeMapper();
            watch.Start();

            for (var i = 0; i < tries; i++)
            {
                dynamicCodeMapper.Copy(new Source(), new Destination());
            }

            watch.Stop();

            Console.WriteLine("Dynamic:");
            PrintResult(watch.ElapsedMilliseconds, tries);

            watch.Reset();

            Console.WriteLine("//--------------------------------//");

            var mapperLcg = new MapperLcg();
            watch.Start();

            for (var i = 0; i < tries; i++)
            {
                mapperLcg.Copy(new Source(), new Destination());
            }

            watch.Stop();

            Console.WriteLine("Lcg:");
            PrintResult(watch.ElapsedMilliseconds, tries);

            watch.Reset();

            Console.WriteLine("//--------------------------------//");
        }

        private static void PrintResult(long totalTime, long triesCount = 1000000)
        {
            Console.WriteLine($"Total time: {totalTime}; time per one iteration: {(double)totalTime/triesCount}");
        }
    }
}
