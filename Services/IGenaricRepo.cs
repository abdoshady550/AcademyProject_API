using AcademyProject_API.Model.Entities;

namespace AcademyProject_API.Services
{
    public interface IGenaricRepo<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> Add(T item);
        public Task<T> UpdateAsync(T item, T itemUpdated);
        public Task<T> Delete(T tiem);
    }
}
