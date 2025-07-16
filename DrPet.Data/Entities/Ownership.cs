using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrPet.Data.Entities
{
    public class Ownership
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }

}
