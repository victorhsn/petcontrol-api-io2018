using System.Collections.Generic;
using Google.Cloud.Vision.V1;
using Microsoft.AspNetCore.Http;
using PetControl.Domain.Services;
using Feature = PetControl.Domain.Entities.Feature;

namespace PetControl.Infra.Services
{
    public class VisionService : IVisionService

    {
        private readonly IList<Feature> _list;

        public VisionService()
        {
            _list = new List<Feature>();
        }

        public IList<Feature> Identify(IFormFile file)
        {
            
            var imagem = Image.FromStream(file.OpenReadStream());
            var client = ImageAnnotatorClient.Create();
            
            var response = client.DetectLabels(imagem);
            
            foreach(var annontation in response) 
            {
                var feature = new Feature(annontation.Description, annontation.Score);
               
                _list.Add(feature);
            }

            return _list;
        }
    }
}