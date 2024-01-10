using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Models
{
    [Table("Casts")] //database table for storing class instances
    public class Cast
    {
        [Key]//primary key
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cast_ID { get; set; }

        public int Cast_Movie_ID { get; set; }

        [Required]
        public string Cast_Name { get; set; }

        public string Cast_Nick { get; set; }

        public override string ToString()
        {
            return $"{Cast_ID} - {Cast_Name} - {Cast_Nick}\n";
        }

        //public override bool Equals(object obj)
        //{
        //    return (obj as Cast).Cast_ID == this.Cast_ID &&
        //        (obj as Cast).Cast_Movie_ID == this.Cast_Movie_ID &&
        //        (obj as Cast).Cast_Nick == this.Cast_Nick &&
        //        (obj as Cast).Cast_Name == this.Cast_Name;
        //}
    }
}
