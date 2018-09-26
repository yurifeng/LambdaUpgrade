using System;
using System.Collections.Generic;
namespace MyLambda
{
    public class ExtendTest
    {
        public static void Show()
        {
            //测试数据
            string sNum = "250";
            sNum.ToInt();//变换为int
            sNum.ToLower();
            sNum.ToStringCustomer();

            Console.WriteLine(sNum);
        }
    }


    #region 扩展方法

    public static class Extend
    {
        //扩展静态方法
        //使用方法:静态类中,静态方法,参数前面添加this
        public static int ToInt(this string sNum)
        {
            //将传入的sNum转换为等价的32为数字iNum
            if (int.TryParse(sNum, out var iNum))
            {
                //成功则返回iNum
                return iNum;
            }
            //不成功,则抛异常
            throw new Exception("发生错误,无法转换为32位数字....");

        }

        public static string ToStringCustomer(this object oObject)
        {
            return oObject.ToString();
        }


        //自创建SomethingWhere方法
        //目的是创建一个过滤条件的方法
        public static IEnumerable<TSource> SomethingWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            List<TSource> list = new List<TSource>();
            foreach (TSource t in source)
            {
                if (predicate.Invoke(t))
                {
                    list.Add(t);
                }
            }
            return list;
        }

    }

    #endregion
}
