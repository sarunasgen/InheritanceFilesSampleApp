using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceFilesSampleApp.Models
{
    public class ProjektuVadovas : Darbuotojas
    {
        public List<string> AtliktiProjektai { get; set; }
        public ProjektuVadovas(List<string> projektai, string vardas, string pavarde, DateOnly gimimoData, DateOnly pradejoDirbti) : base(pradejoDirbti)
        {
            AtliktiProjektai = projektai;
            Vardas = vardas;
            Pavarde = pavarde;
            GimimoData = gimimoData;
            
        }
        public ProjektuVadovas(List<string> projektai, string vardas, string pavarde, DateOnly gimimoData) : base()
        {
            AtliktiProjektai = projektai;
            Vardas = vardas;
            Pavarde = pavarde;
            GimimoData = gimimoData;
        }
        public override string ToString()
        {
            string projektai = "";
            foreach (string s in AtliktiProjektai)
            {
                projektai += s + " ";
            }
            return $"{Vardas} {Pavarde} {GimimoData.ToShortDateString()} Atlikti projektai: {projektai}";
        }
        public void AtliktiDarVienaProjekta(string projektas)
        {
            AtliktiProjektai.Add(projektas);
        }
        public string ProjektaiCSV()
        {
            string projektai = string.Empty;
            foreach (string p in AtliktiProjektai)
            {
                projektai += $"{p};";
            }
            return projektai;
        }
    }
}
