using BPCloud_OBD.VendorMasterService.Models;

namespace BPCloud_OBD.VendorMasterService.Repositories
{
    public interface IBankRepository
    {
        List<CBPBank> GetAllBanks();
        CBPBank GetBankByIFSC(string IFSC);
        Task<CBPBank> CreateBank(CBPBank Bank);
        Task<CBPBank> UpdateBank(CBPBank Bank);
        Task<CBPBank> DeleteBank(CBPBank Bank);
    }
}
