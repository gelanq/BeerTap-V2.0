using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyBeerTap.Data.Models;
using MyBeerTap.Model;

namespace MyBeerTap.BusinessServices
{
    public class TapEntityToTapConverter: ITypeConverter<TapEntity, Tap>
    {
     
        public Tap Convert(ResolutionContext context)
        {
            TapEntity source = context.SourceValue as TapEntity;

            Tap tap = new Tap();

            tap.Id = source.Id  ;
            tap.RemainingBeer = source.Keg.Remaining;
            tap.Label = source.Label;
            tap.OfficeId = source.OfficeId;
            tap.KegState = GetKegState(source.Keg);

            return tap;

             
        }

        private static KegState GetKegState(KegEntity keg)
        {
            if (keg.Capacity == keg.Remaining)
                return KegState.New;
            else if (keg.Remaining < 0.1) //ml
                return KegState.SheIsDryMate;
            else if (keg.Remaining < 500) //ml
                return KegState.AlmostEmpty;

            else
                return KegState.GoingDown;
        }
    }
}
