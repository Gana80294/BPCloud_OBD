using BPCloud_OBD.VendorMasterService.Models;

namespace BPCloud_OBD.VendorMasterService.Repositories
{
    public interface IAppRepository
    {
        List<CBPApp> GetAllApps();
        Task<CBPApp> CreateApp(CBPApp App);
        Task<CBPApp> UpdateApp(CBPApp App);
        Task<CBPApp> DeleteApp(CBPApp App);

        public GspAuthResponse GetGspAuthToken();
    }
}
