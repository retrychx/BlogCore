using System;
namespace Blog.Core.Model.Models
{

    public class PasswordLib
    {
        public int PLID { get; set; }

        public bool? IsDeleted { get; set; }

        public string plURL { get; set; }

        public string plPWD { get; set; }

        public string plAccountName { get; set; }

        public int? plStatus { get; set; }

        public int? plErrorCount { get; set; }

        public string plHintPwd { get; set; }

        public string plHintquestion { get; set; }

        public DateTime? plCreateTime { get; set; }

        public DateTime? plUpdateTime { get; set; }

        public DateTime? plLastErrTime { get; set; }

        public string test { get; set; }
    }
}
