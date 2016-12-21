using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;
using MyBeerTap.ApiServices.Security;
using MyBeerTap.Model;
using MyBeerTap.Services;

namespace MyBeerTap.ApiServices
{
    public class PourBeerApiService: IPourBeerApiService
    {
        readonly IApiUserProvider<MyBeerTapApiUser> _userProvider;
        private readonly ITapServices _tapService;


        public PourBeerApiService(IApiUserProvider<MyBeerTapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _tapService = new TapServices();

        }
        public Task<ResourceCreationResult<PourBeer, int>> CreateAsync(PourBeer resource, IRequestContext context, CancellationToken cancellation)
        {
        

            var tapId = context.UriParameters.GetByName<int>("TapId").EnsureValue(() => context.CreateHttpResponseException<Tap>("The TapId must be supplied in the URI", HttpStatusCode.BadRequest));
            var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue(() => context.CreateHttpResponseException<Office>("The Office must be supplied in the URI", HttpStatusCode.BadRequest));
            resource.Id = tapId;
            resource.Glass.TapId = tapId;
            resource.OfficeId = officeId;

           Tap tap = _tapService.GetBeer(tapId, resource.Glass);
           resource.Tap = tap;
            
           return Task.FromResult(new ResourceCreationResult<PourBeer, int>(resource));
        }

    }
}
