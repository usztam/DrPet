using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrPet.Data.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public ICollection<Ownership> Ownerships { get; set; } = new List<Ownership>();
        public ICollection<Treatment> Treatments { get; set; }
    }

}
