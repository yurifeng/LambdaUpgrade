using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLambda
{
    public class LinqTest
    {
        #region 模拟数据库,初始化数据

        // GetStudentList方法
        // 返回List<Student>
        private static List<Student> GetStudentList()
        {
            //填充list数据
            List<Student> studentList = new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    Name="yty",
                    Age=25,
                    ClassId=2
                },
                new Student()
                {
                    Id=2,
                    Name="jsd1800",
                    Age=36,
                    ClassId=2
                },
                new Student()
                {
                    Id=3,
                    Name="jst",
                    Age=24,
                    ClassId=2
                },
                new Student()
                {
                    Id=4,
                    Name="jsf",
                    Age=25,
                    ClassId=2
                },
                new Student()
                {
                    Id=1,
                    Name="htt",
                    Age=31,
                    ClassId=2
                },
                new Student()
                {
                    Id=1,
                    Name="cxt",
                    Age=18,
                    ClassId=2
                },
                new Student()
                {
                    Id=1,
                    Name="tdjb",
                    Age=33,
                    ClassId=2
                },
                new Student()
                {
                    Id=1,
                    Name="vawen",
                    Age=28,
                    ClassId=2
                },
                  new Student()
                {
                    Id=1,
                    Name="jr",
                    Age=27,
                    ClassId=2
                },
                  new Student()
                {
                    Id=1,
                    Name="jmt",
                    Age=34,
                    ClassId=2
                },
                   new Student()
                {
                    Id=1,
                    Name="jtt",
                    Age=21,
                    ClassId=1
                },
                   new Student()
                {
                    Id=1,
                    Name="jyt",
                    Age=23,
                    ClassId=1
                },
                   new Student()
                {
                    Id=1,
                    Name="hst",
                    Age=29,
                    ClassId=1
                }
            };

            return studentList;
        }
        #endregion 

        public static void Show()
        {
            //拿到上一个方法填充的list数据
            List<Student> studentList = GetStudentList();

            #region 简单方法使用有条件的查询(效率高)

            {
                //声明一个新的list存新查询出来的student
                List<Student> studentListLess25 = new List<Student>();
                foreach (Student student in studentList)
                {
                    if (student.Age < 25)
                    {
                        //年纪小于25
                        studentListLess25.Add(student);
                    }
                }
                Console.WriteLine("**************************");
                foreach (Student student in studentListLess25)
                {
                    Console.WriteLine($"Name={student.Name} Age={student.Age}");
                }
            }

            #endregion


            {
                #region 使用Enumerable

                var studentListLess = Enumerable.Where<Student>(studentList, s => s.Age < 25);
                Console.WriteLine("**************************");
                foreach (Student student in studentListLess)
                {
                    Console.WriteLine($"Name={student.Name} Age={student.Age}");
                }

                #endregion

                #region 使用where关键字

                var studentListLess25 = studentList.Where<Student>(s => s.Age < 25);//陈述式
                Console.WriteLine("*********less than 25 year-old*****************");
                foreach (Student student in studentListLess25)
                {
                    Console.WriteLine($"Name={student.Name} Age={student.Age}");
                }

                #endregion

                #region 原生Linq语法

                var list = from student in studentList
                           where student.Age < 25
                           select student;//语法糖

                Console.WriteLine("**************************");
                foreach (Student student in list)
                {
                    Console.WriteLine($"Name={student.Name} Age={student.Age}");
                }

                #endregion

                #region 调用自创的SomethingWhere方法

                var studentListLessMethod = studentList.SomethingWhere<Student>(s => s.Age < 25);//陈述式
                Console.WriteLine("**************************");
                foreach (Student student in studentListLessMethod)
                {
                    Console.WriteLine($"Name={student.Name} Age={student.Age}");
                }

                #endregion
            }

            #region 使用Where和Select
            {
                var list = studentList.Where<Student>(s => s.Age > 25)
                    .Select(s => new
                    {
                        IdAge = $"{s.Id}_{s.Age}",
                        Name = s.Name
                    });//匿名对象,里面可以随便属性(该对象里面有IdAge和Name)

                Console.WriteLine("**************************");

                foreach (var anonymousObject in list)
                {
                    Console.WriteLine($"Name={anonymousObject.Name} Age={anonymousObject.IdAge}");
                }
            }
            #endregion


            #region 使用原生Linq和匿名对象混合

            {
                var list = from student in studentList
                    where student.Age > 25
                    select new
                    {
                        IdAge = $"{student.Id}_{student.Age}",
                        Name = student.Name
                    };//语法糖(将匿名的对象插入)

                Console.WriteLine("**************************");
                foreach (var anonymousObject in list)
                {
                    Console.WriteLine($"Name={anonymousObject.Name} Age={anonymousObject.IdAge}");
                }
            }

            #endregion

            {
                Console.WriteLine("**************************");
                foreach (var student in studentList.Where<Student>(s => s.ClassId == 2 && s.Id < 4)
                                                   .Select<Student, Student>(s => new Student
                                                   {
                                                       Age = s.Age,
                                                       Name = $"{s.Name}_{s.Id}"
                                                   })
                                                   .OrderBy<Student, int>(s => s.Id)
                                                   .ThenByDescending<Student, int>(s => s.Age)
                                                   .Skip<Student>(1)
                                                   .Take<Student>(5))
                {
                    Console.WriteLine($"Name={student.Name} Age={student.Age}");
                }
            }

        }
    }
}
