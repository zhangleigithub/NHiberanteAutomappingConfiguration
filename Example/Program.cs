using Summer.Example.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            UserDao userDao = new UserDao();
            userDao.Add();
            var v = userDao.Load();

            foreach (var item in v)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }

            Console.Read();
        }
    }
}
