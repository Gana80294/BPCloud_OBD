using BPCloud_OBD.VendorMasterService.Models;

namespace BPCloud_OBD.VendorMasterService.Repositories
{
    public interface ILocationRepository
    {
        CBPLocation GetLocationByPincode(string Pincode);
        List<StateDetails> GetStateDetails();
        List<MyArray> GetLocation(string Pincode);
    }
}
