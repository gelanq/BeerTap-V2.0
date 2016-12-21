using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBeerTap.Model;

namespace MyBeerTap.Services
{
    public interface ITapServices
    {
        Tap GetTapById(int tapId);
        IEnumerable<Tap> GetAllTapsByOfficeId(int officeId);
        int CreateTap(Tap tap);
        Office UpdateTap(int tapId, Tap tap);
        bool DeleteTap(int tapId);


        Tap ReplaceKeg(int tapId, Keg keg);
        Tap GetBeer(int tapId, Glass glass);
    }
}
