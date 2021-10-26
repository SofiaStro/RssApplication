﻿using Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ICategoryRepository<T> : IRepository<T> where T : Category
    {
        //T GetByName(string name);

        int GetIndex(string name);

    }
}
