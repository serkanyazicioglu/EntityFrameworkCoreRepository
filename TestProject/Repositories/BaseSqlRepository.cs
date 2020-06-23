//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject
//{
//    public abstract class BaseSqlRepository<T> : Nhea.Data.Repository.EntityFrameworkCoreRepository.BaseEntityFrameworkCoreRepository<T>, IDisposable where T : class, new()
//    {
//        private Microsoft.EntityFrameworkCore.DbContext _currentDbContext;
//        protected override Microsoft.EntityFrameworkCore.DbContext CurrentContext
//        {
//            get
//            {
//                if (_currentDbContext == null)
//                {
//                    _currentDbContext = new MyDataContext();
//                }

//                return _currentDbContext;
//            }
//        }
//    }
//}
