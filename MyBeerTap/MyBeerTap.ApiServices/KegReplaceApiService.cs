using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
   public class KegReplaceApiService: IKegReplaceApiService
    {
        readonly IApiUserProvider<MyBeerTapApiUser> _userProvider;
        private readonly ITapServices _tapService;



        public KegReplaceApiService(IApiUserProvider<MyBeerTapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _tapService = new TapServices();
        }

 

        public Task<ResourceCreationResult<ReplaceKeg, int>> CreateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            
            var tapId = context.UriParameters.GetByName<int>("TapId").EnsureValue(() => context.CreateHttpResponseException<Tap>("The TapId must be supplied in the URI", HttpStatusCode.BadRequest));
          
            Tap tap = _tapService.ReplaceKeg(tapId, resource.Keg);
            resource.Tap = tap;
            return Task.FromResult(new ResourceCreationResult<ReplaceKeg, int>(resource));

        }

        public Task<ReplaceKeg> UpdateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {


            throw new NotImplementedException();
        }

      
    }
}
