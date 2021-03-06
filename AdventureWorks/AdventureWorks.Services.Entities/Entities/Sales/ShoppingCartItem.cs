//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System;

namespace AdventureWorks.Services.Entities
{
    ///<summary>
    /// Contains online customer orders until the order is submitted or cancelled.
    ///</summary>
    public partial class ShoppingCartItem
    {
        public ShoppingCartItem()
        {
        }

        #region Properties

        public int ShoppingCartItemId  { get; set; }

        ///<summary>
        /// Shopping cart identification number.
        ///</summary>
        public string ShoppingCartId  { get; set; }

        ///<summary>
        /// Product quantity ordered.
        ///</summary>
        public int Quantity  { get; set; }

        ///<summary>
        /// Product ordered. Foreign key to Product.ProductID.
        ///</summary>
        public int ProductId  { get; set; }

        ///<summary>
        /// Date the time the record was created.
        ///</summary>
        public DateTime DateCreated  { get; set; }

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public DateTime ModifiedDate  { get; set; }

        #endregion

        #region Navigation Properties

        ///<summary>
        /// Product object referenced by the field ProductId.
        ///</summary>
        public virtual Product ProductObject { get; set; }

        #endregion
    }
}