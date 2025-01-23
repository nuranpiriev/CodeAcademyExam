using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.BL.DTOs.ChiefDTO
{
    public record GetChiefDTO
    {
        public int Id { get; set; }
        public string FullName {  get; set; }
        public string ImageUrl {  get; set; }
        public string Designation {  get; set; }
        public int DesignationId { get; set; }
    }
   
}
