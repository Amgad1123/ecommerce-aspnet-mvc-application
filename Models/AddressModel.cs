#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models
{
    public interface IAddressRepository
    {
        Address GetAddressById(int addressId);
        void SaveAddress(Address address);
        void DeleteAddress(int addressId);
    }

    public partial class Address : IAddressRepository
    {
        [Key]
        public int AddressId { get; set; }

        public string StreetAddress { get; set; }

        public int CityId { get; set; }

        public virtual CityModel City { get; set; }

        public Address GetAddressById(int addressId)
        {
            // TODO: Implement logic to fetch address by ID
            throw new NotImplementedException();
        }

        public void SaveAddress(Address address)
        {
            // TODO: Implement logic to save/update address
            throw new NotImplementedException();
        }

        public void DeleteAddress(int addressId)
        {
            // TODO: Implement logic to delete address by ID
            throw new NotImplementedException();
        }

        public virtual ICollection<UserModel> UserBillingAddresses { get; set; } = new List<UserModel>();

        public virtual ICollection<UserModel> UserShippingAddresses { get; set; } = new List<UserModel>();
    }
}
