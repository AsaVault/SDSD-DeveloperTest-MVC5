using SDSD_DeveloperTest_MVC5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDSD_DeveloperTest_MVC5.ViewModel
{
    public class IndexViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Transaction Id", Prompt = "Enter your Unique Id")]
        public string TransactionId { get; set; }
        [Required]
        [Display(Name = "Email", Prompt = "Enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserUpload> Files { get; set; }
        public IEnumerable<UserDetail> Users { get; set; }
    }
}
