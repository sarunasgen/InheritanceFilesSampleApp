using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceFilesSampleApp.Models
{
    public class Darbuotojas : Zmogus
    {
        protected DateOnly PrisijungeDribti { get; set; }
        public Darbuotojas()
        {
            PrisijungeDribti = DateOnly.MaxValue;
        }
        public Darbuotojas(DateOnly pradejoDirbti)
        {
            PrisijungeDribti = pradejoDirbti;
        }
    }
}
