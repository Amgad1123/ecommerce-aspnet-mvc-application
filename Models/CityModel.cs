#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models;

public partial class CityModel
{
    [Key]
    public int CityId { get; set; }

    public string CityName { get; set; }

    public int StateId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual StateModel State { get; set; }
}