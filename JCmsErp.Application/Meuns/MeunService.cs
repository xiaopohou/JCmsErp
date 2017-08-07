using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCmsErp.Meuns
{
    public  class MeunService:IMeunService
    {
        private readonly IRepository<Meun, int> _meunRepository;
        public ILogger Logger { get; set; }
        public MeunService(IRepository<Meun, int> meunRepository)
        {
            Logger = NullLogger.Instance;
            _meunRepository = meunRepository;
        }
        public List<MeunDto> GetAllList()
        {
            var meun = _meunRepository.GetAllList();
            return new List<MeunDto>(
                meun.MapTo<List<MeunDto>>()
                );
        }
    }
}
