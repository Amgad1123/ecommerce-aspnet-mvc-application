using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models
{
    public interface IStateRepository
    {
        StateModel GetStateById(int stateId);
        void SaveState(StateModel state);
        void DeleteState(int stateId);
    }

    public partial class StateModel : IStateRepository
    {
        [Key]
        public int StateId { get; set; }

        public string StateName { get; set; }

        public int CountryId { get; set; }

        public virtual ICollection<CityModel> Cities { get; set; } = new List<CityModel>();

        public virtual CountryModel Country { get; set; }

        public StateModel GetStateById(int stateId)
        {
            // TODO: Implement logic to fetch state by ID
            throw new NotImplementedException();
        }

        public void SaveState(StateModel state)
        {
            // TODO: Implement logic to save/update state
            throw new NotImplementedException();
        }

        public void DeleteState(int stateId)
        {
            // TODO: Implement logic to delete state by ID
            throw new NotImplementedException();
        }
    }
}
