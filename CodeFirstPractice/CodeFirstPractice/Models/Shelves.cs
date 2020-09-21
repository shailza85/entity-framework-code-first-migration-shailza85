using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstPractice.Models
{
    // Declares the name of the database table.
    [Table("Shelves")]
    public partial class Shelves
    {
        // All annotations will bind to the next property in the file.
        // Declare a primary key.
        [Key]
        // Specifies AUTO_INCREMENT.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Declare the column name and the data type.
        // MySQL data type, NOT C# data type.
        [Column("id", TypeName = "int(10)")]
        // Declare the C# property that will map onto that database column.
        public int ID { get; set; }
       
        [Column("name", TypeName = "varchar(50)")]
        [Required]
       public string Name { get; set; }
        
         [Column("shelfMaterial_id", TypeName = "int(10)")]
        public int ShelfMaterialID { get; set; }

         //A foreign key to ShelfMaterial(ID) called "ShelfMaterialID".
        // Points to the property representing the foreign key column.
      [ForeignKey(nameof(ShelfMaterialID))]
        // By using nameof() it saves us from breaking it accidentally by renaming things, as long as we use Ctrl+R+R to rename them. For some reason the migration from an existing database doesn't use this, which is why things breaks
       [InverseProperty(nameof(Models.ShelfMaterials.Shelves))]
      public virtual ShelfMaterials ShelfMaterials { get; set; }
  

    }
}
