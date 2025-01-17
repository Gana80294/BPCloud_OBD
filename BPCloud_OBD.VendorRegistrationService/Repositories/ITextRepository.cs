﻿using BPCloud_OBD.VendorRegistrationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPCloud_OBD.VendorRegistrationService.Repositories
{
    public interface ITextRepository
    {
        List<BPText> GetAllTexts();
        Task<BPText> CreateText(BPText Text);
        Task<BPText> UpdateText(BPText Text);
        Task<BPText> DeleteText(BPText Text);

    }
}
