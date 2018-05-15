using Core;

namespace Facade {

    //TODO: setName, setColor and setSalary to internal void
    public class EmployeeViewModel {
        
        public EmployeeViewModel(Employee emp) {
            if (emp is null) return;
            setName(emp);
            setSalary(emp);
            setColor(emp);
        }
        
        public string EmployeeName { get; set; }
        public string Salary { get; set; } = 0.ToString("C");
        public string SalaryColor { get; private set; } = "red";

        public void setName(Employee e) {
            EmployeeName = e.FirstName + " " + e.LastName;
        }

        public void setColor(Employee e) {
            if (!ReferenceEquals(null, e)) SalaryColor = e.Salary > 15000 ? "yellow" : "green";
            else SalaryColor = "red";
        }

        public void setSalary(Employee e) {
            Salary = e.Salary.ToString("C");
        }
    }
}
