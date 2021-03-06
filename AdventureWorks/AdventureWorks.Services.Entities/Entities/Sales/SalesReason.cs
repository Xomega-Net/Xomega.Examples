//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System;

namespace AdventureWorks.Services.Entities
{
    ///<summary>
    /// Lookup table of customer purchase reasons.
    ///</summary>
    public partial class SalesReason
    {
        public SalesReason()
        {
        }

        #region Properties

        public int SalesReasonId  { get; set; }

        ///<summary>
        /// Sales reason description.
        ///</summary>
        public string Name  { get; set; }

        ///<summary>
        /// Category the sales reason belongs to.
        ///</summary>
        public string ReasonType  { get; set; }

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public DateTime ModifiedDate  { get; set; }

        #endregion
    }
}