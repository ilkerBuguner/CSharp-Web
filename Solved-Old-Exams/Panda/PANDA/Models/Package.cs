using PANDA.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PANDA.Models
{
    public class Package
    {
        public Package()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [MinLength(5), MaxLength(20), Required]
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDeliveryDate  { get; set; }

        [ForeignKey("User"), Required]
        public string RecipientId { get; set; }

        public User Recipient { get; set; }
    }
}
