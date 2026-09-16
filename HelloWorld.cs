using System;

public static class HelloWorld
{
    public static string Hello() => "Hello, World!";
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine(HelloWorld.Hello());
    }
}
