using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace SDSD_DeveloperTest_MVC5.ViewModel
{
    public class CreateViewModel
    {
        public Guid Id { get; set; }
        public string TransactionId { get; set; }
        [Required]
        [Display(Name = "Full Name", Prompt = "Enter your full name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email", Prompt = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Upload Files", Prompt = "Attach file(s) to upload")]
        [NotMapped]
        public List<HttpPostedFileBase> FormFiles { get; set; }
    }
}
