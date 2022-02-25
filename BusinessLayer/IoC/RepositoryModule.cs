using Autofac;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IoC
{
    class RepositoryModule : Module // bagımlılıklardan kurtulmak amacıyla IoC Containerlardan yardım almak 
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            //builder.RegisterType<GenericRepository<T>().As<IGenericDal<T>().InstancePerLifetimeScope();


        }
    }
}
