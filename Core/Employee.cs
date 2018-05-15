namespace Core {

    public class Employee {

        public Employee() { }

        public Employee(string firstName, string lastName, int salary) {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }

        public int EmployeeId { get; set; }
        
        [NameValidation]
        public string FirstName { get; set; }
        
        [NameValidation]
        public string LastName { get; set; }
        
        public int Salary { get; set; }
    }
}
