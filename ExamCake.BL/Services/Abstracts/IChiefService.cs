using ExamCake.BL.DTOs.ChiefDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.BL.Services.Abstracts
{
    public interface IChiefService
    {
        Task CreateChiefAsync(PostChiefDTO dto);
        Task UpdateChiefAsync(int id,PutChiefDTO dto);
        Task SoftDeleteChiefAsync(int id);
        Task HardDeleteChiefAsync(int id);
        Task RestoreChiefAsync(int id);
        Task<ICollection<GetChiefDTO>> GetAllChiefAsync();
        Task<GetChiefDTO> GetChiefByIdAsync(int id);
    }
}
