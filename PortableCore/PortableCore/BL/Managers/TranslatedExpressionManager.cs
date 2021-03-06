﻿using System;
using System.Collections.Generic;
using System.Linq;
using PortableCore.BL.Contracts;
using PortableCore.DL;
using PortableCore.DAL;

namespace PortableCore.BL.Managers
{
	public class TranslatedExpressionManager : IInitDataTable<TranslatedExpression>
    {
        ISQLiteTesting db;

        public TranslatedExpressionManager(ISQLiteTesting dbHelper)
        {
            db = dbHelper;
        }

        public void InitDefaultData()
        {
        }

		public bool NeedUpdateDefaultData()
		{
			return false;
		}

        public TranslatedExpression GetItemForId(int id)
        {
            Repository<TranslatedExpression> repos = new Repository<TranslatedExpression>();
            TranslatedExpression result = repos.GetItem(id);
            return result;
        }

		public List<TranslatedExpression> GetItems()
		{
			Repository<TranslatedExpression> repos = new Repository<TranslatedExpression> ();
			return new List<TranslatedExpression> (repos.GetItems ());
		}

        public List<TranslatedExpression> GetListOfTranslatedExpression(List<SourceDefinition> listOfDefinitions)
        {
            var arrayDefinitionIDs = from item in listOfDefinitions select item.ID;
            var view = from trItem in SqlLiteInstance.DB.Table<TranslatedExpression>()
                       where arrayDefinitionIDs.Contains(trItem.SourceDefinitionID)
                       select trItem;
            return view.ToList();
        }

    }
}

