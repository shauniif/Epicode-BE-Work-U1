using Esercizio_S5_WebApp.Models;

namespace Esercizio_S5_WebApp.Services
{
    public interface ICrudService<E> where E : BaseEntity
    {
        void Create(E entity);
        void Update(E entity);

        void Delete(int id);
        E GetById(int id);

    }
}
