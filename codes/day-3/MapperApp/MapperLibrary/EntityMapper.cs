using System.Reflection;

namespace MapperLibrary
{
    public class EntityMapper
    {
        public static TTarget Map<TSource, TTarget>(TSource source) where TTarget : new() where TSource : class
        {
            //TTarget target = new();
            TTarget target = Activator.CreateInstance<TTarget>();

            PropertyInfo[] sourceProperties = typeof(TSource).GetProperties();
            PropertyInfo[] targetProperties = typeof(TTarget).GetProperties();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo? targetProperty =
                    targetProperties
                    .ToList()
                    .Find(tp => tp.Name == sourceProperty.Name && tp.PropertyType == sourceProperty.PropertyType);

                if (targetProperty != null && targetProperty.CanWrite && sourceProperty.CanRead)
                {
                    var value = sourceProperty.GetValue(source);
                    targetProperty.SetValue(target, value);
                }
            }

            return target;
        }
    }
}
