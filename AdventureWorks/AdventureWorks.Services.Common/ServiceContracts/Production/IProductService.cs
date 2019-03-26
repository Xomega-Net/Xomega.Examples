//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Service Contracts" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using Xomega.Framework;
using Xomega.Framework.Services;

namespace AdventureWorks.Services
{
    #region IProductService interface

    ///<summary>
    /// Products sold or used in the manfacturing of sold products.
    ///</summary>
    [ServiceContract]
    public interface IProductService
    {

        ///<summary>
        /// Reads a list of Product objects based on the specified criteria.
        ///</summary>
        [OperationContract]
        [FaultContract(typeof(ErrorList))]
        Output<ICollection<Product_ReadListOutput>> ReadList();

    }
    #endregion

    #region Product_ReadListOutput structure

    ///<summary>
    /// The output structure of operation IProductService.ReadList.
    ///</summary>
    [DataContract]
    public class Product_ReadListOutput
    {
        
        [DataMember]
        public int ProductId { get; set; }
        
        ///<summary>
        /// Name of the product.
        ///</summary>
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public bool IsActive { get; set; }
        
        ///<summary>
        /// Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. 
        ///</summary>
        [DataMember]
        public int? ProductSubcategoryId { get; set; }
        
        ///<summary>
        /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
        ///</summary>
        [DataMember]
        public int? ProductModelId { get; set; }
    }
    #endregion

}