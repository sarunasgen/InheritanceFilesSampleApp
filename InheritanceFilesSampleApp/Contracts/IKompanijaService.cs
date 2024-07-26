using InheritanceFilesSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceFilesSampleApp.Contracts
{
    public interface IKompanijaService
    {
        List<Darbuotojas> GautiVisusDarbuotojus();
        List<Darbuotojas> GautiVisusProgramuotojus();
        List<Darbuotojas> GautiVisusProjektuVadvous();
        void PridetiDarbuotoja(Darbuotojas darbuotojas);
        bool ArProgramuotojuFaileYraDuomenu();
    }
}
