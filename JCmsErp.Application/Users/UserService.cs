using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using Castle.Core.Logging;

namespace JCmsErp.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Users, int> _userRepository;
        public ILogger Logger { get; set; }
        public UserService(IRepository<Users, int> userRepository)
        {
            Logger = NullLogger.Instance;
            _userRepository = userRepository;
        }
        public async Task AddUserList(UserInfoDto model)
        {
            var user = model.MapTo<Users>();
            await _userRepository.InsertAsync(user);
            Logger.Debug("_userRepository通过构造函数注入注入的方式!");
            Logger.Debug("这是通过属性注入的方式!");
        }

        public async Task DelUsers(string id)
        {
            try
            {
                Users user = _userRepository.Get(Int32.Parse(id));
                await _userRepository.DeleteAsync(user);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<ListResultDto<UserInfoDto>> GetUsers()
        {
            var users = await _userRepository.GetAllListAsync();

            return new ListResultDto<UserInfoDto>(
                users.MapTo<List<UserInfoDto>>()
                );
        }
        public List<UserInfoDto> GetAllList()
        {
            List<UserInfoDto> newlist = new List<UserInfoDto>();

            var data = from s in _userRepository.GetAll()
                       select new UserInfoDto()
                       {
                           id = s.Id,
                           UserName = s.UserName,
                           TrueName = s.TrueName,
                           Password = s.Password,
                           CreationTime = s.CreationTime,
                           Email = s.Email,
                           Phone = s.Phone,
                           Address = s.Address,
                       };

            newlist = data.ToList();

            return newlist;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string UserName, string password)
        {
            var users = _userRepository.GetAllList().Where(o => o.UserName == UserName && o.Password == password);
            return users.Count() > 0;
        }
    }
}
