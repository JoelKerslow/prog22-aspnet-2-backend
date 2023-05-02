using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Contexts
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<PromoCategoryEntity> PromoCategories { get; set; }
        public DbSet<PromoCodeEntity> PromoCodes { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<ProductOrderDetailEntity> ProductOrderDetails { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<CampaignProductEntity> CampaignProducts { get; set; }
        public DbSet<CampaignEntity> Campaigns { get; set; }
        public DbSet<OrderReviewEntity> OrderReviews { get; set; }
        public DbSet<CustomerProfileEntity> CustomerProfiles { get; set; }
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<ProductReviewEntity> ProductReviews { get; set; }
        public DbSet<FavouritesEntity> Favourites { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<ShowcaseEntity> Showcases { get; set; }

    }
}
