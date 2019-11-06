using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.EntityFramework
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        bool IsDeleted { get; set; }
    }

    public interface ITableEntity : IBaseEntity
    {
        Guid CreatedBy { get; set; }
        DateTime CreateDateTime { get; set; }
        Guid? UpdateBy { get; set; }
        DateTime? UpdateDateTime { get; set; }
        
    }

    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class TableEntity : BaseEntity, ITableEntity
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreateDateTime { get; set; }
        public Guid? UpdateBy { get; set; }
        public DateTime? UpdateDateTime { get; set; }        
    }
}
