using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using PetControl.Domain.Entities;

namespace PetControl.Domain.Services
{
    public interface IVisionService
    {
        IList<Feature> Identify(IFormFile file);
    }
}