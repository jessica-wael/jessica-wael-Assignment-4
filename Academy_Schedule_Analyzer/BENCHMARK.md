==== Benchmark Analysis ====

Benchmark: String Concatenation vs. StringBuilder.......

I compared two ways of creating a long piece of text in C#: using the standard string concatenation operator (+=) and using StringBuilder. 
The goal was to see how their speed and memory usage differed, using a tool called BenchmarkDotNet.

Machine Information:
-Operating System: Windows 11 pro
-Processor: Intel Core i5-12450HX
-.NET SDK: 10.0.401
-Benchmark Tool: BenchmarkDotNet



| Method                     | Iterations | Mean             | Error           | StdDev          | Gen0         | Gen1         | Gen2         | Allocated     |
|--------------------------- |----------- |-----------------:|----------------:|----------------:|-------------:|-------------:|-------------:|--------------:|
| **StringConcatenation**    | 100        |         917.6 ns |          4.16 ns|         3.69 ns |       2.0046 |       0.0010 |          -   |       12576 B |
| StringBuilderConcatenation | 100        |         175.8 ns |         1.52 ns |         1.42 ns |       0.1223 |       0.0002 |            - |         768 B |
| **StringConcatenation**    | 1000       |      45,326.3 ns |       142.59 ns |       126.40 ns |     163.5132 |       0.7935 |           -  |     1025976 B |
| StringBuilderConcatenation | 1000       |         733.9 ns |         2.87 ns |         2.69 ns |       0.7286 |       0.0067 |            - |        4576 B |
| **StringConcatenation**    | 10000      |    3,636,102.4 ns|    24,157.81 ns |    20,172.87 ns |   15949.2188 |     785.1563 |            - |   100259976 B |
| StringBuilderConcatenation | 10000      |       6,919.6 ns |        56.75 ns |        53.08 ns |       8.4686 |       0.9384 |            - |       53200 B |
| **StringConcatenation**    | 100000     | 692,862,200.0 ns | 3,841,526.36 ns | 3,593,366.14 ns | 2831000.0000 | 2600000.0000 | 2546000.0000 | 10003455432 B |
| StringBuilderConcatenation | 100000     |     135,424.2 ns |       866.52 ns |       768.14 ns |      62.2559 |      62.2559 |      62.2559 |      410013 B |


Which was faster with 100 iterations?
StringBuilder — about 5.5 faster (175 ns vs 917 ns).

Which was faster with 100,000 iterations?
StringBuilder, by a huge margin — 0.135 ms vs 693 ms for plain string concatenation. That's roughly 5,000x slower for strings.

Which one allocated more memory?
String concatenation, by far. At 100,000 iterations it allocated around 10 GB, while StringBuilder only used about 410 KB.

What happened to string performance as the loop size grew?
It got worse much faster than the input size — not just slower, but slower at an increasing rate (closer to O(n²) than O(n)).

Why does repeated string concatenation allocate more memory?
Because strings in C# are immutable. Every += creates a brand-new string in memory 
(copying the old content plus the new part), and the old one becomes garbage. Do that N times, and each step re-copies everything before it.

Why does StringBuilder perform better?
It uses one internal buffer that gets modified in place, instead of creating a new copy every time.
It only resizes the buffer occasionally, not on every Append.

Is StringBuilder always better?
No. For a small, fixed number of operations (like joining 2–3 strings once),
plain string concatenation is simpler and fine. StringBuilder's advantage only shows up when there's a lot of repeated appending,
like inside a loop.





