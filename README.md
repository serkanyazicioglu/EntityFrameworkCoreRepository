[![.NET](https://github.com/serkanyazicioglu/EntityFrameworkCoreRepository/actions/workflows/dotnet-pipeline.yml/badge.svg)](https://github.com/serkanyazicioglu/EntityFrameworkCoreRepository/actions/workflows/dotnet-pipeline.yml)
[![NuGet](https://img.shields.io/nuget/v/Nhea.Data.Repository.EntityFrameworkCoreRepository.svg)](https://www.nuget.org/packages/Nhea.Data.Repository.EntityFrameworkCoreRepository/)

# Nhea Entity Framework Core Repository

Nhea base repository classes for EF Core


## Getting Started

Nhea is on NuGet. You may install Nhea Entity Framework Core Repository via NuGet Package manager.

https://www.nuget.org/packages/Nhea.Data.Repository.EntityFrameworkCoreRepository/

### Prerequisites

Project is built with .NET 9.0

This project references 
-	Nhea > 4.0.1.0
-	Microsoft.EntityFrameworkCore >= 9.0.1

### Configuration

After initializing your data model (Code-First, Db-First etc.) creating a base repository class is a good idea to set basic properties.

```
public abstract class BaseSqlRepository<T> : Nhea.Data.Repository.EntityFrameworkCoreRepository.BaseEntityFrameworkCoreRepository<T>, IDisposable where T : class, new()
{
    private Microsoft.EntityFrameworkCore.DbContext _currentDbContext;
    protected override Microsoft.EntityFrameworkCore.DbContext CurrentContext
    {
        get
        {
            if (_currentDbContext == null)
            {
                _currentDbContext = new MyDataContext();
            }

            return _currentDbContext;
        }
    }
}
```

You may remove the abstract modifier if you want to use generic repositories or you may create individual repository classes for your tables if you want to set specific properties for that object.

```
public class MemberRepository : BaseSqlRepository<Member>
    {
        public override Member CreateNew()
        {
            var entity = base.CreateNew();
            entity.Id = Guid.NewGuid();
            entity.CreateDate = DateTime.Now;
            entity.Status = (int)StatusType.Available;

            return entity;
        }

        public override Expression<Func<Member, object>> DefaultSorter => query => new { query.CreateDate };

        protected override SortDirection DefaultSortType => SortDirection.Descending;

        public override Expression<Func<Member, bool>> DefaultFilter => query => query.Status == (int)StatusType.Available;
    }
```

Then in your code just initalize a new instance of your class and call appropriate methods for your needs.

```
//Create new record
using (MemberRepository memberRepository = new MemberRepository())
{
    var member = memberRepository.CreateNew();
    member.Title = "Test Member";
    member.UserName = "username";
    member.Password = "password";
    member.Email = "test@test.com";
    memberRepository.Save();
}

//Get multi and update
using (MemberRepository memberRepository = new MemberRepository())
{
    var members = memberRepository.GetAll(query => query.CreateDate >= DateTime.Today).ToList();

    foreach (var member in members)
    {
        member.Title += " Lastname";
    }

    memberRepository.Save();
}

//Get single by id and update
using (MemberRepository memberRepository = new MemberRepository())
{
    var member = memberRepository.GetById(new Guid("4D33AB34-5C5C-4A03-AF18-5C5FE6FC121A"));
    member.Title = "Selected Member";
    memberRepository.Save();
}

//Get single by filter and update
using (MemberRepository memberRepository = new MemberRepository())
{
    var member = memberRepository.GetSingle(query => query.Title == "Selected Member");
    member.Title = "Selected Member 2";
    memberRepository.Save();
}

//Delete record
using (MemberRepository memberRepository = new MemberRepository())
{
    memberRepository.Delete(query => query.Title == "Selected Member 2");
    memberRepository.Save();
}

//Check is new record
using (MemberRepository memberRepository = new MemberRepository())
{
    var member = memberRepository.CreateNew();
    bool isNew = memberRepository.IsNew(member);
}
```
