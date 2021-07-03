using alar.BLL.DataModels;
using alar.DAL.Classes.BaseObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace alar.BLL.Interfaces
{
    public interface IAppBaseRepositoriys
    {
        /// <summary>
        /// Generik Olarak Ekleme Metodu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entitiy"></param>
        /// <returns></returns>
        Task<T> Add<T>(T Entitiy) where T : BaseObject;

        /// <summary>
        /// Liste OLarak Ekele
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="models"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> AddRange<T>(IEnumerable<T> models) where T : BaseObject;

        /// <summary>
        /// Generik Olarak Güncelleme
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entitiy"></param>
        /// <returns></returns>
        Task<T> Update<T>(T Entitiy) where T : BaseObject;

        /// <summary>
        /// Liste Olarak Günceleme
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entitiy"></param>
        /// <returns></returns>
        Task<int> UpdateRange<T>(IEnumerable<T> models) where T : BaseObject;

        /// <summary>
        /// Generik Olarak Silme Metodu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        Task<int> Delete<T>(int ID) where T : BaseObject;

        /// <summary>
        /// Liste Halinde Silme
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        void DeleteRange<T>(IEnumerable<T> models) where T : BaseObject;

        /// <summary>
        /// ID ile DbSilme
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        Task<int> Remove<T>(int ID) where T : BaseObject;

        /// <summary>
        /// Liste Silme
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        void RemoveRange<T>(IEnumerable<T> models) where T : BaseObject;

        /// <summary>
        /// Get Queryable Generik
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> Get<T>(Expression<Func<T, bool>> expression) where T : BaseObject;

        /// <summary>
        /// Get Queryable NonDeleted
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> GetNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseObject;

        /// <summary>
        /// Get Queryable NonDeleted ve Aktif Kayıtlar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> GetNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseObject;

        /// <summary>
        /// Get Queryable Silinmemiş ve aktif kayıtları 
        /// 20 li kayılar ile bir sayfa
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageID"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        IQueryable<T> GetNonDeletedAndPaginate<T>(int pageID, int PageSize) where T : BaseObject;

        /// <summary>
        /// ID ile getirilmniş onje kayıtları
        /// ınculude yapılamaz!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<T> GetByID<T>(int ID) where T : BaseObject;

        /// <summary>
        /// Inculude yapılabilir id ile alınan kayıtlar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        IQueryable<T> GetIQueryableByID<T>(int ID) where T : BaseObject;

        /// <summary>
        /// Dosya Kaydetme İşlemi Dosya Adı Dönüyor
        /// </summary>
        /// <param name="files"></param>
        /// <param name="folderName"></param>
        /// <param name="path">KayıtOLacak Dosya Yolu</param>
        /// <returns></returns>
        string SaveFile(IFormFile file, string folderName, string path);

        /// <summary>
        /// Resim Defauld Boyutlama ile resim yükleme
        /// </summary>
        /// <param name="files"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        ImageResultModel SaveImage(IFormFile file, string folderName,string path);
    }
}
