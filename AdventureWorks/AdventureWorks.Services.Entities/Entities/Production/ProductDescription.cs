//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System;

namespace AdventureWorks.Services.Entities
{
    ///<summary>
    /// Product descriptions in several languages.
    ///</summary>
    public partial class ProductDescription
    {
        public ProductDescription()
        {
        }

        #region Properties

        public int ProductDescriptionId  { get; set; }

        ///<summary>
        /// Description of the product.
        ///</summary>
        public string Description  { get; set; }

        ///<summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        ///</summary>
        public Guid Rowguid  { get; set; }

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public DateTime ModifiedDate  { get; set; }

        #endregion
    }
}