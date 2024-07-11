using BPCloud_OBD.VendorMasterService.Models;

namespace BPCloud_OBD.VendorMasterService.Repositories
{
    public interface IFieldMasterRepository
    {
        List<CBPFieldMaster> GetAllOnBoardingFieldMaster();
        List<CBPIdentity> GetAllIdentityFields();
        Task<CBPFieldMaster> UpdateOnBoardingFieldMaster(CBPFieldMaster OnBoardingFieldMaster);
    }
}
