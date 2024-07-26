using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceFilesSampleApp.Models
{
    public class Programuotojas : Darbuotojas
    {
        public List<string> ProgramavimoKalbos { get; set; }
        public string Seniority { get; set; }
        public Programuotojas(List<string> programavimoKalbos, string seniority, string vardas, string pavarde, DateOnly gimimoData) 
        {
            ProgramavimoKalbos = programavimoKalbos;
            Seniority = seniority;
            Vardas = vardas;
            Pavarde = pavarde;
            GimimoData = gimimoData;
        }
        public override string ToString()
        {
            string kalbos = "";
            foreach(string s in ProgramavimoKalbos)
            {
                kalbos += s + " ";
            }
            return $"{Vardas} {Pavarde} {GimimoData.ToShortDateString()} Programavimo kalbos: {kalbos} Seniority: {Seniority}";
        }
        public void IsmoktiKalba(string kalba)
        {
            ProgramavimoKalbos.Add(kalba);
        }
    }
}
