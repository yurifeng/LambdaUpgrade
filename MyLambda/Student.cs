namespace MyLambda
{
    public class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    //教室类
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
