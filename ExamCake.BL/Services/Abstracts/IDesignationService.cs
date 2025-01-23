using ExamCake.BL.DTOs.DesignationDTO;

namespace ExamCake.BL.Services.Abstracts
{
    public interface IDesignationService
    {
        Task CreateDesignationAsync(PostDesignationDTO dto);
        Task UpdateDesignationAsync(int id, PutDesignationDTO dto);
        Task SoftDeleteDesignationAsync(int id);
        Task HardDeleteDesignationAsync(int id);
        Task RestoreDesignationAsync(int id);
        Task<ICollection<GetDesignationDTO>> GetAllDesignationAsync();
        Task<GetDesignationDTO> GetDesignationByIdAsync(int id);
    }
}
