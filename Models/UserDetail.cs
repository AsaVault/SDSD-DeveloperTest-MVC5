using System;
using System.Collections.Generic;

namespace SDSD_DeveloperTest_MVC5.Models
{
    public class UserDetail
    {
        public Guid UserDetailId { get; set; }
        public string TransactionId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<UserUpload> UserUpload { get; set; }
    }
}