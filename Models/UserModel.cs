#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_store.Models;

public partial class UserModel
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [Display(Name = "User Name")]
    public string Username { get; set; }

    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]   
    public string PasswordHash { get; set; }
    public string ReturnUrl {  get; set; }
    public int ShippingAddressId { get; set; }

    public int BillingAddressId { get; set; }

    public virtual Address BillingAddress { get; set; }

    public virtual ICollection<OrderModel> Orders { get; set; } = new List<OrderModel>();

    public virtual Address ShippingAddress { get; set; }
}