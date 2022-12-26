using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI {
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

    }
}