using System;

class ConfigurationManager
{
    private static ConfigurationManager instance;

    public string ApplicationName { get; set; }
    public string Version { get; set; }
    public string DatabaseConnectionString { get; set; }

    private ConfigurationManager()
    {
        ApplicationName = "Inventory App";
        Version = "1.0";
        DatabaseConnectionString = "Server=.;Database=TestDB;";
    }

    public static ConfigurationManager GetInstance()
    {
        if (instance == null)
        {
            instance = new ConfigurationManager();
        }
        return instance;
    }
}

class Program
{
    static void Main()
    {
        var config1 = ConfigurationManager.GetInstance();
        var config2 = ConfigurationManager.GetInstance();

        Console.WriteLine(config1.ApplicationName);
        Console.WriteLine(config2.ApplicationName);

        Console.WriteLine(config1 == config2); 
    }
}