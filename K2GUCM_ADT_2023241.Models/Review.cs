using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Models
{
    [Table("Reviews")] //DBtable for storing class instances
    public class Review
    {
        //properties
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Review_ID { get; set; }

        [Required]
        public int Review_Movie_ID { get; set; }


        [MaxLength(2000)]
        [ToString]
        public string Review_Content { get; set; }


        public override string ToString()
        {
            return $"{Review_ID} - {Review_Content}\n"; //returns formatted string
        }

        //public override bool Equals(object obj)
        //{
        //    return (obj as Review).Review_Movie_ID == this.Review_Movie_ID &&
        //        (obj as Review).Review_ID == this.Review_ID &&
        //        (obj as Review).Review_Content == this.Review_Content;
        //}
    }
}
