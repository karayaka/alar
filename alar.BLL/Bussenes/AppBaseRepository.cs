using alar.BLL.Interfaces;
using alar.DAL.AlarDataContext;
using alar.DAL.Classes.BaseObjects;
using alar.DAL.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace alar.BLL.Bussenes
{
    public class AppBaseRepository : IAppBaseRepositoriys
    {
        private readonly DataContext context;

        private int UserID;

        public AppBaseRepository(DataContext _context, IHttpContextAccessor httpContextAccessor)
        {
            //Kullanıcı Giriş Yöntemleri karşışatıtran bir yapı kurulacak
            context = _context;
            var val = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (val != null)
                UserID = Convert.ToInt32(val.Value);
        }
        /// <summary>
        /// Generik Olarak Ekleme Metodu
        /// Eklenen Objeyi döndürüyor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entitiy"></param>
        /// <returns></returns>
        public async Task<T> Add<T>(T Entitiy) where T : BaseObject
        {
            try
            {
                Entitiy.CreatedDate = DateTime.Now;
                Entitiy.CreatedBy = UserID;
                Entitiy.LastUpdateBy = UserID;
                Entitiy.LastUpdateDate = DateTime.Now;
                Entitiy.ObjectStatus = ObjectStatus.NonDeleted;
                Entitiy.Status = Status.Active;
                await context.AddAsync(Entitiy);
                return Entitiy;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public async Task<IEnumerable<T>> AddRange<T>(IEnumerable<T> models) where T : BaseObject
        {
            try
            {
                foreach (var item in models)
                {
                    item.CreatedDate = DateTime.Now;
                    item.CreatedBy = UserID;
                    item.LastUpdateBy = UserID;
                    item.LastUpdateDate = DateTime.Now;
                    item.ObjectStatus = ObjectStatus.NonDeleted;
                    item.Status = Status.Active;
                }
                await context.AddRangeAsync(models);

                return models;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Delete<T>(int ID) where T : BaseObject
        {
            try
            {
                var model = context.Set<T>().FirstOrDefault(t => t.ID == ID);
                model.LastUpdateDate = DateTime.Now;
                model.ObjectStatus = ObjectStatus.Deleted;
                model.LastUpdateBy = UserID;
                model.Status = Status.Pasive;
                context.Update(model);
                return ID;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void DeleteRange<T>(IEnumerable<T> models) where T : BaseObject
        {
            try
            {
                foreach (var model in models)
                {
                    model.LastUpdateDate = DateTime.Now;
                    model.ObjectStatus = ObjectStatus.Deleted;
                    model.LastUpdateBy = UserID;
                    model.Status = Status.Pasive;
                    context.Update(model);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<T> Get<T>(Expression<Func<T, bool>> expression) where T : BaseObject
        {
            try
            {
                return context.Set<T>().Where(expression);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> GetByID<T>(int ID) where T : BaseObject
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(t => t.ID == ID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<T> GetIQueryableByID<T>(int ID) where T : BaseObject
        {
            try
            {
                return context.Set<T>().Where(t => t.ID == ID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<T> GetNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseObject
        {
            try
            {
                IQueryable<T> models;
                if (expression != null)                
                    models = context.Set<T>().Where(expression);                
                else                
                    models = context.Set<T>();
                
                return models.Where(t => t.ObjectStatus == ObjectStatus.NonDeleted);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<T> GetNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseObject
        {
            try
            {
                return GetNonDeleted<T>(t => t.Status == Status.Active);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<T> GetNonDeletedAndPaginate<T>(int pageID, int PageSize) where T : BaseObject
        {
            try
            {
                //Lokayona göre filitrelenecek metod düşünülecek
                pageID--;
                return GetNonDeletedAndActive<T>(t=>true).Skip(pageID * PageSize).Take(PageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Remove<T>(int ID) where T : BaseObject
        {
            try
            {
                var model = await GetByID<T>(ID);
                context.Remove(model);
                return ID;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void RemoveRange<T>(IEnumerable<T> models) where T : BaseObject
        {
            try
            {
                context.RemoveRange(models);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string SaveFile(List<IFormFile> files, string folderName)
        {
            string fileName = null;
            try
            {
                var file = files[0];
                var path = Path.Combine("Resource", folderName);

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), path);//TEstamaçlıYAzıldı
                if (file.Length > 0)
                {
                    var fileKey = Guid.NewGuid();
                    var ex = Path.GetExtension(file.FileName);
                    fileName = folderName + "-" + fileKey + ex;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return fileName;
            }
            catch (Exception ex)
            {
                return fileName;
            }
        }

        public string SaveImage(List<IFormFile> files, string folderName)
        {
            //Image Resize Yapılaca,

            throw new NotImplementedException();
        }

        public async Task<T> Update<T>(T Entitiy) where T : BaseObject
        {
            try
            {
                Entitiy.LastUpdateBy = UserID;
                Entitiy.LastUpdateDate = DateTime.Now;
                Entitiy.ObjectStatus = ObjectStatus.NonDeleted;
                Entitiy.Status = Status.Active;
                context.Update(Entitiy);
                return Entitiy;                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> UpdateRange<T>(IEnumerable<T> models) where T : BaseObject
        {
            try
            {
                foreach (var item in models)
                {
                    item.LastUpdateBy = UserID;
                    item.LastUpdateDate = DateTime.Now;
                    item.ObjectStatus = ObjectStatus.NonDeleted;
                    item.Status = Status.Active;                    
                }
                context.UpdateRange(models);
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
