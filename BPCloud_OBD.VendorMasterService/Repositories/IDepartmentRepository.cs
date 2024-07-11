using BPCloud_OBD.VendorMasterService.Models;

namespace BPCloud_OBD.VendorMasterService.Repositories
{
    public interface IDepartmentRepository
    {
        List<CBPDepartment> GetAllDepartments();
        Task<CBPDepartment> CreateDepartment(CBPDepartment Department);
        Task<CBPDepartment> UpdateDepartment(CBPDepartment Department);
        Task<CBPDepartment> DeleteDepartment(CBPDepartment Department);
    }
}
