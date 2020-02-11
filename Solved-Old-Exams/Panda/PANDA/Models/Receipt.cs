using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PANDA.Models
{
    public class Receipt
    {
        public Receipt()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        [ForeignKey("User"), Required]
        public string RecipientId { get; set; }

        public User Recipient { get; set; }

        [ForeignKey("Package"), Required]
        public string PackageId { get; set; }

        public Package Package { get; set; }
    }
}
