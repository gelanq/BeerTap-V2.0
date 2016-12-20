using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using MyBeerTap.BusinessServices;
using MyBeerTap.Data.Models;
using MyBeerTap.Data.UnitOfWork;
using MyBeerTap.Model;

namespace MyBeerTap.Services
{
    public class TapServices: ITapServices
    {

        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public TapServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Fetches Tap details by id
        /// </summary>
        /// <param name="tapId"></param>
        /// <returns></returns>
        public Tap GetTapById(int tapId)
        {
            var tap = _unitOfWork.TapRepository.GetByID(tapId);
            if (tap != null)
            {

                Mapper.CreateMap<TapEntity, Tap>();
                var tapModel = Mapper.Map<TapEntity, Tap>(tap);
                return tapModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the taps in an office.
        /// </summary>
        /// <param name="officeId"></param>
        /// <returns></returns> 
        public IEnumerable<Tap> GetAllTapsByOfficeId(int officeId)
        {
            var items = _unitOfWork.TapRepository.GetWithInclude(t => t.OfficeId == officeId, "Keg").ToList();
            Mapper.CreateMap<TapEntity, Tap>().ConvertUsing<TapEntityToTapConverter>(); 
            var itemsModel = Mapper.Map<List<TapEntity>, List<Tap>>(items);
            return itemsModel;
            
           
        }

        public int CreateTap(Tap tap)
        {
            throw new NotImplementedException();
        }

        public Office UpdateTap(int tapId, Tap tap)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTap(int tapId)
        {
            throw new NotImplementedException();
        }

        public Tap ReplaceKeg(int tapId, Keg keg)
        {
            //Get tap by Id
            TapEntity tapEntity = _unitOfWork.TapRepository.GetByID(tapId);
            if (tapEntity != null)
            {

             

                using (var scope = new TransactionScope())
                {
                    //Get Keg by TapId
                    var oldKeg = _unitOfWork.KegRepository.GetFirst(k => k.TapId == tapId);
                    if (oldKeg != null)
                    {
                        //Update the Old Keg
                        oldKeg.TapId = null;
                        _unitOfWork.KegRepository.Update(oldKeg);
                       

                    }
                    //Update the Tap with the new Keg
                    Mapper.CreateMap<Keg, KegEntity>();
                    var kegModel = Mapper.Map<Keg, KegEntity>(keg);
                    tapEntity.Keg = kegModel;


                    //Add new Keg
                    _unitOfWork.KegRepository.Insert(kegModel);


                    _unitOfWork.Save();
                    scope.Complete();


                }
            }

            return GetTapById(tapId);

        }

      
      
 
       
    }
}
