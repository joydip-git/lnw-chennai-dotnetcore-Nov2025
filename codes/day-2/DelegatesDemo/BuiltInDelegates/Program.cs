namespace BuiltInDelegates
{
    //delegate bool Predicate<in T>(T obj);

    //delegate TResult Func<out TResult>();
    //delegate TResult Func<in T, out TResult>(T arg);
    //...
    //delegate TResult Func<in T1,...,in T16, out TResult>(T1 arg1,...,T16 arg16);

    //delegate void Action();
    //delegate void Action<in T>(T obj);

    internal class Program
    {
        static void Main(string[] args)
        {
            //source of data
            List<int> numbers = [1, 3, 2, 5, 4, 8, 6, 0, 7, 9];
            List<string> names = ["Alice", "Batman", "Alison", "Suman", "Joy"];

            Func<int, bool> evenDel = num => num % 2 == 0;
            //List<int> evenNumbers = numbers.Where(evenDel).ToList();
            List<int> evenNumbers = [.. numbers.Where(evenDel)];

            Action<int> printDel = num => Console.WriteLine(num);
            numbers.ForEach(printDel);

            Console.WriteLine("\n");

            Func<int, bool> oddDel = num => num % 2 != 0;
            List<int> oddNumbers = [.. numbers.Where(oddDel)];
            numbers.ForEach(printDel);
            Console.WriteLine("\n");


            List<string> namesWithA = [.. names.Where(name => name.ToLower().StartsWith('a'))];
            numbers.ForEach(printDel);

            Console.WriteLine("\n");

            //List<string> namesEndingWithN = [.. names.Where(name => name.ToLower().EndsWith('n'))];
            //numbers.ForEach(printDel);

            //Language Integrated Query (LINQ) - Method Syntax
            //immediate execution
            names
                .Where(name => name.ToLower().EndsWith('n'))
                .ToList()
                .ForEach(name => Console.WriteLine(name));

            //LINQ - Query Syntax
            //delays the execution until the data is enumerated => deferred execution
            var query =
                from name in names
                where name.ToLower().EndsWith('n')
                select name;

            //immediate execution
            query
                .ToList()
                .ForEach(name => Console.WriteLine(name));

            //var => implicitly typed local variable
        }
    }
}
