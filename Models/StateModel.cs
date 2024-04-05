#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models;

public partial class StateModel
{
    [Key]
    public int StateId { get; set; }

    public string StateName { get; set; }

    public int CountryId { get; set; }

    public virtual ICollection<CityModel> Cities { get; set; } = new List<CityModel>();

    public virtual CountryModel Country { get; set; }
}