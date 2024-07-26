using InheritanceFilesSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceFilesSampleApp.Repository
{
    public class FilesRepository
    {
        private readonly string ProgramuotojuFailoVieta;
        private readonly string ProjektuVadovuFailoVieta;
        public FilesRepository(string duomenuFailasProg, string duomenuFailasProjVad)
        {
            ProgramuotojuFailoVieta = duomenuFailasProg;
            ProjektuVadovuFailoVieta = duomenuFailasProjVad;
        }
        public List<Darbuotojas> SkaitytiProgramuotojus()
        {
            List<Darbuotojas> darbuotojai = new List<Darbuotojas>();
            
            using(StreamReader sr = new StreamReader(ProgramuotojuFailoVieta))
            {
                while(!sr.EndOfStream)
                {
                    string eilute = sr.ReadLine();
                    string[] vertes = eilute.Split(',');
                    string[] pKalbos = vertes[4].Split(';');
                    List<string> programavimoKalbos = pKalbos.ToList();
                    darbuotojai.Add(new Programuotojas(programavimoKalbos, vertes[3], vertes[0], vertes[1], DateOnly.Parse(vertes[2])));
                }
            }

            return darbuotojai;
        }
        public List<Darbuotojas> SkaitytiProjektuVadovus()
        {
            List<Darbuotojas> darbuotojai = new List<Darbuotojas>();

            using (StreamReader sr = new StreamReader(ProjektuVadovuFailoVieta))
            {
                while (!sr.EndOfStream)
                {
                    string eilute = sr.ReadLine();
                    string[] vertes = eilute.Split(',');
                    string[] vProjektai = vertes[3].Split(';');
                    List<string> projektai = vProjektai.ToList();
                    darbuotojai.Add(new ProjektuVadovas(projektai, vertes[0], vertes[1], DateOnly.Parse(vertes[2])));
                }
            }

            return darbuotojai;
        }
        public void PridetiProgramuotoja(Programuotojas p)
        {
            using(StreamWriter sw = new StreamWriter(ProgramuotojuFailoVieta, true))
            {
                sw.WriteLine($"{p.Vardas},{p.Pavarde},{p.GimimoData},{p.Seniority},{p.KalbosCSV()}");
            }
        }
        public void PridetiProjektuVadovas(ProjektuVadovas p)
        {
            using (StreamWriter sw = new StreamWriter(ProjektuVadovuFailoVieta, true))
            {
                sw.WriteLine($"{p.Vardas},{p.Pavarde},{p.GimimoData},{p.ProjektaiCSV()}");
            }
        }
    }
}
