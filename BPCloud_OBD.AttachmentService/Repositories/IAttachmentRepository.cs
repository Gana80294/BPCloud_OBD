
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPCloud_OBD.AttachmentService.Controllers
{
    public interface IAttachmentRepository
    {
        Task<UserAttachment> AddAttachment(UserAttachment userAttachment);
        List<UserAttachment> FilterAttachments(string ProjectName, int AppID = 0, string AppNumber = null);
        UserAttachment GetAttachmentByID(int AttachmentID);
    }
}
