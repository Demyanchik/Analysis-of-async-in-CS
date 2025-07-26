// See https://aka.ms/new-console-template for more information
using System.Threading;
using System.Threading.Tasks;

ThreadId();
var tomTask = PrintNameAsync("Tom");
ThreadId();
var bobTask = PrintNameAsync("Bob");
ThreadId();
var samTask = PrintNameAsync("Sam");
ThreadId();

await tomTask;
ThreadId("после await 1 ");
await bobTask;
ThreadId("после await 2 ");
await samTask;
ThreadId("после await 3 ");

ThreadId();

// определение асинхронного метода
async Task PrintNameAsync(string name)
{
    ThreadId($"В начале вызова async метода {name}: ");
    await Task.Delay(5000);
    Console.WriteLine(name);
    ThreadId($"В конце вызова async метода {name}: ");
}

/// <summary>
/// Выводим Id потока, в котором вызван этот метод
/// </summary>
static void ThreadId(string text = "")
{
    Console.WriteLine(text + "Current thread id: " + Thread.CurrentThread.ManagedThreadId);
}