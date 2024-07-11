using BPCloud_OBD.VendorRegistrationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPCloud_OBD.VendorRegistrationService.Repositories
{
    public interface IQuestionnaireRepository
    {
        Task<bool> SaveAnswers(List<Answers> AnswerList);
    }
}
