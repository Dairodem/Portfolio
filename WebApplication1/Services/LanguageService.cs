using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public interface ILanguageService
    {
        LanguageDTO GetById(int id);
        IEnumerable<LanguageListDTO> GetMany();
        void Create(LanguageDTO project);
        void Update(int id, LanguageDTO project);
        void Delete(int id);
    }
    public class LanguageService : ILanguageService
    {
        private readonly aDatabase _appDB;
        public LanguageService(aDatabase db)
        {
            _appDB = db;
        }
        public LanguageDTO GetById(int id)
        {
            var lang = _appDB.Languages.Where(x => x.Id == id).FirstOrDefault();

            return new LanguageDTO
            {
                Id = lang.Id,
                Name = lang.Name,
            };
        }
        public IEnumerable<LanguageListDTO> GetMany()
        {
            var langList = _appDB.Languages.
                Select(x =>
                new LanguageListDTO
                {
                    Name = x.Name
                });

            return langList;
        }
        public void Create(LanguageDTO lang)
        {
            var newLang = new Language
            {
                Id = GetNewId(),
                Name = lang.Name,
            };

            _appDB.Languages.Add(newLang);

            // if there was a database:
            //_appDB.SaveChanges();

        }
        public void Update(int id, LanguageDTO lang)
        {
            var oldLang = _appDB.Languages.SingleOrDefault(x => x.Id == id);

            if (oldLang != null)
            {
                oldLang.Name = lang.Name;

                // if there was a database:
                //_appDB.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            var lang = _appDB.Languages.SingleOrDefault(x => x.Id == id);
            if (lang != null)
            {
                _appDB.Languages.Remove(lang);

                // if there was a database:
                //_appDB.SaveChanges();
            }
        }
        private int GetNewId()
        {
            int id = 0;
            for (int i = 0; i < _appDB.Languages.Count; i++)
            {
                if (_appDB.Languages[i].Id > id)
                {
                    id = _appDB.Languages[i].Id;
                }
            }

            return id;
        }
    }
}
