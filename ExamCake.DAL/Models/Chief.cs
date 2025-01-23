using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.DAL.Models
{
    public class Chief:BaseAuditable
    {
        public string FullName {  get; set; }
        public string ImageUrl {  get; set; }

        public Designation Designation { get; set; }
        public int DesignationId {  get; set; }
    }
}
