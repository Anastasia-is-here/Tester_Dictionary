﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tester_Dictionary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DictionaryEntities : DbContext
    {
        private static DictionaryEntities _context;
        public DictionaryEntities()
            : base("name=DictionaryEntities")
        {
        }
        public static DictionaryEntities GetContext()
        {
            if (_context == null)
                _context = new DictionaryEntities();
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<dictionary> dictionary { get; set; }
    }
}