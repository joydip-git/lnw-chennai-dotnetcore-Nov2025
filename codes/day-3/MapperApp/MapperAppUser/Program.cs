using MapperLibrary;
namespace MapperAppUser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new() { Id = 1, Name = "John Doe" };
            UserDto userDto = EntityMapper.Map<User, UserDto>(user);
            Console.WriteLine(userDto.Id + " " + userDto.Name);
        }
    }
}
