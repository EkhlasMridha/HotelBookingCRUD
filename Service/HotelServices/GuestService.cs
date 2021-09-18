using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.HotelServices.Contracts;
using CoreModel.Entities.Guests;
using Persistence.Contracts;

namespace Service.HotelServices
{
    class GuestService : BaseService<Guest>, IGuestService
    {
        private IUnitOfWork _unitOfWork;
        public GuestService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
