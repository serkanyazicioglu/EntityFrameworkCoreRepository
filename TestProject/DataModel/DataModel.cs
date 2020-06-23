//namespace TestProject
//{
//    using System;
//    using System.Data.Entity;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Linq;

//    public partial class DataModel : DbContext
//    {
//        public DataModel()
//            : base("name=DataModel")
//        {
//        }

//        public virtual DbSet<Member> Member { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Member>()
//                .Property(e => e.HashSalt)
//                .IsUnicode(false);
//        }
//    }
//}
