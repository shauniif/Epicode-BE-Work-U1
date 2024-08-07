﻿using Esercizio_S5_WebApp.Models;

namespace Esercizio_S5_WebApp.Services
{
    public interface ICrudService<E> where E : BaseEntity
    {
        IEnumerable<E> GetAll();

    }
}
