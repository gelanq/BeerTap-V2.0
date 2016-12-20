﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;
using MyBeerTap.ApiServices.Security;
using MyBeerTap.Model;
using MyBeerTap.Model.Data;
using MyBeerTap.Services;

namespace MyBeerTap.ApiServices
{
   public class TapApiService: ITapApiService
   {
        private readonly ITapServices _tapService;
        readonly IApiUserProvider<MyBeerTapApiUser> _userProvider;

        public TapApiService(IApiUserProvider<MyBeerTapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _tapService = new TapServices();

        }


        public Task<Tap> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {

            var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue(() => context.CreateHttpResponseException<Tap>("The officeId must be supplied in the URI", HttpStatusCode.BadRequest));

            var tap = _tapService.GetTapById(id);
            return Task.FromResult(tap);
        }

        public Task<IEnumerable<Tap>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
           var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue(() => context.CreateHttpResponseException<Tap>("The officeId must be supplied in the URI", HttpStatusCode.BadRequest));
     

            var taps = _tapService.GetAllTapsByOfficeId(officeId);
            return Task.FromResult(taps);

            throw new NotImplementedException();
    }


        public Task<Tap> UpdateAsync(Tap resource, IRequestContext context, CancellationToken cancellation)
        {
        //_repository = new BeeerTapRepository();

        //return   Task.FromResult(_repository.UpdateTap( resource));

        throw new NotImplementedException();
    }


        public Task<ResourceCreationResult<Tap, int>> CreateAsync(Tap resource, IRequestContext context, CancellationToken cancellation)
        {
        //  _repository = new BeeerTapRepository();

        //  Keg keg = resource.Keg;
        ////  resource.Keg = null;

        //  Tap tap = resource;
        //  tap = _repository.AddTap(resource);

        //  if (keg != null)
        //  {
        //      keg.TapId  = tap.Id;
        //      _repository.ReplaceKeg(resource.Keg);
        //  }


        //  return Task.FromResult(new ResourceCreationResult<Tap, int>(resource));
        throw new NotImplementedException();
    }

      
        public Task DeleteAsync(ResourceOrIdentifier<Tap, int> input, IRequestContext context, CancellationToken cancellation)
        {
            // _repository = new BeeerTapRepository();
            // var tapId = context.UriParameters.GetByName<int>("Id").EnsureValue(() => context.CreateHttpResponseException<Tap>("The TapId must be supplied in the URI", HttpStatusCode.BadRequest));
            //_repository.UpdateKeg(tapId);
            //_repository.RemoveTap(tapId);
            // return Task.FromResult<Tap>(null);
            throw new NotImplementedException();
        }


    }
}