using System.Collections;

namespace GenericDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            object obj = x; // Boxing => implcit conversion
            int y = (int)obj; // Unboxing => expplicit conversion

            ArrayList al = new ArrayList();
            al.Add(obj);
            al.Add("Hello");
            al.Add('a');
            al.Add(20.5);
            foreach (object item in al)
            {
                Console.WriteLine(item);
            }

            Student student = new Student();
            //student.Id = 101;
            //student.Name = "John Doe";
            student[0]= 101;
            student[1]= "John Doe";
            Console.WriteLine($"{student["id"]}, {student["name"]}");
            /*
            Add<int>(12, 13);
            //Add<string>(string.Empty, string.Empty);
            //Add<int,long>(12, 13);
            Add<string,string>("Hello", "World");
            */
            MyCollection<int> intCollection = new MyCollection<int>();
            intCollection.Add(10);
            intCollection.Add(20);
            intCollection.Add(30);
            Console.WriteLine(intCollection.Count +" "+intCollection.Capacity);
            intCollection.Add(40);
            intCollection.Add(50);
            Console.WriteLine(intCollection.Count + " " + intCollection.Capacity);
            intCollection.Add(60);
            intCollection.Add(70);
            intCollection.Add(80);
            intCollection.Add(90);
            Console.WriteLine(intCollection.Count + " " + intCollection.Capacity);

            for (int i = 0; i < intCollection.Count; i++)
            {
                Console.WriteLine(intCollection[i]);
            }

            foreach (int item in intCollection)
            {
                Console.WriteLine(item);
            }
        }
        //T => Type parameter
        static void Add<TValue>(TValue x, TValue y) where TValue : struct
        {
           
        }
        static void Add<TVal1, TVal2>(TVal1 x, TVal2 y) where TVal1:class where TVal2: class
        {

        }
    }
}
