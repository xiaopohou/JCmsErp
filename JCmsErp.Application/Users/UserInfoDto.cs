using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCmsErp.User
{
    [Serializable]
    [AutoMapFrom(typeof(Users))]
    public class UserInfoDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }
        public string TrueName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public bool Enabled { get; set; }
        public string StrEnabled
        {
            get
            {
                return Enabled == true ? "是" : "否";
            }
        }
        public DateTime CreationTime { get; set; }

    }
}
