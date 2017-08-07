using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCmsErp.Meuns
{
   public  interface IMeunService : IApplicationService
    {
        List<MeunDto> GetAllList();
    }
}
