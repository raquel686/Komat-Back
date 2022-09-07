using Inventex.API.Management.Domain.Models;
using Inventex.API.Security.Domain.Models;
using Inventex.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Inventex.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    
    public DbSet<Inventory> Inventories { get; set; }

    
    
    public AppDbContext(DbContextOptions options) : base(options){
    }
    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        //USERS
        //Constraints
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p=>p.Id);
        builder.Entity<User>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p=>p.FirstName).IsRequired();
        builder.Entity<User>().Property(p=>p.LastName).IsRequired();
        builder.Entity<User>().Property(p=>p.Email).IsRequired().HasMaxLength(30);

        //Relationships

       
        builder.Entity<User>()
            .HasMany(p=>p.Inventories)
            .WithOne(p=>p.User)
            .HasForeignKey(p=>p.UserId);
        
     
  
       


        //INVENTORIES

        builder.Entity<Inventory>().ToTable("Inventories");
        builder.Entity<Inventory>().HasKey(p => p.Id);
        builder.Entity<Inventory>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Inventory>().Property(p => p.Name).IsRequired().HasMaxLength(20);
        //Descripción (Nombre del Item a almacenar): Cadena de texto de longitud 20 caracteres->Name
        
        builder.Entity<Inventory>().Property(p => p.Image).HasMaxLength(7);
        //Ubicacion (Donde se almacenará el item: cadena de texto de longitud 7  ->Image

        builder.Entity<Inventory>().Property(p => p.Price).HasMaxLength(9);
        //OS  (Orden de Servicio): número de 9 digitos (Generado desde SAP)->Price

        builder.Entity<Inventory>().Property(p => p.Category);
        //Clasificación del Item: Evaluado, Repuesto, Base, Compra Local.->Category
        
    
       
        
      
        

        //Apply Snake Case Naming Convention
        
      

        builder.UseSnakeCaseNamingConvention();
    }
    
    
}