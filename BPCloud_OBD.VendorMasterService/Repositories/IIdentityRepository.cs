using BPCloud_OBD.VendorMasterService.Models;

namespace BPCloud_OBD.VendorMasterService.Repositories
{
    public interface IIdentityRepository
    {
        List<CBPIdentity> GetAllIdentities();
        List<string> GetAllIdentityTypes();       
        CBPIdentity GetIdentityByType(string Type);
        CBPIdentity ValidateIdentityByType(string Type);
        Task<CBPIdentity> CreateIdentity(CBPIdentity Identity);
        Task<CBPIdentity> UpdateIdentity(CBPIdentity Identity);
        Task<CBPIdentity> DeleteIdentity(CBPIdentity Identity);
    }
}
