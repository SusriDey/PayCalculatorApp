using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_programming
{
    /// <summary>
    /// This is an Employee Class
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rate { get; set; }

        /// <summary>
        /// Employee constructor
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="rate">Employee Rate per hour</param>
        public Employee(int id, string firstName, string lastName, double rate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Rate = rate;
        }

        /// <summary>
        /// Override ToString method
        /// </summary>
        /// <returns>Returns a string representation of the Employee object</returns>
        public override string ToString()
        {
            return "ID: " + this.Id + " Name: " + this.FirstName + " " + this.LastName + " Hourly Rate: " + this.Rate + " per hr";
        }

    }
}
