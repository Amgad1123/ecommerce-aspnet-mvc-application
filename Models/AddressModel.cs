#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models;

public partial class Address
{
    [Key]
    public int AddressId { get; set; }

    public string StreetAddress { get; set; }

    public int CityId { get; set; }

    public virtual CityModel City { get; set; }

    public virtual ICollection<UserModel> UserBillingAddresses { get; set; } = new List<UserModel>();

    public virtual ICollection<UserModel> UserShippingAddresses { get; set; } = new List<UserModel>();
}