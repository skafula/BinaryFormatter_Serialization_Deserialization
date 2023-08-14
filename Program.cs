using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
internal class Program
{
    [Serializable]
    public class Country
    {
        public short CountryID { get; set; }
        public string CountryName { get; set; }
        public long Population { get; set; }
        public string Region { get; set; }
    }
    private static void Main(string[] args)
    {
        Country russia = new Country() { CountryID = 1, CountryName = "Russia", Population = 149000000, Region = "Eastern Europe" };

        string filePath = @"c:\FileTest\russia.txt";
        FileStream russiaStream = new(filePath, FileMode.Create, FileAccess.Write);

        BinaryFormatter bf = new BinaryFormatter();

        bf.Serialize(russiaStream, russia);

        russiaStream.Close();
        Console.WriteLine("Serialization completed.");

        FileStream fileStream2 = new(filePath, FileMode.Open, FileAccess.Read);
        Country russieFromFile = (Country)bf.Deserialize(fileStream2);

        fileStream2.Close();
        Console.WriteLine("Deserialzation completed.\n\nThe data: ");
        Console.WriteLine($"Id: {russieFromFile.CountryID} Name: {russieFromFile.CountryName} Pop: {russieFromFile.Population} Region: {russieFromFile.Region}");
    }
}