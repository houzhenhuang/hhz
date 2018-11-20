using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AutoMapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(x => x.CreateMap<User, UserDto>());
            //Mapper.Initialize(x => x.CreateMap<User, UserDto>()
            //    .ForMember(d => d.Name2, opt => { opt.MapFrom(s => s.Name); })
            //);
            User user = new User
            {
                Id = 1,
                Name = "张三",
                Age = 21
            };
            //AutoMapperHelper.MapTo<UserDto>(user);
            var dto = Mapper.Map<UserDto>(user);

            Type type = dto.GetType();
            PropertyInfo[] propertyInfo = type.GetProperties();
            foreach (var item in propertyInfo)
            {
                Console.WriteLine(item.Name + "=" + item.GetValue(dto));
            }
            Console.ReadKey();
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class UserDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
