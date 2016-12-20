using System.Collections.Generic;
using MyBeerTap.Model;

namespace MyBeerTap.Services
{
    public interface IOfficeServices
    {

        Office GetOfficeById(int officeId);
        IEnumerable<Office> GetAllOffices();
        int CreateOffice(Office office);
        Office UpdateOffice(int officeId, Office office);
        bool DeleteOffice(int officeId);
    }
}
