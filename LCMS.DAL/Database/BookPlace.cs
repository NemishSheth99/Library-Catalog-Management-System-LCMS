//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LCMS.DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookPlace
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookPlace()
        {
            this.TransactionHistories = new HashSet<TransactionHistory>();
        }
    
        public int Id { get; set; }
        public Nullable<int> BookCatalogId { get; set; }
        public string PlaceCode { get; set; }
        public string MaterialType { get; set; }
        public Nullable<int> BorrowedBy { get; set; }
        public Nullable<System.DateTime> BorrowedOn { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual BookCatalog BookCatalog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
