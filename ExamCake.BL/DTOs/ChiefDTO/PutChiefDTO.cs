using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.BL.DTOs.ChiefDTO
{
    public record PutChiefDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public IFormFile? Image { get; set; }
        public int DesignationId {get; set; }


    }
    public class PutChiefDTOValidation : AbstractValidator<PutChiefDTO>
    {
        public PutChiefDTOValidation()
        {
            RuleFor(c => c.FullName).NotEmpty().WithMessage("Fullname is required").MinimumLength(3).WithMessage("Fullname Length must be longer than 3").MaximumLength(40).WithMessage("Fullname length must be shorter than 50");
            RuleFor(c => c.Image).NotEmpty().WithMessage("Image is required");
            RuleFor(c => c.DesignationId).NotEmpty().WithMessage("Designation is required");
        }
    }

}
