using BPCloud_OBD.VendorMasterService.Models;

namespace BPCloud_OBD.VendorMasterService.Repositories
{
    public interface ITitleRepository
    {
        List<CBPTitle> GetAllTitles();
        Task<CBPTitle> CreateTitle(CBPTitle Title);
        Task<CBPTitle> UpdateTitle(CBPTitle Title);
        Task<CBPTitle> DeleteTitle(CBPTitle Title);
    }
}
