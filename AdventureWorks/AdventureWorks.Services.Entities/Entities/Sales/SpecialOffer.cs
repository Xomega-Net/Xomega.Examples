//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System;

namespace AdventureWorks.Services.Entities
{
    ///<summary>
    /// Sale discounts lookup table.
    ///</summary>
    public partial class SpecialOffer
    {
        public SpecialOffer()
        {
        }

        #region Properties

        public int SpecialOfferId  { get; set; }

        ///<summary>
        /// Discount description.
        ///</summary>
        public string Description  { get; set; }

        ///<summary>
        /// Discount precentage.
        ///</summary>
        public decimal DiscountPct  { get; set; }

        ///<summary>
        /// Discount type category.
        ///</summary>
        public string Type  { get; set; }

        ///<summary>
        /// Group the discount applies to such as Reseller or Customer.
        ///</summary>
        public string Category  { get; set; }

        ///<summary>
        /// Discount start date.
        ///</summary>
        public DateTime StartDate  { get; set; }

        ///<summary>
        /// Discount end date.
        ///</summary>
        public DateTime EndDate  { get; set; }

        ///<summary>
        /// Minimum discount percent allowed.
        ///</summary>
        public int MinQty  { get; set; }

        ///<summary>
        /// Maximum discount percent allowed.
        ///</summary>
        public int? MaxQty  { get; set; }

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