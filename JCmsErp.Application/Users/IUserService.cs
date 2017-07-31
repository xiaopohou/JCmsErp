using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCmsErp.User
{
     public  interface IUserService: IApplicationService
    {
        Task <ListResultDto<UserInfoDto>> GetUsers();
        Task  AddUserList(UserInfoDto model);
        Task  DelUsers(string id);
    }


}
