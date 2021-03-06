﻿using System.Collections.Generic;
using PortableCore.BL.Models;
using PortableCore.DL;

namespace PortableCore.BL.Managers
{
    public interface IIdiomManager
    {
        int SaveItem(Idiom item);
        Idiom GetItemForId(int id);
        List<DirectionIdiomItem> GetListDirections();
        void InsertItemsInTransaction(IEnumerable<Idiom> items);
    }
}