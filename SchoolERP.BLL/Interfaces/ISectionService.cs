using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolERP.Data.Entities;
namespace SchoolERP.BLL.Interfaces
{
    public interface ISectionService
    {
        Task<IEnumerable<Section>> GetAllSectionsAsync();
        Task<Section> GetSectionByIdAsync(int id);
        Task AddSectionAsync(Section section);
        Task UpdateSectionAsync(Section section);
        Task DeleteSectionAsync(int id);
    }
}
