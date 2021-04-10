using BenchmarkDotNet.Attributes;
using System.Linq;
using System.Threading.Tasks;

namespace ValueTasks
{
    [MemoryDiagnoser]
    public class ValueTaskBenchmark
    {
        private readonly ProductService _service = new();

        [Benchmark]
        public async Task GetProductsReferenceTask()
        {
            foreach (var _ in Enumerable.Range(0, 10))
            {
                // Awaiting Task<T>
                await _service.GetProductsAsync();
            }
        }

        [Benchmark]
        public async Task GetProductsValueTask()
        {
            foreach (var _ in Enumerable.Range(0, 10))
            {
                // Awaiting ValueTask<T>
                await _service.GetProductsValueTaskAsync();
            }
        }
    }
}
