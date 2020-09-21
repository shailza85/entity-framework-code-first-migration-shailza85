using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstPractice.Models
{
    // Declares the name of the database table.
    [Table("ShelfMaterial")]
    public partial class ShelfMaterials
    {
        /**
         * A table called ShelfMaterial with:
            An int primary key called "ID".
            A varchar of length 25 called "MaterialName".
            The requisite virtual properties for references.
         */
       public ShelfMaterials()
       {
            Shelves = new HashSet<Shelves>();
       }
        // Declare a primary key.
      [Key]
        // Specifies AUTO_INCREMENT.
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Declare the column name and the data type.
        // MySQL data type, NOT C# data type.
   [Column("id", TypeName = "int(10)")]
        // Declarethe C# property that will map onto that database column.
    public int ID { get; set; }
        
   [Column("materialname", TypeName = "varchar(25)")]
        [Required]
     public string MaterialName { get; set; }

       // This property represents a list of all the related entities which have this entity's primary key as their foreign key. It saves using LINQ to try and filter on the primary key and makes things more readable.
      [InverseProperty(nameof(Models.Shelves.ShelfMaterials))]
       public virtual ICollection<Shelves> Shelves { get; set; }
    }
}
