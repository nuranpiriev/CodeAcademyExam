using AutoMapper;
using ExamCake.BL.DTOs.ChiefDTO;
using ExamCake.BL.Services.Abstracts;
using ExamCake.DAL.Models;
using ExamCake.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.BL.Services.Concrets
{
    public class ChiefService : IChiefService
    {
        readonly IRepository<Chief> _repository;
        readonly IMapper _mapper;
        readonly IWebHostEnvironment _webHostEnvironment;

        public ChiefService(IRepository<Chief> repository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task CreateChiefAsync(PostChiefDTO dto)
        {
            Chief chief = _mapper.Map<Chief>(dto);
            chief.CreatedAt = DateTime.Now;
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            var uploadedFileExtn = Path.GetExtension(dto.Image.FileName);
            var fileName = Path.ChangeExtension(Guid.NewGuid().ToString(), uploadedFileExtn);
            using (var stream = System.IO.File.OpenWrite(Path.Combine(imagePath, fileName)))
            {
                dto.Image.CopyTo(stream);
            }

            chief.ImageUrl = fileName;
            await _repository.CreateAsync(chief);
            await _repository.SaveChangesAsync();

        }

        public async Task<ICollection<GetChiefDTO>> GetAllChiefAsync()
        {
            ICollection<Chief> chiefs =await _repository.GetAllAsync("Designation");
            if (chiefs == null) throw new Exception("no chiefs");

            return  _mapper.Map<ICollection<GetChiefDTO>>(chiefs);

        }

        public async Task<GetChiefDTO> GetChiefByIdAsync(int id)
        {
            Chief chief = await _repository.GetByIdAsync(id);
            if (chief == null) throw new Exception("no chief");
            return _mapper.Map<GetChiefDTO>(chief);
        }

        public async Task HardDeleteChiefAsync(int id)
        {
            Chief chief =await _repository.GetByIdAsync(id);
            if (chief == null) throw new Exception("no chief");
            _repository.DeleteAsync(chief);
            await _repository.SaveChangesAsync();
        }

        public async Task RestoreChiefAsync(int id)
        {
            Chief chief = await _repository.GetByIdAsync(id);
            if (chief == null) throw new Exception("no chief");
            chief.IsDeleted = true;
            chief.UpdatedAt = DateTime.Now;
            chief.DeletedAt = DateTime.Now;
            _repository.UpdateAsync(chief);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteChiefAsync(int id)
        {
            Chief chief = await _repository.GetByIdAsync(id);
            if (chief == null) throw new Exception("no chief");
            chief.IsDeleted = false;
            chief.UpdatedAt = DateTime.Now;
            chief.DeletedAt = null;
            _repository.UpdateAsync(chief);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateChiefAsync(int id, PutChiefDTO dto)
        {
            Chief chief = _mapper.Map<Chief>(dto);
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            var uploadedFileExtn = Path.GetExtension(dto.Image.FileName);
            var fileName = Path.ChangeExtension(Guid.NewGuid().ToString("N"), uploadedFileExtn);
            using (var stream = System.IO.File.OpenWrite(Path.Combine(imagePath, fileName)))
            {
                dto.Image.CopyTo(stream);
            }
            
            Chief updateChief = await _repository.GetByIdAsync(id);

            updateChief.CreatedAt=chief.CreatedAt;
            updateChief.UpdatedAt=DateTime.Now;
            updateChief.ImageUrl = fileName;
            _repository.UpdateAsync(updateChief);
            await _repository.SaveChangesAsync();

        }
    } 
}
