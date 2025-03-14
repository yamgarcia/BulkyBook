﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        //Data Annotation to inform Id column is the primary key
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,1000,ErrorMessage = "Display Order must be between 1 and 1000 only")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}

//Add migration folder and files -> add-migration AddCategoryToDadabase
//Push migrations to the database -> update database