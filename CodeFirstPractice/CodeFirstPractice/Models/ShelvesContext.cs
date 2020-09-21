using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CodeFirstPractice.Models;

namespace CodeFirstPractice.Models
{
    public partial class ShelvesContext : DbContext
    {
        public ShelvesContext()
        {
        }
        public ShelvesContext(DbContextOptions<ShelvesContext> options) : base(options)
        {
        }
        public virtual DbSet<Shelves> Shelves { get; set; }
       public virtual DbSet<ShelfMaterials> ShelfMaterials { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // If we aren't already configured.
            if (!optionsBuilder.IsConfigured)
            {
                // Initialize the connection to a MySQL server.
                optionsBuilder
                    .UseMySql("server=localhost;port=3306;user=root;database=code_first_practice",
                        // Retreived from PHPMyAdmin under Home > Database Server > Server Version.
                        x => x.ServerVersion("10.4.14-MariaDB"));
                /*
                    Connection strings are used to define an entire connection profile in one string. They are composed of attributes and values separated by semicolons.
                    server=VALUE - Declares the server address for the connection.
                    port=VALUE - Declares the port for the conenction.
                    user=VALUE - Declares the database username for the connection.
                    password=VALUE - Declares that username's password for the connection (if applicable).
                    database=VALUE - Declares the database name to connect to.
                */
                // server=localhost;port=3306;user=root;database=code_first_cars
            }
        }
        // Called when we're doing database migrations, etc.
        // Called when we're doing database migrations, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Declare advanced column configuration for our model.
            modelBuilder.Entity<Shelves>(entity =>
            {
                 // If you have foreign keys, declare them here as "HasIndex".
                  entity.HasIndex(e => e.ShelfMaterialID)
                      // By using nameof() we don't have to worry about weird names when we rename the classes.
                      .HasName("FK_" + nameof(Shelves) + "_" + nameof(ShelfMaterials));
                  // Enforce the Foreign Key
                  // Specify the relationship between the child and parent
                  entity.HasOne(child => child.ShelfMaterials)
                  // Specify the relationship between the parent and child(ren)
                      .WithMany(parent => parent.Shelves)
                  // Specify the property acting as the foreign key
                      .HasForeignKey(child => child.ShelfMaterialID)
                  // Specify delete behaviour
                  // If the foreign key value is NOT NULL, you must use Cascade
                  // If you want to use restrict, push the seed data with Cascade, then change it to Restrict and push again (I'm not sure why it doesn't let you do that to start with)
                      .OnDelete(DeleteBehavior.Cascade)
                  // Name the foreign key
                      .HasConstraintName("FK_" + nameof(Shelves) + "_" + nameof(ShelfMaterials));

                // Declare the string encoding for our text fields.
                entity.Property(e => e.Name)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasData(
                     new Shelves()
                     {
                         ID = 1,
                         Name = "Movies Shelf",
                      ShelfMaterialID=1
                     },
                     new Shelves()
                     {
                         ID = 2,
                         Name = "Books Shelf",
                       ShelfMaterialID = 1
                     },
                     new Shelves()
                     {
                         ID = 3,
                         Name = "Cloths Shelf",
                       ShelfMaterialID = 1
                     },
                     new Shelves()
                     {
                         ID = 4,
                         Name = "Tools Shelf",
                      ShelfMaterialID = 1
                     },
                     new Shelves()
                     {
                         ID = 5,
                         Name = "Games Shelf",
                       ShelfMaterialID = 1
                     }
                     );
            });

                 modelBuilder.Entity<ShelfMaterials>(entity =>
                {
                    // PLEASE don't try to memorize this. Copy/paste it and change the column name.
                    entity.Property(e => e.MaterialName)
                            .HasCharSet("utf8mb4")
                            .HasCollation("utf8mb4_general_ci");

                 entity.HasData(
                       new ShelfMaterials()
                       {
                         ID=1,
                           MaterialName = "metal"
                       },
                       new ShelfMaterials()
                       {
                           ID = 2,
                           MaterialName = "wire"
                       },


                          new ShelfMaterials()
                          {
                              ID = 3,
                              MaterialName = "wood"
                          },
                           new ShelfMaterials()
                           {
                               ID = 4,
                               MaterialName = "plastic"
                           },
                            new ShelfMaterials()
                            {
                                ID = 5,
                                MaterialName = "concrete"
                            }
                            );

                });

                // Call the partial method in case we add some stuff to another file later.
                OnModelCreatingPartial(modelBuilder);
            
        }
        // Not technically needed, but the scaffolding generates it for later use, so we can add it if we want for future-proofing.
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
