using InheritanceFilesSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceFilesSampleApp.Contracts
{
    public interface IFilesRepository
    {
        List<Darbuotojas> SkaitytiProgramuotojus();
        List<Darbuotojas> SkaitytiProjektuVadovus();
        void PridetiProgramuotoja(Programuotojas p);
        void PridetiProjektuVadovas(ProjektuVadovas p);
        bool ArProgramuotojuFailasNetuscias();

    }
}
