using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.DAL.Models
{
    public class Designation:BaseEntity
    {
        public string Title {  get; set; }
        public ICollection<Chief> Chiefs { get; set; }

    }
}
