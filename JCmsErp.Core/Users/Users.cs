using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCmsErp.User
{
    [Table("Users")]
    public class Users : Entity<int>, IHasCreationTime
    {

        /// <summary>
        /// 登录名称
        /// </summary>
        [StringLength(20)]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string TrueName { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool Enabled { get; set; }
        public string StrEnabled
        {
            get
            {
                return Enabled == true ? "是" : "否";
            }
        }
        public interface ICreationAudited : IHasCreationTime
        {
            /// <summary>
            /// 创建人id
            /// </summary>
            long? CreatorUserId { get; set; }
            /// <summary>
            /// 最后更新时间
            /// </summary>
            DateTime? LastModificationTime { get; set; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        public Users()
        {
            CreationTime = DateTime.Now;
        }
        //软删除
        public interface ISoftDelete
        {
            /// <summary>
            /// 是否删除
            /// </summary>
            bool IsDeleted { get; set; }
        }
    }
}
