using InheritanceFilesSampleApp.Contracts;
using InheritanceFilesSampleApp.Models;
using InheritanceFilesSampleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceFilesSampleApp.Service
{
    public class KompanijaService : IKompanijaService
    {
        private List<Darbuotojas> Darbuotojai { get; set; } = new List<Darbuotojas>();

        private readonly IFilesRepository _filesRepository;
        public KompanijaService(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
            OnStart();
        }
        private void OnStart()
        {
            List<Darbuotojas> programuotojai = _filesRepository.SkaitytiProgramuotojus();
            List<Darbuotojas> projektuVadovai = _filesRepository.SkaitytiProjektuVadovus();

            Darbuotojai.AddRange(projektuVadovai);
            Darbuotojai.AddRange(programuotojai);
        }
        public List<Darbuotojas> GautiVisusDarbuotojus()
        {
            return Darbuotojai;
        }
        public List<Darbuotojas> GautiVisusProgramuotojus()
        {
            List<Darbuotojas> programuotojai = new List<Darbuotojas>();
            foreach (Darbuotojas d in Darbuotojai)
            {
                if(d is Programuotojas)
                {
                    programuotojai.Add(d);
                }
            }
            return programuotojai;
        }
        public List<Darbuotojas> GautiVisusProjektuVadvous()
        {
            List<Darbuotojas> vadovai = new List<Darbuotojas>();
            foreach (Darbuotojas d in Darbuotojai)
            {
                if (d is ProjektuVadovas)
                {
                    vadovai.Add(d);
                }
            }
            return vadovai;
        }
        public void PridetiDarbuotoja(Darbuotojas darbuotojas)
        {
            Darbuotojai.Add(darbuotojas);
            PridetiDarbuotojaIFaila(darbuotojas);
        }
        private void PridetiDarbuotojaIFaila(Darbuotojas darbuotojas)
        {
            if (darbuotojas is Programuotojas)
                _filesRepository.PridetiProgramuotoja((Programuotojas)darbuotojas);
            else
                _filesRepository.PridetiProjektuVadovas((ProjektuVadovas)darbuotojas);
        }
        public bool ArProgramuotojuFaileYraDuomenu()
        {
            return _filesRepository.ArProgramuotojuFailasNetuscias();
        }
        
    }
}
