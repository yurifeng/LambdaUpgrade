using System;

namespace MyLambda
{
    //1 声明委托
    public delegate int WithReturnNoParaOutClass();

    public class Lambda
    {
        //声明委托
        public delegate void NoReturnNoPara();//没返回没参数
        public delegate void NoReturnWithPara(int x, int y);//没返回有参数
        public delegate int WithReturnNoPara();//又返回没参数
        public delegate string WithReturnWithPara(int x, int y);//有参数有返回

        //方法
        public void Show()
        {
            //2 实例化委托
            NoReturnWithPara method = ShowPlus;

            //3 调用委托
            method.Invoke(5, 6);
            ShowPlus(5, 6);

            #region 匿名类

            //匿名类
            var model = new
            {
                Id = 3,
                Name = "abcd",
                Size = 5
            };
            Console.WriteLine("id={0} Name={1} Size={2}", model.Id, model.Name, model.Size);

            Student student = new Student()
            {
                Id = 11,
                Name = "wxyz",
                Age = 22,
                ClassId = 1
            };
            #endregion 匿名类


            #region 匿名方法

            // 匿名方法
            NoReturnWithPara method1 = new NoReturnWithPara(delegate (int x, int y)
            {
                Console.WriteLine("ShowPlus x={0} y={1} x+y={2}", x, y, x + y);
            });
            method1.Invoke(6, 7);

            // ==> goes to   这就是lambda表达式   参数列表  goes to  方法体
            //去掉了delegate关键字
            NoReturnWithPara method2 = new NoReturnWithPara(
                (int x, int y) =>
                {
                    Console.WriteLine("ShowPlus x={0} y={1} x+y={2}", x, y, x + y);
                });
            method2.Invoke(6, 7);

            //因为委托会严格要求方法签名一致
            //去掉了参数类型,直接写参数
            NoReturnWithPara method3 = new NoReturnWithPara(
                (x, y) =>
                {
                    Console.WriteLine("ShowPlus x={0} y={1} x+y={2}", x, y, x + y);
                });
            method3.Invoke(6, 7);

            //Lambda表达式的简化写法,
            //委托实例化的时候，可以去掉new
            NoReturnWithPara method4 = (x, y) =>
            {
                Console.WriteLine("ShowPlus x={0} y={1} x+y={2}", x, y, x + y);
            };
            method4.Invoke(6, 7);

            //lambda只有一行，大括号和分号去掉
            NoReturnWithPara method5 = (x, y) => Console.WriteLine("ShowPlus x={0} y={1} x+y={2}", x, y, x + y);
            method5.Invoke(6, 7);

            #endregion


            #region Action委托

            //最基础的委托写法
            Action act = new Action(DoNothing);

            //已简化 (没有参数,没有返回值)
            Action action = () => Console.WriteLine("fucking yourself");

            //已简化 (有参数,没有返回值)
            Action<int, int> act22 = (x, y) => Console.WriteLine("ShowPlus x={0} y={1} x+y={2}", x, y, x + y);

            //已简化,只有一个参数的时候，可以不要小括号
            Action<string> act3 = t => Console.WriteLine(t);

            //Action 支持0到16个参数
            Action<string, float, int, string, float, int, string, float, int, string, float, int, string, float, int, Action> act4 = null;
            #endregion



            #region Func委托

            //初始写法(带返回值string类型)
            Func<string> func = new Func<string>(Get);

            //如果lambda表达式方法体只有一行的话，可以把大括号和分号去掉,return也去掉
            //返回一个string类型
            Func<string> func11 = () => "Firefox";
            Console.WriteLine(" Hello,{0}", func11());

            //参数是int类型,返回值是DateTime类型
            Func<int, DateTime> func2 = i => DateTime.Now;

            //Func 支持0到16个传入参数  带返回值
            Func<string, float, int, string, float, int, string, float, int, string, float, int, string, float, int, Action, Func<string>> func3 = null;

            #endregion

            #region Predicate委托

            Predicate<int> pre = t => true;
            pre(3);
            pre.Invoke(3);

            #endregion



        }

        #region 几个供Delegate调用的方法

        private string Get()
        {
            return "fireBug..";
        }

        private void DoNothing()
        {
            Console.WriteLine("DoNothing...");
        }

        private void ShowPlus(int x, int y)
        {
            Console.WriteLine("ShowPlus x={0} y={1} x+y={2}", x, y, x + y);
        }

        #endregion
    }
}
