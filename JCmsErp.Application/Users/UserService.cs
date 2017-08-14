using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using Castle.Core.Logging;
using Abp.Domain.Uow;

namespace JCmsErp.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Users, int> _userRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public ILogger Logger { get; set; }
        public UserService(IRepository<Users, int> userRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            Logger = NullLogger.Instance;
            _userRepository = userRepository;
            _unitOfWorkManager = unitOfWorkManager;
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



        public string AddorUpdateUserList(UserInfoDto model)
        {
            string Stars = "ok";
            try
            {
                if (model.id==0)
                {
                    Users user = new Users();
                   
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.Password = string.IsNullOrWhiteSpace(model.Password) ? "123456" : model.Password;
                    user.Address = string.IsNullOrWhiteSpace(model.Email) ? "深南大道" : model.Email;
                    user.Phone = string.IsNullOrWhiteSpace(model.Phone) ? "123456789" : model.Phone;
                    user.TrueName = string.IsNullOrWhiteSpace(model.TrueName) ? "user" : model.TrueName;
                    user.Enabled = true;
                    user.CreationTime = DateTime.Now;
                    user.CreatorUserId = 11;
                    user.LastModificationTime = DateTime.Now;
                    user.IsDeleted = false;
                    user.UpdateDate =DateTime.Now;
                    _userRepository.Insert(user);
                }
                else
                {
                    Users user = _userRepository.Get(model.id);
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.Password = string.IsNullOrWhiteSpace(model.Password) ? "123456" : model.Password;
                    user.Address = string.IsNullOrWhiteSpace(model.Email) ? "深南大道" : model.Email;
                    user.Phone = string.IsNullOrWhiteSpace(model.Phone) ? "123456789" : model.Phone;
                    user.TrueName = string.IsNullOrWhiteSpace(model.TrueName) ? "user" : model.TrueName;
                    user.Enabled = true;
                    user.CreationTime = DateTime.Now;
                    user.CreatorUserId = 11;
                    user.LastModificationTime = DateTime.Now;
                    user.IsDeleted = false;
                    _userRepository.Update(user);

                }
               _unitOfWorkManager.Current.SaveChanges();



            }
            catch (Exception ex)
            {

                throw;
            }

            return Stars;

        }



        public string DelUser(string id)
        {

            string Start = "ok";
            try
            {


                var userEntity = _userRepository.Get(Int32.Parse(id));
                if (userEntity == null)
                {
                    return Start = "你删除的对象不存在";
                }
                else
                {
                    Users user = _userRepository.Get(Int32.Parse(id));
                    _userRepository.Delete(user);
                    _unitOfWorkManager.Current.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Start;

        }


    }
}
