 

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyBeerTap.Model
{

    /// <summary>
    /// State of the Keg
    /// </summary> 
    public enum KegState
     {

       ///// <summary>
       ///// No keg
       ///// </summary>
       // NoKeg,

        /// <summary>
        /// Keg is   going down. Not yet available for replacement.
        /// </summary> 
  
        New,
        /// <summary>
        /// Keg is   going down. Not yet available for replacement.
        ///  
        /// </summary> 
        GoingDown,

        /// <summary>
        /// 
        /// Keg is almost empty then a link to “replaceKeg” would be there 
        /// </summary> 
        AlmostEmpty,
        /// <summary>
        /// Keg is dry then a link to “replaceKeg” would be there
        ///  
        /// </summary> 
        SheIsDryMate

    }

    /// <summary>
    /// Beer Tap
    /// </summary> 
    public class Tap :  IStatefulResource<KegState>, IIdentifiable<int>, ITapStateful, IStatelessResource
    {

        /// <summary>
        /// Id
        ///  
        /// </summary> 
        public int Id { get; set; }

        /// <summary>
        /// Label(Beer name) of the Tap
        /// </summary> 
        public string Label { get; set; }

        /// <summary>
        /// Office Id of the Tap
        /// </summary> 
        public int OfficeId { get; set; }

        /// <summary>
        /// State of the Keg(from Keg)
        /// </summary> 
        public KegState KegState  { get; set; }

        /// <summary>
        /// Amount of the remaining beer in the keg
        /// </summary> 
        public double? RemainingBeer  { get; set; }
        

    }
}