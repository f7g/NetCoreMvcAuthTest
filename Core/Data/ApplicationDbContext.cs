using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Core.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<DataModel> DataModel => Set<DataModel>();
    public DbSet<FolderModel> FolderModel => Set<FolderModel>();
    public DbSet<ItemModel> ItemModel => Set<ItemModel>();
    public DbSet<OrganizationModel> OrganizationModel => Set<OrganizationModel>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
}
