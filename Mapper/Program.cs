using System;
using AutoMapper;
using Mapper.Mappers;
using Mapper.Objects;

namespace Mapper
{
    class Program
    {
        static void Main()
        {
            CreateAutoMapper();

            const int tries = 1000000;
            TestMapper(new UnoptimizedMapper(), "Unoptimized", tries);
            TestMapper(new OptimizedMapper(), "Optimized", tries);
            TestMapper(new DynamicCodeMapper(), "Dynamic", tries);
            TestMapper(new MapperLcg(), "Lcg", tries);

            TestMapper(CreateAutoMapper(), "AutoMapper", tries);
        }

        private static IMapper CreateAutoMapper()
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<Source, Destination>(); });
            return configuration.CreateMapper();
        }

        private static void TestMapper(IMapper mapper, string mapperName, long triesCount)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();

            for (var i = 0; i < triesCount; i++)
            {
                mapper.Map(new Source(), new Destination());
            }

            watch.Stop();

            var totalTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"{mapperName}:");
            Console.WriteLine($"Total time: {totalTime}; time per one iteration: {(double)totalTime / triesCount}");

            watch.Reset();

            Console.WriteLine("//--------------------------------//");
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

            var totalTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"{mapperName}:");
            Console.WriteLine($"Total time: {totalTime}; time per one iteration: {(double)totalTime / triesCount}");

            watch.Reset();

            Console.WriteLine("//--------------------------------//");
        }
    }
}
