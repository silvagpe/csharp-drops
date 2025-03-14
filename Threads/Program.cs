// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

//Threads 
Thread t = new Thread(() =>
{
    Console.WriteLine("Thread is running");
});
t.Start();

//Task
await Task.Run(() =>
{
    Console.WriteLine("Task is running");
});

//Parallel
Parallel.For(0, 10, i => Console.WriteLine(i));



// Exercício 1: Concorrência com Tasks
// Objetivo: Simular o download de vários arquivos de forma concorrente.
// Tarefa: Crie um programa que use Task para "baixar" 5 arquivos (simule com Task.Delay) e exiba o progresso no console.
// Dica: Use async/await e Task.WhenAll para esperar todas as tarefas.

static async Task DownloadFile(int fileNumber){
    Console.WriteLine($"Downloading file {fileNumber}...");
    await Task.Delay(1000); 
    Console.WriteLine($"File {fileNumber} downloaded.");
}

Task[] tasks = new Task[5];
for(int i = 0; i < 5; i++){
    int fileNumber = i + 1;
    tasks[i] = DownloadFile(fileNumber);
}

await Task.WhenAll(tasks);
Console.WriteLine("All files downloaded.");


// Exercício 2: Paralelismo com Parallel.For
// Objetivo: Processar uma lista de números em paralelo.
// Tarefa: Crie uma lista com 1.000 números e use Parallel.For para calcular o quadrado de cada número. Compare o tempo de execução com um for comum.
// Dica: Use Stopwatch para medir o desempenho.

List<int> numbers = Enumerable.Range(1, 10000).ToList();
Console.WriteLine($"Processing {numbers.Count} numbers using Parallel...");
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
Parallel.For(0, numbers.Count, i => {
    numbers[i] = numbers[i] * numbers[i];  
    for(int j = 0; j < 100000; j++){
        // Simulate some work
    }  
});
stopwatch.Stop();
Console.WriteLine($"Parallel.For: {stopwatch.ElapsedMilliseconds}ms | ticks: {stopwatch.ElapsedTicks}");

Console.WriteLine($"Processing {numbers.Count} numbers using For...");
stopwatch = new Stopwatch();
stopwatch.Start();
for(int i = 0; i < numbers.Count; i++){
    numbers[i] = numbers[i] * numbers[i];
    for(int j = 0; j < 100000; j++){
        // Simulate some work
    }  
}
stopwatch.Stop();
Console.WriteLine($"For: {stopwatch.ElapsedMilliseconds}ms | ticks: {stopwatch.ElapsedTicks}");


// Exercício 3: Simulação de Concorrência vs. Paralelismo
// Objetivo: Entender a diferença prática.
// Tarefa:
// Escreva um método que simule uma tarefa pesada (ex.: cálculo matemático em loop).
// Execute-o com Task.Run (concorrência) e depois com Parallel.For (paralelismo).
// Observe como o uso da CPU muda em cada caso (use o Gerenciador de Tarefas).
static void HeavyTask(){
    double result = 0;
    for(int i = 0; i < 1000000; i++){
        result += Math.Sqrt(i);
    }
    Console.WriteLine($"Heavy task result: {result}");
}

Console.WriteLine("Running heavy task with Task.Run (concurrency)...");
Stopwatch sw = new Stopwatch();
sw.Start();
await Task.Run(() => HeavyTask());
sw.Stop();
Console.WriteLine($"Task.Run: {sw.ElapsedMilliseconds}ms");

Console.WriteLine("Running heavy task with Parallel.For (parallelism)...");
sw = new Stopwatch();
sw.Start();
Parallel.For(0, Environment.ProcessorCount, i => HeavyTask());
sw.Stop();
Console.WriteLine($"Parallel.For: {sw.ElapsedMilliseconds}ms");


// Exercício 4: Misturando async/await com Paralelismo
// Objetivo: Combinar os conceitos.
// Tarefa: Crie um programa que baixa dados de 3 APIs fictícias (simuladas com Task.Delay) de forma assíncrona e, em seguida, processa os resultados em paralelo com Parallel.ForEach.
static async Task<string> DownloadDataFromApi(int apiNumber)
{
    Console.WriteLine($"Downloading data from API {apiNumber}...");
    await Task.Delay(1000); // Simulate API call delay
    Console.WriteLine($"Data from API {apiNumber} downloaded.");
    return $"Data from API {apiNumber}";
}

sw = new Stopwatch();
sw.Start();
List<Task<string>> apiTasks = new List<Task<string>>();
for (int i = 1; i <= 3; i++)
{
    apiTasks.Add(DownloadDataFromApi(i));
}

string[] apiResults = await Task.WhenAll(apiTasks);
sw.Stop();
Console.WriteLine($"Task.WhenAll - {sw.ElapsedMilliseconds}ms");


Console.WriteLine("Processing API results in parallel...");
sw = new Stopwatch();
sw.Start();
Parallel.ForEach(apiResults, result =>
{
    Console.WriteLine($"Processing {result}");
    // Simulate some processing work
    for (int j = 0; j < 100000; j++) { }
});
sw.Stop();
Console.WriteLine($"Parallel - {sw.ElapsedMilliseconds}ms");

Console.WriteLine("All API results processed.");