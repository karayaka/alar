using alar.DAL.Classes.AlarClasses;
using alar.DAL.Classes.BranchClasses;
using alar.DAL.Classes.CustomerClasses;
using alar.DAL.Classes.DiscountClasses;
using alar.DAL.Classes.ProductClasses;
using alar.DAL.Classes.UserClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace alar.DAL.AlarDataContext
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        
        //Alar classes
        public DbSet<Brant> Brants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ComplaintTypes> ComplaintTypes { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<ProductName> ProductNames { get; set; }
        public DbSet<UnitDefination> UnitDefinations { get; set; }

        //Branch Classes
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchAuthorized> BranchAuthorizeds { get; set; }

        //CustomerClaases
        public DbSet<Customer> Customers { get; set; }

        //DiscountClasses
        public DbSet<DicountComment> DicountComments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountBranch> DiscountBranches { get; set; }
        public DbSet<DiscountComplaint> DiscountComplaints { get; set; }
        public DbSet<DiscountLikeDislike> LikeDislikes { get; set; }
        public DbSet<DiscountView> DiscountViews { get; set; }
        public DbSet<DiscountWepView> DiscountWepViews { get; set; }

        //Product classes
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        //UserClasses
        public DbSet<CustomerFallow> CustomerFallows { get; set; }
        public DbSet<UserBasket> UserBaskets { get; set; }
        public DbSet<UserClass> Users { get; set; }
    }
}
