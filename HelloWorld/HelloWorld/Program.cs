using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.ReadKey();

            //第一步循环ps 类似于java，比较鸡肋的items
            int[] x = new int[12];
            foreach(int y in x)
            {
                Console.WriteLine(y);
            }
            Console.ReadKey();
            Console.WriteLine("-----------------------------------------------");
            {
                MyClass first = new MyClass();
                first.show();
                MyClass.showCount();
                {
                    MyClass second = new MyClass(12, "ZhangBao");
                    second.show();
                    MyClass.showCount();

                    {
                        MyClass third = new MyClass(12, "ZhangBao");
                        third.show();
                        MyClass.showCount();

                    }
                    MyClass.showCount();
                }
                MyClass.showCount();
            }
            MyClass.showCount();
            Console.ReadKey();
            Console.WriteLine("-------------------文件读写与一场处理----------------------------");
            try
            {
                FileStream file = new FileStream("a.txt",FileMode.OpenOrCreate);
                file.Flush();
                file.Close();


            }catch(Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                Console.ReadKey();
            }
            Console.WriteLine("-------------------文件读写与一场处理2.0----------------------------");
            try
            {
                //using(Stream)
            }

        }
    }
    //第二步类：
    class MyClass
    {
        protected int m_x;
        private string m_name;
        public static int count=0;
        public MyClass(int x=10,string name="No name")
        {
            m_name = name;
            m_x = x;
            Console.WriteLine("你好啊，第{0}个对象被创建出来",count+1);
            count++;
        }
        public void  show()
        {
            Console.WriteLine("此时m_x的值是{0},这个对象的名称是{1}", m_x,m_name);
        }
        public static void showCount()
        {
            Console.WriteLine("此时共有个{0}MyClass对象", count);
        }
        ~MyClass()
        {
            Console.WriteLine("现在是对象被销毁，老大那好呀,我被销毁后只有{0}个对象了",count);
            count = count - 1;
        }
    }
}
