using BPCloud_OBD.VendorMasterService.Models;

namespace BPCloud_OBD.VendorMasterService.Repositories
{
    public interface ITypeRepository
    {
        List<CBPType> GetAllTypes();
        Task<CBPType> CreateType(CBPType type);
        Task<CBPType> UpdateType(CBPType type);
        Task<CBPType> DeleteType(CBPType type);
    }
}
