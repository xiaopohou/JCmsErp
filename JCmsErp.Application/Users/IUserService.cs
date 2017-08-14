using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCmsErp.User
{
    /// <summary>
    /// 用户接口
    /// </summary>
     public  interface IUserService: IApplicationService
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        Task <ListResultDto<UserInfoDto>> GetUsers();
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task  AddUserList(UserInfoDto model);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        Task  DelUsers(string id);
        bool Login(string UserName, string password);

        List<UserInfoDto> GetAllList();


        string AddorUpdateUserList(UserInfoDto model);

        string DelUser(string id);
    }


}
