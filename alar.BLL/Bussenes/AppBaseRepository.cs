using alar.BLL.DataModels;
using alar.BLL.Interfaces;
using alar.DAL.AlarDataContext;
using alar.DAL.Classes.BaseObjects;
using alar.DAL.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
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


        public string SaveFile(IFormFile file, string folderName,string path)
        {
            string fileName = null;
            try
            {               
                var Imagepath = Path.Combine(path, folderName);

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), Imagepath);//TEstamaçlıYAzıldı
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

        public ImageResultModel SaveImage(IFormFile file, string folderName, string path)
        {
            try
            {
                var retVal = new ImageResultModel();


                using (var image = Image.Load(file.OpenReadStream()))
                {
                    string systemFileExtenstion = Path.GetExtension(file.FileName);
                    //org
                    var newfileNameorg = GenerateFileName("Photo_org_", systemFileExtenstion);
                    var filepathorg = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, "org")) + $@"\{newfileNameorg}";

                    image.Save(filepathorg);
                    retVal.ImageOrjin = newfileNameorg;

                    //1080
                    var ratioX18 = (double)1080 / image.Width;
                    var ratioY18 = (double)640 / image.Height;
                    var ratio18 = Math.Max(ratioX18, ratioY18);
                    var width18 = (int)(image.Width * ratio18);
                    var height18 = (int)(image.Height * ratio18);
                    var newfileName18 = GenerateFileName("Photo_1080_", systemFileExtenstion);
                    var filepath18 = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, "px1080")) + $@"\{newfileName18}";
                    image.Mutate(x => x.Resize(width18, height18, true));
                    image.Save(filepath18);
                    retVal.ImageLarge = newfileName18;

                    //468px
                    var ratioX40 = (double)468 / image.Width;
                    var ratioY40 = (double)468 / image.Height;
                    var ratio40 = Math.Max(ratioX40, ratioY40);
                    var width40 = (int)(image.Width * ratio40);
                    var height40 = (int)(image.Height * ratio40);
                    image.Mutate(x => x.Resize(width40, height40));
                    var newfileName40 = GenerateFileName("Photo_468_", systemFileExtenstion);
                    var filepath40 = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, "px468")) + $@"\{newfileName40}";
                    image.Save(filepath40);
                    retVal.ImageMedium = newfileName40;

                    //200px
                    var ratioX20 = (double)64 / image.Width;
                    var ratioY20 = (double)64 / image.Height;
                    var ratio20 = Math.Max(ratioX20, ratioY20);
                    var width20 = (int)(image.Width * ratio20);
                    var height20 = (int)(image.Height * ratio20);
                    image.Mutate(x => x.Resize(width20, height20));
                    var newfileName20 = GenerateFileName("Photo_200_", systemFileExtenstion);
                    var filepath20 = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName,"px64")) + $@"\{newfileName20}";
                    image.Save(filepath20);
                    retVal.ImageMin = newfileName20;
                    
                }

                return retVal;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GenerateFileName(string fileTypeName, string fileextenstion)
        {
            if (fileTypeName == null) throw new ArgumentNullException(nameof(fileTypeName));
            if (fileextenstion == null) throw new ArgumentNullException(nameof(fileextenstion));
            return $"{fileTypeName}_{Guid.NewGuid():N}{fileextenstion}";
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
