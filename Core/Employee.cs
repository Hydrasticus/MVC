using System.ComponentModel.DataAnnotations;

namespace Core {

    public class Employee {

        private const string requiredField = "Required field!";
        private const string lengthIsTooBig = "Length should be less than 20 characters!";

        public Employee() { }

        public Employee(string firstName, string lastName, int salary) {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        public int EmployeeId { get; set; }
        
        [Required(ErrorMessage = requiredField)]
        [StringLength(20, ErrorMessage = lengthIsTooBig)]
        public string FirstName { get; set; }
        
        [StringLength(20, ErrorMessage = lengthIsTooBig)]
        public string LastName { get; set; }
        
        public int Salary { get; set; }
    }
}
