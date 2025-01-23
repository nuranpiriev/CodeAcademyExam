using AutoMapper;
using ExamCake.BL.DTOs.DesignationDTO;
using ExamCake.BL.Services.Abstracts;
using ExamCake.DAL.Models;
using ExamCake.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace ExamCake.BL.Services.Concrets
{
    public class DesignationService : IDesignationService
    {
        readonly IRepository<Designation> _repository;
        readonly IMapper _mapper;
        readonly IWebHostEnvironment _webHostEnvironment;

        public DesignationService(IRepository<Designation> repository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task CreateDesignationAsync(PostDesignationDTO dto)
        {
            Designation chief = _mapper.Map<Designation>(dto);
            await _repository.CreateAsync(chief);
            await _repository.SaveChangesAsync();

        }

        public async Task<ICollection<GetDesignationDTO>> GetAllDesignationAsync()
        {
            ICollection<Designation> chiefs =await _repository.GetAllAsync("Chiefs");
            if (chiefs == null) throw new Exception("no chiefs");

            return  _mapper.Map<ICollection<GetDesignationDTO>>(chiefs);

        }

        public async Task<GetDesignationDTO> GetDesignationByIdAsync(int id)
        {
            Designation chief = await _repository.GetByIdAsync(id);
            if (chief == null) throw new Exception("no chief");
            return _mapper.Map<GetDesignationDTO>(chief);
        }

        public async Task HardDeleteDesignationAsync(int id)
        {
            Designation chief =await _repository.GetByIdAsync(id);
            if (chief == null) throw new Exception("no chief");
            _repository.DeleteAsync(chief);
            await _repository.SaveChangesAsync();
        }

        public async Task RestoreDesignationAsync(int id)
        {
            Designation chief = await _repository.GetByIdAsync(id);
            if (chief == null) throw new Exception("no chief");
            chief.IsDeleted = true;
           
            _repository.UpdateAsync(chief);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteDesignationAsync(int id)
        {
            Designation chief = await _repository.GetByIdAsync(id);
            if (chief == null) throw new Exception("no chief");
            chief.IsDeleted = false;
            _repository.UpdateAsync(chief);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateDesignationAsync(int id, PutDesignationDTO dto)
        {
            Designation chief = _mapper.Map<Designation>(dto);
            Designation updateDesignation = await _repository.GetByIdAsync(id);
            _repository.UpdateAsync(updateDesignation);
            await _repository.SaveChangesAsync();

        }
    }
}
