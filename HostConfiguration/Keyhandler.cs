namespace ConfigurationsInConsoleApp;

public static class Keyhandler
{
    public static void WaitForKey()
    {
        Console.WriteLine("\n\n\n... Press any key to exit.");

        Console.ReadKey();
    }
}