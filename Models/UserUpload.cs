using System;

namespace SDSD_DeveloperTest_MVC5.Models
{
    public class UserUpload
    {
        public Guid UserUploadId { get; set; }
        public string TransactionId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Guid UserDetailId { get; set; }
        public UserDetail UserDetail { get; set; }
    }
}