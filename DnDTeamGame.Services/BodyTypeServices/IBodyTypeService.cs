using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Models.BodyTypeModels;
namespace DnDTeamGame.Services.BodyTypeServices
{
    public interface IBodyTypeService
    {
        Task<BodyTypeList?> CreateBodyTypeAsync(BodyTypeCreate request);
        Task<IEnumerable<BodyTypeList>> GetAllBodyTypesAsync();
        Task<BodyTypeDetail?> GetBodyTypeByIdAsync(int bodyTypeId);
        Task<bool> UpdateBodyTypeAsync(BodyTypeUpdate request);
        Task<bool> DeleteBodyTypeAsync(int bodyTypeId);
    }
}