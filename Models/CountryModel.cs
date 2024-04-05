#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models;

public partial class CountryModel
{
    [Key]
    public int CountryId { get; set; }

    public string CountryName { get; set; }

    public virtual ICollection<StateModel> States { get; set; } = new List<StateModel>();
}