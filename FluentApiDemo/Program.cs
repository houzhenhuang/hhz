using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //Class cls = new Class();
            //cls.Name = "九年一班";

            //Student stu = new Student();
            //stu.Name = "lily";
            //stu.Age = 21;
            //stu.Class = cls;

            //using (FluentApiDBContext dbContext = new FluentApiDBContext())
            //{
            //    dbContext.Classes.Add(cls);
            //    dbContext.Students.Add(stu);
            //    dbContext.SaveChanges();
            //}

            Teacher t1 = new Teacher();
            t1.Name = "t1";
            t1.Age = 21;

            Teacher t2 = new Teacher();
            t2.Name = "t2";
            t2.Age = 23;

            Teacher t3 = new Teacher();
            t3.Name = "t3";
            t3.Age = 14;

            Student s1 = new Student();
            s1.Name = "tom";
            s1.Age = 33;
            s1.Teachers.Add(t1);
            s1.Teachers.Add(t2);

            Student s2 = new Student();
            s2.Name = "lucy";
            s2.Age = 12;
            //s2.Class = c;
            s2.Teachers.Add(t1);
            s1.Teachers.Add(t3);

            t1.Students.Add(s1);
            t1.Students.Add(s2);

            using (FluentApiDBContext dbContext = new FluentApiDBContext())
            {
                //dbContext.Classes.Add(c);

                dbContext.Students.Add(s1);
                dbContext.Students.Add(s2);
                dbContext.Teacheres.Add(t1);
                dbContext.Teacheres.Add(t2);
                dbContext.Teacheres.Add(t3);
                dbContext.SaveChanges();
            }

            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine(ex.Message);
            //}

            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
