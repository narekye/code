using Ninject.Modules;
using sharp.IocContainer.Console.Interfaces;

namespace sharp.IocContainer.Console.Module
{
    class WarriorModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWeapon>().To<Sword>();
            
        }
    }
}
