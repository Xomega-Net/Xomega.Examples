//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Service Contracts" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;
using Xomega.Framework.Services;

namespace AdventureWorks.Services
{
    #region ISpecialOfferProductService interface

    ///<summary>
    /// Cross-reference table mapping products to special offer discounts.
    ///</summary>
    [ServiceContract]
    public interface ISpecialOfferProductService
    {

        ///<summary>
        /// Reads a list of Special Offer Product objects based on the specified criteria.
        ///</summary>
        [OperationContract]
        Task<Output<ICollection<SpecialOfferProduct_ReadListOutput>>> ReadListAsync(int _productId);

    }
    #endregion

    #region SpecialOfferProduct_ReadListOutput structure

    ///<summary>
    /// The output structure of operation ISpecialOfferProductService.ReadListAsync.
    ///</summary>
    [DataContract]
    public class SpecialOfferProduct_ReadListOutput
    {
        
        [DataMember]
        public int SpecialOfferId { get; set; }
        
        [DataMember]
        public string Description { get; set; }
        
        [DataMember]
        public decimal? Discount { get; set; }
        
        [DataMember]
        public int? MinQty { get; set; }
        
        [DataMember]
        public int? MaxQty { get; set; }
        
        [DataMember]
        public bool? Active { get; set; }
    }
    #endregion

}