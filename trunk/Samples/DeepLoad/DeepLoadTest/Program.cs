using System;

namespace DeepLoadBench
{
    class Program
    {
        static void Main(string[] args)
        {
            ParentLoadTest();
            SelfLoadTest();
            ParentLoadActiveTest();
            SelfLoadActiveTest();
        }

        private static void ParentLoadTest()
        {
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("ParentLoad EDITABLE");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ReadLine();
            var test1 = new ParentLoadTestA();
            test1.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            var test2 = new ParentLoadTestB();
            test2.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("ParentLoad READ ONLY");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ReadLine();
            var test3 = new ParentLoadROTestA();
            test3.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            var test4 = new ParentLoadROTestB();
            test4.FetchTest();
        }

        private static void SelfLoadTest()
        {
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("SelfLoad EDITABLE");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ReadLine();
            var test5 = new SelfLoadTestC();
            test5.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            var test6 = new SelfLoadTestD();
            test6.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("SelfLoad READ ONLY");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ReadLine();
            var test7 = new SelfLoadROTestC();
            test7.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            var test8 = new SelfLoadROTestD();
            test8.FetchTest();
        }

        private static void ParentLoadActiveTest()
        {
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("ParentLoad EDITABLE - Active");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ReadLine();
            var test6 = new ParentLoadTestE();
            test6.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            var test7 = new ParentLoadTestF();
            test7.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("ParentLoad READ ONLY - Active");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ReadLine();
            var test8 = new ParentLoadROTestE();
            test8.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            var test9 = new ParentLoadROTestF();
            test9.FetchTest();
        }

        private static void SelfLoadActiveTest()
        {
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("SelfLoad EDITABLE - Active");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ReadLine();
            var test10 = new SelfLoadTestG();
            test10.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            var test11 = new SelfLoadTestH();
            test11.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("SelfLoad READ ONLY - Active");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.ReadLine();
            var test12 = new SelfLoadROTestG();
            test12.FetchTest();
            Console.ReadLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            var test13 = new SelfLoadROTestH();
            test13.FetchTest();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
        }
    }
}
