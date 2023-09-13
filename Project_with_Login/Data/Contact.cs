using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace Project_with_Login.Data
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Telefon_Nummer { get; set; }

    }
}
