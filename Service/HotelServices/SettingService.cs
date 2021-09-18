using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.HotelServices.Contracts;
using CoreModel.Entities.Settings;
using Persistence.Contracts;

namespace Service.HotelServices
{
    class SettingService : BaseService<BookingSetting>, ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SettingService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
