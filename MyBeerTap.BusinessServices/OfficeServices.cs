
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using MyBeerTap.Data.UnitOfWork;
using MyBeerTap.Model;
using MyBeerTap.Data.Models;
using System.Transactions;

namespace MyBeerTap.Services
{
   public class OfficeServices : IOfficeServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public OfficeServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Fetches office details by id
        /// </summary>
        /// <param name="officeId"></param>
        /// <returns></returns>
        public Office GetOfficeById(int officeId)
        {
            var office = _unitOfWork.OfficeRepository.GetByID(officeId);
            if (office != null)
            {

                Mapper.CreateMap<OfficeEntity, Office>();
                var officeModel = Mapper.Map<OfficeEntity, Office>(office);
                return officeModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the offices.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Office> GetAllOffices()
        {
            var offices = _unitOfWork.OfficeRepository.GetAll().ToList();
            if (offices.Any())
            {
                Mapper.CreateMap<OfficeEntity, Office>();
                var officesModel = Mapper.Map<List<OfficeEntity>, List<Office>>(offices);
                return officesModel;
            }
            return null;
        }

        /// <summary>
        /// Creates an office
        /// </summary>
        /// <param name="office"></param>
        /// <returns></returns>
        public int CreateOffice(Office office)
        {
            using (var scope = new TransactionScope())
            {
                var newOffice = new OfficeEntity()
                {
                    Name = office.Name
                };
                _unitOfWork.OfficeRepository.Insert(newOffice);
                _unitOfWork.Save();
                scope.Complete();
                return newOffice.Id;
            }
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="officeId"></param>
        /// <param name="office"></param>
        /// <returns></returns>
        public Office UpdateOffice(int officeId, Office office)
        {
            Office officeModel = null;
            if (office != null)
            {
                using (var scope = new TransactionScope())
                {
                    var  newOffice = _unitOfWork.OfficeRepository.GetByID(officeId);
                    if (newOffice != null)
                    {
                        newOffice.Name = office.Name;
                        _unitOfWork.OfficeRepository.Update(newOffice);
                        _unitOfWork.Save();
                        scope.Complete();
                        Mapper.CreateMap<OfficeEntity, Office>();
                        officeModel = Mapper.Map<OfficeEntity, Office>(newOffice);
                    }
                }
            }
       
              return officeModel;
        }

        /// <summary>
        /// Deletes a particular product
        /// </summary>
        /// <param name="officeId"></param>
        /// <returns></returns>
        public bool DeleteOffice(int officeId)
        {
            var success = false;
            if (officeId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.OfficeRepository.GetByID(officeId);
                    if (product != null)
                    {

                        _unitOfWork.OfficeRepository.Delete(product);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}

 
