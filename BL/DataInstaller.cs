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
using BL.DTO;
using System.Data.Entity;
using BL.Services;

namespace BL
{
    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(

                Component.For<AppDbContext>()
                .LifestyleTransient(),

                Component.For<OptionFacade>()
                .LifestyleTransient(),

                Component.For<QuestionFacade>()
                .LifestyleTransient(),

                Component.For<RoleFacade>()
                .LifestyleTransient(),

                Component.For<StudentGroupFacade>()
                .LifestyleTransient(),

                Component.For<TestSchemeFacade>()
                .LifestyleTransient(),

                Component.For<TopicFacade>()
                .LifestyleTransient(),

                Component.For<UserFacade>()
                .LifestyleTransient(),

                Component.For<TestFacade>()
                .LifestyleTransient(),

                Component.For<StudentGroupUserService>()
                .LifestyleTransient(),

                Component.For<QuestionOptionService>()
                .LifestyleTransient(),

                Component.For<StudentGroupTestSchemeService>()
                .LifestyleTransient(),

                Component.For<TopicQuestionService>()
                .LifestyleTransient(),

                Component.For<TestService>()
                .LifestyleTransient(),

                Component.For<IUserStore<User, int>>()
                .ImplementedBy<AppUserStore>()
                .LifestyleTransient(),

                Component.For<Func<AppUserManager>>()
                .Instance(() => new AppUserManager(new AppUserStore(new AppDbContext())))
                .LifestyleTransient()
            );
        }
    }
}
