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
    //attribute for generated movie objs
    public class ToStringAttribute : Attribute
    {

    }

    [Table("Movies")] //DB table
    public class Movie
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int Movie_ID { get; set; }


        [Required]
        [MaxLength(100)]
        [ToString]
        public string Movie_Title { get; set; }


        [ToString]
        public int Movie_ReleaseYear { get; set; }

        [ToString]
        public string Movie_Director { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Cast> Casts { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Review> Reviews { get; set; }

        public override string ToString()
        {
            string x = "";

            foreach (var item in this.GetType().GetProperties().Where(x => x.GetCustomAttribute<ToStringAttribute>() != null))
            {
                x += "   ";
                x += item.Name + "\t=> ";
                x += item.GetValue(this);
                x += "\n";
            }

            return x;
        }

    }
}
