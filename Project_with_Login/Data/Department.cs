using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace Project_with_Login.Data
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }   
    }
}
