using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Models.ConsumableModels;

namespace DnDTeamGame.Services.ConsumableServices
{
    public interface IConsumableService
    {
        Task<ConsumableDetail?> CreateNewConsumableAsync(ConsumableCreate request);
        Task<IEnumerable<ConsumableList>> GetAllConsumablesAsync();
        Task<ConsumableDetail?> GetConsumableByIdAsync(int consumableId);
        Task<bool> UpdateConsumableAsync(ConsumableUpdate request);
        Task<bool> DeleteConsumableAsync(int consumableId);
    }
}