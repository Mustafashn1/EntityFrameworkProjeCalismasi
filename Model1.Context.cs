﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkProjeÇalışması
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ldbEntitiyProjeEntities : DbContext
    {
        public ldbEntitiyProjeEntities()
            : base("name=ldbEntitiyProjeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_KATEGORİ> TBL_KATEGORİ { get; set; }
        public virtual DbSet<TBL_MUSTERI> TBL_MUSTERI { get; set; }
        public virtual DbSet<TBL_SATIS> TBL_SATIS { get; set; }
        public virtual DbSet<TBL_URUN> TBL_URUN { get; set; }
        public virtual DbSet<Tbl_Admin> Tbl_Admin { get; set; }
    
        public virtual ObjectResult<string> MARKAGETİR()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MARKAGETİR");
        }
    }
}