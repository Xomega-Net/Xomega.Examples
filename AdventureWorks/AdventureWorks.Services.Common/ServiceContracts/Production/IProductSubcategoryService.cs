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
    #region IProductSubcategoryService interface

    ///<summary>
    /// Product subcategories. See ProductCategory table.
    ///</summary>
    [ServiceContract]
    public interface IProductSubcategoryService
    {

        ///<summary>
        /// Reads a list of Product Subcategory objects based on the specified criteria.
        ///</summary>
        [OperationContract]
        Task<Output<ICollection<ProductSubcategory_ReadListOutput>>> ReadListAsync();

    }
    #endregion

    #region ProductSubcategory_ReadListOutput structure

    ///<summary>
    /// The output structure of operation IProductSubcategoryService.ReadListAsync.
    ///</summary>
    [DataContract]
    public class ProductSubcategory_ReadListOutput
    {
        
        [DataMember]
        public int ProductSubcategoryId { get; set; }
        
        ///<summary>
        /// Product category identification number. Foreign key to ProductCategory.ProductCategoryID.
        ///</summary>
        [DataMember]
        public int ProductCategoryId { get; set; }
        
        ///<summary>
        /// Subcategory description.
        ///</summary>
        [DataMember]
        public string Name { get; set; }
    }
    #endregion

}