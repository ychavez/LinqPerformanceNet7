using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Net7
{
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [MemoryDiagnoser(false)]
    public class Benchmarks
    {
        [Params(10000)]
        public int Size { get; set; }
        private IEnumerable<int> _items;

        [GlobalSetup]
        public void Setup()
        {

            _items = Enumerable.Range(1, Size).ToArray();
        }


        [Benchmark]
        public int Min() => _items.Min();

        [Benchmark]
        public double Average() => _items.Average();

        [Benchmark]
        public int Sum() => _items.Sum();

        [Benchmark]
        public int Max() => _items.Max();


        [Benchmark]
        public int Max_Own()
        {

            var biggest = int.MinValue;
            foreach (var item in _items)
            {

                if (item > biggest)
                    biggest = item;

            }
            return biggest;

        }


    }
}
