using BPCloud_OBD.VendorMasterService.Models;

namespace BPCloud_OBD.VendorMasterService.Repositories
{
    public interface IPostalRepository
    {
        List<CBPPostal> GetAllPostals();
        Task<CBPPostal> CreatePostal(CBPPostal Postal);
        Task<CBPPostal> UpdatePostal(CBPPostal Postal);
        Task<CBPPostal> DeletePostal(CBPPostal Postal);
    }
}
