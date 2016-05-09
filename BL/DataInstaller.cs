using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DAL;
using BL;
using BL.Facades;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Entities;

namespace BL
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<AppDbContext>()
                .Instance(new AppDbContext())
                .LifestyleTransient(),

                Component.For<AppDbContext>()
                .Instance(new AppDbContext())
                .LifestyleTransient(),

                Component.For<OptionFacade>()
                .Instance(new OptionFacade())
                .LifestyleTransient(),

                Component.For<QuestionFacade>()
                .Instance(new QuestionFacade())
                .LifestyleTransient(),

                Component.For<RoleFacade>()
                .Instance(new RoleFacade())
                .LifestyleTransient(),

                Component.For<StudentGroupFacade>()
                .Instance(new StudentGroupFacade())
                .LifestyleTransient(),

                Component.For<TestSchemeFacade>()
                .Instance(new TestSchemeFacade())
                .LifestyleTransient(),

                Component.For<TopicFacade>()
                .Instance(new TopicFacade())
                .LifestyleTransient(),

                Component.For<UserFacade>()
                .Instance(new UserFacade())
                .LifestyleTransient()
            );
        }
    }
}
