using InheritanceFilesSampleApp.Models;
using System;

namespace InheritanceFilesSampleApp;

public class Program
{
    public static void Main(string[] args)
    {
        Darbuotojas programuotojasJonas = new Programuotojas(new List<string> { "C#", "Java", "C++" }, "Mid", "Jonas", "Programeris", DateOnly.Parse("2000-01-02"));
        Darbuotojas projektuVadovasJonas = new ProjektuVadovas(new List<string> { "Projektas A", "Projektas B", "Projektas C" }, "Jonas", "Vadovas", DateOnly.Parse("1995-01-02"), DateOnly.Parse("2022-01-02"));

        List<Darbuotojas> darbuotojai = new List<Darbuotojas> { programuotojasJonas, projektuVadovasJonas };

        foreach(Darbuotojas d in darbuotojai)
        {
            if (d is Programuotojas)
            {
                ((Programuotojas)d).IsmoktiKalba("JavaScript");
            }
            else if (d is ProjektuVadovas)
            {
                ((ProjektuVadovas)d).AtliktiDarVienaProjekta("Projektas D");
            }
            Console.WriteLine(d);
        }
        Console.WriteLine();
    }
}