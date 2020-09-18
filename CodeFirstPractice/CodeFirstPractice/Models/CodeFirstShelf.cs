using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstPractice.Models
{
    // Declares the name of the database table.
    [Table("Shelves")]
    public partial class CodeFirstShelf
    {
        // All annotations will bind to the next property in the file.

        // Declare a primary key.
        [Key]
        // Specifies AUTO_INCREMENT.
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Declare the column name and the data type.
        // MySQL data type, NOT C# data type.
        [Column("id", TypeName = "int(10)")]
        // Declare the C# property that will map onto that database column.
        public int ID { get; set; }

        [Column("name", TypeName = "varchar(50)")]
        // Specifies NOT NULL on nullable types.
        // Ints do not require this to be NOT NULL as they are not nullable.
        // You must make a nullable int (int?) in order to specify NULL.
        [Required]
        public string Name { get; set; }
           
    }
}
