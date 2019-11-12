using MovieStore.Core;
using MovieStore.Core.EntityFramework;
using MovieStore.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Data.SubStructure
{
    public interface IBaseService<D>
        where D : BaseEntity, IBaseEntity, new()
    {
        IList<D> GetAll(Expression<Func<D, bool>> expr);

        Task<D> GetByIdAsync(Guid id);
        IList<D> GetAll();

        Task<D> Add(D model, Guid? userId = null, bool isCommit = true);
        Task<D> Update(Guid id, D model, Guid? userId = null, bool isCommit = true);
        Task<bool> Delete(Guid id, Guid? userId = null, bool isCommit = true);
        Task<bool> ReverseDelete(Guid id, Guid? userId, bool isCommit = true);
        D GetById(Guid id);
        Task<bool> Commit();
    }

    public class BaseService<D> : IBaseService<D>
         where D : BaseEntity, IBaseEntity, new()
    {
        protected IRepository<D> Repository;

        public BaseService(IRepository<D> repository)
        {
            Repository = repository;
        }

        public virtual async Task<D> GetByIdAsync(Guid id)
        {
            try
            {
                if (Validation.IsNullOrEmpty(id))
                    return null;

                return await Repository.GetByID(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual D GetById(Guid id)
        {
            try
            {
                D dm = Repository.Query().Where(x => x.Id == id).FirstOrDefault();
                if (Validation.IsNull(dm))
                    return null;

                return dm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual IList<D> GetAll()
        {
            try
            {
                return Repository.Query().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual IList<D> GetAll(Expression<Func<D, bool>> expr)
        {
            try
            {
                return Repository.Query().Where(expr).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<D> Add(D model, Guid? userId = null, bool isCommit = true)
        {
            try
            {
                Guid _userId = userId == null ? Guid.Empty : userId.Value;

                if (model.Id == null || model.Id == Guid.Empty)
                    model.Id = Guid.NewGuid();

                if (model is ITableEntity)
                {
                    (model as ITableEntity).CreatedBy = _userId;
                    (model as ITableEntity).CreateDateTime = DateTime.Now;
                }

                Repository.Add(model);

                if (isCommit)
                    await Commit();

                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual async Task<D> Update(Guid id, D model, Guid? userId = null, bool isCommit = true)
        {
            try
            {
                Guid _userId = userId == null ? Guid.Empty : userId.Value;

                D oldRec = await Repository.GetByID(id);
                if (Validation.IsNull(oldRec))
                    return null;

                ModelCopier.CopyModel(model, oldRec);

                if (oldRec is ITableEntity)
                {
                    (oldRec as ITableEntity).UpdateBy = _userId;
                    (oldRec as ITableEntity).UpdateDateTime = DateTime.Now;
                }

                Repository.Update(oldRec);

                if (isCommit)
                    await Commit();

                return oldRec;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual async Task<bool> Delete(Guid id, Guid? userId = null, bool isCommit = true)
        {
            try
            {
                Guid _userId = userId == null ? Guid.Empty : userId.Value;

                D entity = await Repository.GetByID(id);
                if (Validation.IsNull(entity))
                    return false;

                if (entity is ITableEntity)
                {
                    (entity as ITableEntity).UpdateBy = _userId;
                    (entity as ITableEntity).UpdateDateTime = DateTime.Now;
                }

                entity.IsDeleted = true;
                Repository.Update(entity);

                if (isCommit)
                    await Commit();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual async Task<bool> ReverseDelete(Guid id, Guid? userId, bool isCommit = true)
        {
            try
            {
                Guid _userId = userId == null ? Guid.Empty : userId.Value;

                D entity = await Repository.GetByID(id);
                if (Validation.IsNull(entity))
                    return false;

                if (entity is ITableEntity)
                {
                    (entity as ITableEntity).UpdateBy = _userId;
                    (entity as ITableEntity).UpdateDateTime = DateTime.Now;
                }

                entity.IsDeleted = false;
                Repository.Update(entity);

                if (isCommit)
                    await Commit();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<bool> Commit()
        {
            try
            {
                await Repository.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
