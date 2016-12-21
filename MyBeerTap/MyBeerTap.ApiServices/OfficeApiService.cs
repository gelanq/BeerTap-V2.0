
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;
using MyBeerTap.ApiServices.Security;
using MyBeerTap.Model;
using MyBeerTap.Services;



namespace MyBeerTap.ApiServices
{
    public class OfficeApiService: IOfficeApiService
    {
        readonly IApiUserProvider<MyBeerTapApiUser> _userProvider;
        private readonly IOfficeServices _officeService;



        public OfficeApiService(IApiUserProvider<MyBeerTapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _officeService = new OfficeServices();

        }


        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {

            
            var office = _officeService.GetOfficeById(id);
            return Task.FromResult(office);
             
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
           

            var offices = _officeService.GetAllOffices();
            return Task.FromResult(offices);
            
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            ;
             return Task.FromResult(new ResourceCreationResult<Office, int>(_officeService.CreateOffice(resource)));

        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            var id = context.UriParameters.GetByName<int>("Id").EnsureValue(() => context.CreateHttpResponseException<Office>("The Id must be supplied in the URI", HttpStatusCode.BadRequest));
           
            return Task.FromResult(_officeService.UpdateOffice(id, resource));

        }

        public Task DeleteAsync(ResourceOrIdentifier<Office, int> input, IRequestContext context, CancellationToken cancellation)
        {
            var id = context.UriParameters.GetByName<int>("Id").EnsureValue(() => context.CreateHttpResponseException<Office>("The Id must be supplied in the URI", HttpStatusCode.BadRequest));
            _officeService.DeleteOffice(id);
            return Task.FromResult<Office>(null);
            
        }

    }
}
