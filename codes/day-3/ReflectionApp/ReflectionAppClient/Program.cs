using System.Reflection;

namespace ReflectionAppClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = null;
            try
            {
                //loading assembly dynamically
                assembly = LoadAssembly();

                Console.WriteLine("\n\n");
                //get type information
                ShowAllTypes(assembly);

                Console.WriteLine("\n\n");
                Type savingsAccType = GetATypeInfo(assembly);

                Console.WriteLine("\n\n");
                //constructors
                GetAllConstructors(savingsAccType);

                //create instance dynamically
                object savingsAccInstance = CreateInstanceDynamically(savingsAccType);

                //properties
                PropertyInfo[] properties = GetAllProperties(savingsAccType);

                //extract single property and set value
                PropertyInfo accNoProp = savingsAccType.GetProperty("AccountNumber");
                PropertyInfo accNameProp = savingsAccType.GetProperty("Name");
                PropertyInfo accBalanceProp = savingsAccType.GetProperty("Balance");

                accNoProp.SetValue(savingsAccInstance, 1001);
                accNameProp.SetValue(savingsAccInstance, "joydip");
                accBalanceProp.SetValue(savingsAccInstance, 10000m);

                Console.WriteLine("\n\n After setting property values:");
                properties
                    .ToList()
                    .ForEach(p =>
                    {
                        Console.WriteLine($"Property: {p.Name}, Value: {p.GetValue(savingsAccInstance)}");
                    });

                //methods
                GetAllMethods(savingsAccType);

                //extract a method
                MethodInfo withdrawMethod = savingsAccType.GetMethod("Withdraw");

                //get method parameters
                ParameterInfo[] parameterInfos = withdrawMethod.GetParameters();

                Console.WriteLine($"\n\n Method: {withdrawMethod.Name} Parameters:");
                parameterInfos
                    .ToList()
                    .ForEach(p =>
                    {
                        Console.WriteLine($"\t Param: Name={p.Name}, Type={p.ParameterType}, Position: {p.Position}");
                    });

                //invoke withdraw method
                object[] parametersForWithdraw = new object[] { 3000m };
                withdrawMethod.Invoke(savingsAccInstance, parametersForWithdraw);

                Console.WriteLine($"\n\n After invoking Withdraw method, current balance: {accBalanceProp.GetValue(savingsAccInstance)}");

                //field info
                FieldInfo[] allFields = savingsAccType
                    .BaseType
                     .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                allFields
                    .ToList()
                    .ForEach(f =>
                    {
                        Console.WriteLine($"Field: {f.Name}, Type: {f.FieldType}");
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void GetAllMethods(Type savingsAccType)
        {

            //methods
            MethodInfo[] methods = savingsAccType.GetMethods();

            Console.WriteLine("\n\n Methods:");
            methods.ToList().ForEach(p =>
            {
                Console.WriteLine($"Method: {p.Name}, Return Type: {p.ReturnType}");
            });
        }

        private static PropertyInfo[] GetAllProperties(Type savingsAccType)
        {
            //propeties
            PropertyInfo[] properties = savingsAccType.GetProperties();
            Console.WriteLine("\n\n");
            properties.ToList().ForEach(p =>
            {
                Console.WriteLine($"Property: {p.Name}, Type: {p.PropertyType}");
            });
            return properties;
        }

        private static object CreateInstanceDynamically(Type savingsAccType)
        {

            //create object dynamically based on the metadata using default ctor
            object savingsAccInstance = Activator.CreateInstance(savingsAccType);
            Console.WriteLine(savingsAccInstance.GetType().Name);
            return savingsAccInstance;
        }

        private static void GetAllConstructors(Type savingsAccType)
        {
            ConstructorInfo[] constructors = savingsAccType.GetConstructors();

            constructors.ToList().ForEach(c =>
            {
                Console.WriteLine($"Constructor: {c.Name}");

                ParameterInfo[] parameters = c.GetParameters();
                if (parameters.Length == 0)
                {
                    Console.WriteLine("\t No parameters");
                }
                else
                    foreach (var param in parameters)
                    {
                        Console.WriteLine($"\t Param: Name={param.Name}, Type={param.ParameterType}, Position:{param.Position}");
                    }
            });
        }

        private static Type GetATypeInfo(Assembly assembly)
        {
            //get specific type
            Type savingsAccType = assembly.GetType("BankAccountLibrary.SavingsAccount");
            Console.WriteLine($"Is abstract? {savingsAccType.IsAbstract}");
            return savingsAccType;
        }

        private static void ShowAllTypes(Assembly assembly)
        {
            Type[] allTypes = assembly.GetTypes();
            allTypes
                .ToList()
                .ForEach(t =>
                {
                    Console.WriteLine($"Name={t.FullName}");
                    Console.WriteLine($"Is Class? {t.IsClass}");
                    Console.WriteLine($"Is Interface? {t.IsInterface}");
                    Console.WriteLine($"Is Value Type? {t.IsValueType}");
                });
        }

        private static Assembly LoadAssembly()
        {
            Assembly assembly = Assembly.LoadFrom(@"E:\lnw-chennai-dotnetcore-Nov2025\codes\day-1\AccountServiceApp\BankAccountLibrary\bin\Debug\net9.0\BankAccountLibrary.dll");
            Console.WriteLine($"Name:\n {assembly.FullName}");
            return assembly;
        }
    }
}
