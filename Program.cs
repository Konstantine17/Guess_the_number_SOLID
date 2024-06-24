using System;
using System.Collections.Generic;
using System.IO;
public static class Extensions
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
    {
        if (collection == null || convertToNumber == null)
            return null;
        T max = null;
        float maxValue = float.MinValue;
        foreach (var item in collection)
        {
            float value = convertToNumber(item);
            if (value > maxValue)
            {
                maxValue = value;
                max = item;
            }
        }
        return max;
    }
}
public class FileSearcher
{
    public event EventHandler<FileFoundEventArgs> FileFound;
    public void SearchDirectory(string directoryPath)
    {
        SearchDirectoryRecursive(directoryPath);
    }
    private void SearchDirectoryRecursive(string directoryPath)
    {
        try
        {
            foreach (string file in Directory.GetFiles(directoryPath))
            {
                OnFileFound(new FileFoundEventArgs(file));
            }

            foreach (string subDirectory in Directory.GetDirectories(directoryPath))
            {
                SearchDirectoryRecursive(subDirectory);
            }
        }
        catch
        {
           Console.WriteLine("Not Found");
        }
    }
    protected virtual void OnFileFound(FileFoundEventArgs e)
    {
        FileFound?.Invoke(this, e);
    }
}
public class FileFoundEventArgs : EventArgs
{
    public string FileName { get; }
    public FileFoundEventArgs(string fileName)
    {
        FileName = fileName;
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Bob", Age = 30 },
            new Person { Name = "Charlie", Age = 35 }
        };
        Person oldest = people.GetMax(p => p.Age);
        Console.WriteLine($"The oldest person is {oldest.Name}, who is {oldest.Age} years old.");
        
        FileSearcher fileSearcher = new FileSearcher();
        fileSearcher.FileFound += FileSearcher_FileFound;
        Console.WriteLine("Searching for files...");
        fileSearcher.SearchDirectory(@"C:\");
        Console.WriteLine("Search complete.");
    }
    private static void FileSearcher_FileFound(object sender, FileFoundEventArgs e)
    {
        Console.WriteLine($"Found file: {e.FileName}");
    }
}
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}