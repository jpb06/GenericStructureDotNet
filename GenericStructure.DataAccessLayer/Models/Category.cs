﻿using GenericStructure.DataAccessLayer.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.DataAccessLayer.Models
{
    public class Category : BaseModel
    {
        /* ----------------------------------------------------------*/

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        /* ----------------------------------------------------------*/
        public virtual ICollection<Article> Articles { get; set; }
        /* ----------------------------------------------------------*/

        public Category() : base()
        {
            this.Articles = new HashSet<Article>();
        }
    }
}
