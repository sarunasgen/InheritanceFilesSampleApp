using InheritanceFilesSampleApp.Contracts;
using InheritanceFilesSampleApp.Models;
using InheritanceFilesSampleApp.Repository;
using InheritanceFilesSampleApp.Service;

namespace InheritanceFilesSampleApp;

public class Program
{
    public static void Main(string[] args)
    {
        IFilesRepository filesRepository = new FilesRepository("Programuotojai.csv", "ProjektuVadovai.csv");
        IKompanijaService kompanijaService = new KompanijaService(filesRepository);

        while (true)
        {
            Console.WriteLine("1. Rodyti visus darbuotojus");
            Console.WriteLine("2. Rodyti visus programuotojus");
            Console.WriteLine("3. Rodyti visus projektu vadovus");
            Console.WriteLine("4. Prideti projektu vadova");
            Console.WriteLine("5. Prideti programuotoja");
            Console.WriteLine("6. Ar Programuotoju faile yra duomenu");
            Console.WriteLine("20. Baigti Darba");

            string pasirinkimas = Console.ReadLine();
            switch (pasirinkimas)
            {
                case "1":
                    foreach (Darbuotojas d in kompanijaService.GautiVisusDarbuotojus())
                    {
                        Console.WriteLine(d);
                    }
                    break;
                case "2":
                    foreach (Darbuotojas d in kompanijaService.GautiVisusProgramuotojus())
                    {
                        Console.WriteLine(d);
                    }
                    break;
                case "3":
                    foreach (Darbuotojas d in kompanijaService.GautiVisusProjektuVadvous())
                    {
                        Console.WriteLine(d);
                    }
                    break;
                case "4":
                    Console.WriteLine("Iveskite varda");
                    string vardas = Console.ReadLine();
                    Console.WriteLine("Iveskite pavarde");
                    string pavarde = Console.ReadLine();
                    Console.WriteLine("Iveskite gimimo data");
                    string gimimoData = Console.ReadLine();
                    Console.WriteLine("Projektu kieki: ");
                    int pKiekis = int.Parse(Console.ReadLine());
                    List<string> projektai = new List<string>();
                    for (int i = 0; i < pKiekis; i++)
                    {
                        Console.WriteLine($"Iveskite {i + 1} projekto pavadinima: ");
                        projektai.Add(Console.ReadLine());
                    }
                    kompanijaService.PridetiDarbuotoja(new ProjektuVadovas(projektai, vardas, pavarde, DateOnly.Parse(gimimoData)));
                    break;
                case "5":
                    Console.WriteLine("Iveskite varda");
                    string pvardas = Console.ReadLine();
                    Console.WriteLine("Iveskite pavarde");
                    string ppavarde = Console.ReadLine();
                    Console.WriteLine("Iveskite gimimo data");
                    string pgimimoData = Console.ReadLine();
                    Console.WriteLine("Iveskite seniority");
                    string pseniority = Console.ReadLine();
                    Console.WriteLine("Kalbu kiekis: ");
                    int ppKiekis = int.Parse(Console.ReadLine());
                    List<string> kalbos = new List<string>();
                    for (int i = 0; i < ppKiekis; i++)
                    {
                        Console.WriteLine($"Iveskite {i + 1} projekto pavadinima: ");
                        kalbos.Add(Console.ReadLine());
                    }
                    kompanijaService.PridetiDarbuotoja(new Programuotojas(kalbos, pseniority, pvardas, ppavarde, DateOnly.Parse(pgimimoData)));
                    break;
                case "6":
                    Console.WriteLine($"Programuotoju failas netuscias: {kompanijaService.ArProgramuotojuFaileYraDuomenu()}");
                    break;
                case "20":
                    Environment.Exit(0);
                    break;
            }
        }


    }
}