using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models
{
    public interface ICityRepository
    {
        CityModel GetCityById(int cityId);
        void SaveCity(CityModel city);
        void DeleteCity(int cityId);
    }

    public partial class CityModel : ICityRepository
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int StateId { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

        public virtual StateModel State { get; set; }

        public CityModel GetCityById(int cityId)
        {
            // TODO: Implement logic to fetch city by ID
            throw new NotImplementedException();
        }

        public void SaveCity(CityModel city)
        {
            // TODO: Implement logic to save/update city
            throw new NotImplementedException();
        }

        public void DeleteCity(int cityId)
        {
            // TODO: Implement logic to delete city by ID
            throw new NotImplementedException();
        }
    }
}
