using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<ValueTasks.ValueTaskBenchmark>();