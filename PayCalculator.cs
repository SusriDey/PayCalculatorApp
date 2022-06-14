using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace OO_programming
{
    internal class Range
    {
        public double Start { get; set; }
        public double End { get; set; }
        public double Tax { get; set; }
        

        public Range(double start, double end, double tax)
        {
            Start = start;
            End = end;
            Tax = tax;
        }

        override public string ToString()
        {
            return this.Start + " " + this.End + " " + this.Tax;
        }

    }
    public class PayCalculator
    {
        //Super percentage
        double Super = 0.1; // 10% super
        internal List<Employee> employees { get;  } = new List<Employee>();
        internal List<Range> RangeList = new List<Range> ();

        public PayCalculator()
        {
            
        }

        public string LoadTaxDetails()
        {
            //Load the tax slabs
            //Store the file location in a variable.
            string filePath = Directory.GetCurrentDirectory() + "\\Files\\taxrate-withthreshold.csv";

            //Check if the file exists 
            if (File.Exists(filePath))
            {
                //read the file
                StreamReader sr = new StreamReader(File.OpenRead(filePath));
                Range range;

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(',');

                    range = new Range(Double.Parse(values[0]), Double.Parse(values[1]), Double.Parse(values[2]));

                    RangeList.Add(range);
                    Console.WriteLine(range);

                }

                return "success";
            }
            else
            {
                Console.WriteLine("File can not be found");
                return "File can not be found";

            }
        }

        public string LoadEmployeeDetails()
        {
            //Store the file location in a variable.
            string filePath = Directory.GetCurrentDirectory() + "\\Files\\employee.csv";

            //MessageBox.Show(Directory.GetCurrentDirectory());

            //Check if the file exists 
            if (File.Exists(filePath))
            {
                //read the file
                StreamReader sr = new StreamReader(File.OpenRead(filePath));
                Employee emp;

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(',');

                    emp = new Employee(Int32.Parse(values[0]), values[1], values[2], Double.Parse(values[3]));
                    employees.Add(emp);
                    //this.listBox1.Items.Add(emp);

                }

                return "success";

            }
            else
            {
                Console.WriteLine("File can not be found");
                return "File can not be found";

            }
        }

        /// <summary>
        /// Get Employee at a particular index
        /// </summary>
        /// <param name="index">index of the employee from the employee list</param>
        /// <returns></returns>
        public Employee GetEmployee(int index)
        {
            return employees.ElementAt(index);
        }

        
        public PaySlip CalculatePayment(int selectedIndex,double hours)
        {

            Employee employee = GetEmployee(selectedIndex);
            PaySlip p = new PaySlip(employee, hours);

            double net = p.netPay;
            p.super = Math.Round(p.netPay * this.Super,2);
            p.gross = Math.Round(p.netPay - p.super,2); //Deduct super from net pay
            double tax = 0;
            p.threshold = RangeList.First().End;

            foreach (Range range in RangeList)
            {
                if (range.End <= p.gross)
                {
                    tax = tax + (range.End - range.Start) * range.Tax;
                }
                else if (range.Start <= p.gross)
                {
                    tax = tax + (p.gross - range.Start) * range.Tax;
                    break;
                }
                else break;
            }
            p.tax = Math.Round(tax,2);
            p.gross = Math.Round(p.gross - p.tax,2);

            return p;

        }



        public override string ToString()
        {
            return RangeList.ToString();
        }

    }
}
