//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "EF Domain Objects" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System;

namespace AdventureWorks.Services.Entities
{
    ///<summary>
    /// Cross-reference table mapping stores, vendors, and employees to people
    ///</summary>
    public partial class BusinessEntityContact
    {
        public BusinessEntityContact()
        {
        }

        #region Properties

        ///<summary>
        /// Primary key. Foreign key to BusinessEntity.BusinessEntityID.
        ///</summary>
        public int BusinessEntityId  { get; set; }

        ///<summary>
        /// Primary key. Foreign key to Person.BusinessEntityID.
        ///</summary>
        public int PersonId  { get; set; }

        ///<summary>
        /// Primary key.  Foreign key to ContactType.ContactTypeID.
        ///</summary>
        public int ContactTypeId  { get; set; }

        ///<summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        ///</summary>
        public Guid Rowguid  { get; set; }

        ///<summary>
        /// Date and time the record was last updated.
        ///</summary>
        public DateTime ModifiedDate  { get; set; }

        #endregion

        #region Navigation Properties

        ///<summary>
        /// BusinessEntity object referenced by the field BusinessEntityId.
        ///</summary>
        public virtual BusinessEntity BusinessEntityObject { get; set; }

        ///<summary>
        /// Person object referenced by the field PersonId.
        ///</summary>
        public virtual Person PersonObject { get; set; }

        ///<summary>
        /// ContactType object referenced by the field ContactTypeId.
        ///</summary>
        public virtual ContactType ContactTypeObject { get; set; }

        #endregion
    }
}