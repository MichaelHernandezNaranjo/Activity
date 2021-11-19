using Activity.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Interfaces
{
    public interface IRepository<TRequest, TResponse> where TRequest : baseEntity
    {
        Task<List<TResponse>> GetAll();
        Task<TResponse> GetById(int id);
        Task<int> Add(TRequest entity);
        Task<bool> Update(TRequest entity);
        Task<bool> Delete(int id);
    }

    public interface IRepository4<TRequest, TResponse> where TRequest : baseEntity
    {
        Task<List<TResponse>> GetAll(int id, int id2, int id3);
        Task<TResponse> GetById(int Id, int id2, int id3, int id4);
        Task<int> Add(TRequest entity);
        Task<bool> Update(TRequest entity);
        Task<bool> Delete(int id, int id2, int id3, int id4);
    }

    public interface IRepository3<TRequest, TResponse> where TRequest : baseEntity
    {
        Task<List<TResponse>> GetWhere(int id, int id2, List<string> Where);
        Task<List<TResponse>> GetAll(int id, int id2);
        Task<TResponse> GetById(int Id, int id2, int id3);
        Task<int> Add(TRequest entity);
        Task<bool> Update(TRequest entity);
        Task<bool> Delete(int id, int id2, int id3);
    }

    public interface IRepository2<TRequest, TResponse> where TRequest : baseEntity
    {
        Task<List<TResponse>> GetAll(int id);
        Task<TResponse> GetById(int Id, int id2);
        Task<int> Add(TRequest entity);
        Task<bool> Update(TRequest entity);
        Task<bool> Delete(int id, int id2);
    }

    public interface IRepository<T> where T : baseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }

}
