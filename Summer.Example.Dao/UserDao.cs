using Summer.Example.Entity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Summer.AutomappingConfiguration;
using System.Reflection;

namespace Summer.Example.Dao
{
    public class UserDao
    {
        public ISessionFactory SessionFactory { get; set; }

        public UserDao()
        {
            this.SessionFactory = NHibernateFactory.CreateSessionFactory("MySql.cfg.xml", new string[] { "Summer.Example.Entity.dll" });
            //this.SessionFactory = NHibernateFactory.CreateMysqlSessionFactory("Database=HBTest;Data Source=localhost;User Id=root;Password=jdsn;charset=utf8", new string[] { "Summer.Example.Entity.dll" });
        }

        public void Add()
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                User user = new User() { Name = "user", UserEx = new UserEx() { Remark = "123" } };
                Authority authority = new Authority() { Name = "测试" };
                user.Authority = new List<Authority>(new Authority[] { authority });
                session.Save(user);
                session.Flush();
            }
        }

        public IList<User> Load()
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                return session.QueryOver<User>().List();
            }
        }
    }
}
