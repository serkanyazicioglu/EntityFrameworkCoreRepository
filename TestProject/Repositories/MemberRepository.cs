//using Nhea.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject
//{
//    public class MemberRepository : BaseSqlRepository<Member>
//    {
//        public override Member CreateNew()
//        {
//            var entity = base.CreateNew();
//            entity.Id = Guid.NewGuid();
//            entity.CreateDate = DateTime.Now;
//            entity.Status = (int)StatusType.Available;

//            return entity;
//        }

//        public override Expression<Func<Member, object>> DefaultSorter => query => new { query.CreateDate };

//        protected override SortDirection DefaultSortType => SortDirection.Descending;

//        public override Expression<Func<Member, bool>> DefaultFilter => query => query.Status == (int)StatusType.Available;
//    }
//}
