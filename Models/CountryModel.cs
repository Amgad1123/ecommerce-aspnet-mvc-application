using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models
{
    public interface ICountryRepository
    {
        CountryModel GetCountryById(int countryId);
        void SaveCountry(CountryModel country);
        void DeleteCountry(int countryId);
    }

    public partial class CountryModel : ICountryRepository
    {
        [Key]
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public virtual ICollection<StateModel> States { get; set; } = new List<StateModel>();

        public CountryModel GetCountryById(int countryId)
        {
            // TODO: Implement logic to fetch country by ID
            throw new NotImplementedException();
        }

        public void SaveCountry(CountryModel country)
        {
            // TODO: Implement logic to save/update country
            throw new NotImplementedException();
        }

        public void DeleteCountry(int countryId)
        {
            // TODO: Implement logic to delete country by ID
            throw new NotImplementedException();
        }
    }
}
