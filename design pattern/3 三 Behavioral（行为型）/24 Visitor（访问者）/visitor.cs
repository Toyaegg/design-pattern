using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern
{
    //抽象元素类
    interface Employee
    {
        void Accept(Department handler);
    }
    //抽象访问者类
    abstract class Department
    {
        public abstract void Visit(FulltimeEmployee employee);
        public abstract void Visit(ParttimeEmployee employee);
    }
    //具体元素类
    class FulltimeEmployee : Employee
    {
        private string name;
        private double weeklyWage;
        private int workTime;

        public FulltimeEmployee(string name, double weeklyWage, int workTime)
        {
            this.name = name;
            this.weeklyWage = weeklyWage;
            this.workTime = workTime;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double WeeklyWage
        {
            get
            {
                return weeklyWage;
            }
            set
            {
                weeklyWage = value;
            }
        }

        public int WorkTime
        {
            get
            {
                return workTime;
            }
            set
            {
                workTime = value;
            }
        }

        public void Accept(Department handler)
        {
            handler.Visit(this);
        }
    }
    //具体元素类
    class ParttimeEmployee : Employee
    {
        private string name;
        private double hourWage;
        private int workTime;

        public ParttimeEmployee(string name, double hourWage, int workTime)
        {
            this.name = name;
            this.hourWage = hourWage;
            this.workTime = workTime;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double HourWage
        {
            get
            {
                return hourWage;
            }
            set
            {
                hourWage = value;
            }
        }

        public int WorkTime
        {
            get
            {
                return workTime;
            }
            set
            {
                workTime = value;
            }
        }
        public void Accept(Department handler)
        {
            handler.Visit(this);
        }
    }
    //具体访问者类
    class FADepartment : Department
    {
        public override void Visit(FulltimeEmployee employee)
        {
            int workTime = employee.WorkTime;
            double weekWage = employee.WeeklyWage;
            if (workTime > 40)
            {
                weekWage = weekWage + (workTime - 40) * 100;
            }
            else if(workTime < 40)
            {
                weekWage = weekWage - (40 - workTime) * 80;
                if (weekWage < 0)
                {
                    weekWage = 0;
                }
            }
            Console.WriteLine("正式员工{0}的实际工资为：{1}元。", employee.Name, weekWage);
        }

        public override void Visit(ParttimeEmployee employee)
        {
            int workTime = employee.WorkTime;
            double hourWage = employee.HourWage;
            Console.WriteLine("临时工{0}的实际工资为：{1}元。", employee.Name, workTime * hourWage);
        }
    }
    //具体访问者类
    class HRDepartment : Department
    {
        public override void Visit(FulltimeEmployee employee)
        {
            int workTime = employee.WorkTime;
            Console.WriteLine("正式员工{0}的实际工作时间为：{1}小时。", employee.Name, workTime);
            if (workTime > 40)
            {
                Console.WriteLine("正式员工{0}的加班时间为：{1}小时。", employee.Name, workTime - 40);
            }
            else if(workTime < 40)
            {
                Console.WriteLine("正式员工{0}的请假时间为：{1}小时。", employee.Name, 40 - workTime);
            }
        }

        public override void Visit(ParttimeEmployee employee)
        {
            int workTime = employee.WorkTime;
            Console.WriteLine("临时工{0}的实际工作时间为：{1}小时。", employee.Name, workTime);
        }
    }
    //对象结构
    class EmployeeList
    {
        private ArrayList list = new ArrayList();

        public void AddEmployee(Employee employee)
        {
            list.Add(employee);
        }

        public void Accept(Department handler)
        {
            foreach (object obj in list)
            {
                ((Employee)obj).Accept(handler);
            }
        }
    }
}
