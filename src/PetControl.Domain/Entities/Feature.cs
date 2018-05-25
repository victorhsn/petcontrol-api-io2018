using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace PetControl.Domain.Entities
{
    public class Feature : Notifiable
    {
        public Feature(string descripton, float score) 
        {
      
            Description = descripton;
            Score = Math.Round(score * 100);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Description, "Feature.Description", "The feature description can not be empty."));
        }
    
        public string Description { get; private set; }  
    
        public double Score { get; private set; }
    }
}