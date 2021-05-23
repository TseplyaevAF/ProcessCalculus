# Потоки в C#

Для создания потоков в языке программирования C# используется класс **Thread**:
```C#
// создаем новый поток
Thread myThread = new Thread(new ThreadStart(Count));
myThread.Start(); // запускаем поток
```

Для создания нового потока используется делегат **ThreadStart**, который получает в качестве параметра выполняемый метод. И чтобы запустить поток, вызывается метод **Start**.

```C#
public static void Count()
{
    for (int i = 1; i < 9; i++)
    {
        Console.WriteLine("Второй поток:");
        Console.WriteLine(i * i);
        Thread.Sleep(400);
    }
}
```

Существует еще одна форма создания потока без явного использования делегата ThreadStart: 
```C# 
Thread myThread = new Thread(Count);
```
Компилятор C# выводит делегат из сигнатуры метода Count и вызывает соответствующий конструктор.


## Потоки с параметрами 
Если необходимо передать какие-нибудь параметры в поток, для этой цели можно использовать делегат **ParameterizedThreadStart**.
``` C#
class Program
{
    static void Main(string[] args)
    {
        int number = 4;
        // создаем новый поток
        Thread myThread = new Thread(new ParameterizedThreadStart(Count));
        myThread.Start(number); 
 
        for (int i = 1; i < 9; i++)
        {
            Console.WriteLine("Главный поток:");
            Console.WriteLine(i * i);
            Thread.Sleep(300);
        }
 
        Console.ReadLine();
    }
 
    public static void Count(object x)
    {
        for (int i = 1; i < 9; i++)
        {
            int n = (int)x;
 
            Console.WriteLine("Второй поток:");
            Console.WriteLine(i*n);
            Thread.Sleep(400);
        }
    }
}
```

После создания потока мы передаем метод в **myThread.Start(number);** переменную, значение которой хотим передать в поток.

При использовании ParameterizedThreadStart мы сталкиваемся с ограничением: **мы можем запускать во втором потоке только такой метод, который в качестве единственного параметра принимает объект типа object.** Поэтому в данном случае нам надо дополнительно привести переданное значение к типу int, чтобы его использовать в вычислениях.

### А что если необходимо передать несколько параметров? В таком случае на помощь приходит **классовый подход**:

``` C#
class Program
{
    static void Main(string[] args)
    {
        Counter counter = new Counter();
        counter.x = 4;
        counter.y = 5;
            
        Thread myThread = new Thread(new ParameterizedThreadStart(Count));
        myThread.Start(counter); 
 
        //...................
    }
 
    public static void Count(object obj)
    {
        for (int i = 1; i < 9; i++)
        {
            Counter c = (Counter)obj;
 
            Console.WriteLine("Второй поток:");
            Console.WriteLine(i*c.x *c.y);
        }
    }
}
 
public class Counter
{
    public int x;
    public int y;
}
```

Но тут опять же есть одно ограничение: **метод Thread.Start не является типобезопасным**, то есть мы можем передать в него любой тип, и потом нам придется приводить переданный объект к нужному нам типу. Для решения данной проблемы рекомендуется объявлять все используемые методы и переменные в специальном классе, а в основной программе запускать поток через ThreadStart. Например:

``` C#
class Program
{
    static void Main(string[] args)
    {
        Counter counter = new Counter(5, 4);
 
        Thread myThread = new Thread(new ThreadStart(counter.Count));
        myThread.Start(); 
        //........................
    }  
}
 
public class Counter
{
    private int x;
    private int y;
 
    public Counter(int _x, int _y)
    {
        this.x = _x;
        this.y = _y;
    }
 
    public void Count()
    {
        for (int i = 1; i < 9; i++)
        {
            Console.WriteLine("Второй поток:");
            Console.WriteLine(i * x * y);
            Thread.Sleep(400);
        }
    }
}
```

### Также можно добавлять данные в поток с помощью **лямбда выражений**. Так можно передать методу любое количество аргументов. Например:

```C# 
static void Main()
{
Thread myThread = new Thread( () => callFunc(" Hello world! ") );
myThread.Start();
}
static void callFunc( string message) { Console.WriteLine(message); }
```

## Как получить данные из потока?
1.
``` C#
void Main()
{
  object value = null; // Переменная для хранения возвращаемого значения
  var thread = new Thread(
    () =>
    {
      value = "Hello World"; // Присвоить этой переменной какое-то значение
    });
  thread.Start();
  thread.Join();
  Console.WriteLine(value); // Вывести значение
}
```

2. Вы можете использовать делегаты и IAsyncResult и возвращать значение из метода EndInvoke():

```C# 
delegate object MyFunc();
...
MyFunc x = new MyFunc(() => 
    { 
        // Что-то делаем...
        return 42; 
    });
IAsyncResult asyncResult = x.BeginInvoke(null, null);
object result = x.EndInvoke(asyncResult);
```
3. Вы можете использовать класс BackgroundWorker . В этом случае вы можете использовать захваченную переменную (например, с объектом Thread ) или обработать событие RunWorkerCompleted :

```C# BackgroundWorker worker = new BackgroundWorker();
worker.DoWork += (s, e) => {
    //Some work...
    e.Result = 42;
};
worker.RunWorkerCompleted += (s, e) => {
    //e.Result "returned" from thread
    Console.WriteLine(e.Result);
};
worker.RunWorkerAsync();
```

4. Начиная с .NET 4.0, вы можете использовать параллельную библиотеку задач и класс Task для запуска ваших потоков. Универсальный класс Task<TResult> позволяет получить возвращаемое значение из свойства Result :

```C# 
// Основной поток будет заблокирован до завершения потока задачи
// (из-за получения значения свойства Result)
int result = Task.Factory.StartNew(() => {
    //Some work...
    return 42;}).Result;
```

5. Начиная с .NET 4.5, вы также можете использовать ключевые слова async / await для прямого возврата значения из задачи вместо получения свойства Result :

``` C#
int result = await Task.Run(() => {
    //Some work...
    return 42; });
```
*Примечание*: метод, содержащий приведенный выше код, должен быть помечен ключевым словом **async**.


### **Источники:**
1. metanit.com
2. https://coderoad.ru/1314155/Возвращая-значение-из-потока