﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortableCore.BL.Contracts;
using PortableCore.BL.Models;
using PortableCore.DAL;
using PortableCore.DL;
using System.IO;

namespace PortableCore.BL.Managers
{
    public class IdiomCategoryManager : IInitDataTable<IdiomCategory>, IIdiomCategoryManager
    {
        readonly ISQLiteTesting db;
        private ILanguageManager languageManager;


        public IdiomCategoryManager(ISQLiteTesting dbHelper, ILanguageManager languageManager)
        {
            this.db = dbHelper;
            this.languageManager = languageManager;
        }

        public void ClearTable()
        {
            DAL.Repository<IdiomCategory> repos = new DAL.Repository<IdiomCategory>();
            repos.DeleteAllDataInTable();
        }

        public void InitDefaultData()
        {
            Repository<IdiomCategory> repos = new Repository<IdiomCategory>();
            IdiomCategory[] data = GetDefaultData();
            int hashOriginalData = data.Sum(i=>i.ID);
            int hashRepositoryData = repos.GetHashForItems();
            if(hashOriginalData != hashRepositoryData)
            {
                repos.DeleteAllDataInTable();
                repos.AddItemsInTransaction(data);
            }
        }

        private IdiomCategory[] GetDefaultData()
        {
            var eng = languageManager.GetItemForShortName("en").ID;
            var rus = languageManager.GetItemForShortName("ru").ID;
            IdiomCategory[] list = new IdiomCategory[] {
                new IdiomCategory (){ ID=1, LanguageFrom = eng, LanguageTo = rus, TextFrom = "Common terms", TextTo="Обозначения"},
                new IdiomCategory (){ ID=2, LanguageFrom = eng, LanguageTo = rus, TextFrom = "Common phrases", TextTo="Распространенные фразы"},
                new IdiomCategory (){ ID=3, LanguageFrom = eng, LanguageTo = rus, TextFrom = "Talks", TextTo="Поддержание разговора"},
                new IdiomCategory (){ ID=4, LanguageFrom = eng, LanguageTo = rus, TextFrom = "Common phrases", TextTo="Вводные и завершающие фразы"},
                new IdiomCategory (){ ID=5, LanguageFrom = eng, LanguageTo = rus, TextFrom = "Common phrases", TextTo="Основные фразы"},
                new IdiomCategory (){ ID=6, LanguageFrom = eng, LanguageTo = rus, TextFrom = "About life", TextTo="Фразы о жизни"},
                new IdiomCategory (){ ID=7, LanguageFrom = eng, LanguageTo = rus, TextFrom = "Short phrases", TextTo="Короткие фразы"},
                new IdiomCategory (){ ID=8, LanguageFrom = eng, LanguageTo = rus, TextFrom = "Discussions", TextTo="Дискуссии"},
                new IdiomCategory (){ ID=9, LanguageFrom = eng, LanguageTo = rus, TextFrom = "Business", TextTo="Деловые фразы"},
                new IdiomCategory (){ ID=10, LanguageFrom = eng, LanguageTo = rus, TextFrom = "Simple phrases", TextTo="Простые фразы"},
                new IdiomCategory (){ ID=11, LanguageFrom = eng, LanguageTo = rus, TextFrom = "Time", TextTo="Фразы о времени"},
                new IdiomCategory (){ ID=12, LanguageFrom = eng, LanguageTo = rus, TextFrom = "Writing letter", TextTo="Фразы для писем"},
            };

            return list;
        }

        private int getHash()
        {
            return 0;
        }
        public IdiomCategory GetItemForId(int id)
        {
            Repository<IdiomCategory> repos = new Repository<IdiomCategory>();
            return repos.GetItem(id);
        }

        public int SaveItem(IdiomCategory item)
        {
            Repository<IdiomCategory> repo = new Repository<IdiomCategory>();
            return repo.Save(item);
        }
    }
}
