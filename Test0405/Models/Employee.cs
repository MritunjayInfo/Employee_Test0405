using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Test0405.Models
{
    public class Employee
    {
        //        name
        //mobile
        //dob
        //age
        //password
        //fileupload
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public long Mobile { get;set; }

        public DateTime Dob { get; set; }
        public int Age { get; set; } 

        public string Password { get; set; }

        public string? DocumnetUploadBase64 { get;set; }

        public byte[]? DocumentByteUpload { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile? DocumentFile { get; set; }

    }
}
