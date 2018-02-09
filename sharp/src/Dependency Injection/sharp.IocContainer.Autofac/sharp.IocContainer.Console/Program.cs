using Ninject;
using sharp.IocContainer.Console.Interfaces;
using sharp.IocContainer.Console.Module;
using System.Reflection;

namespace sharp.IocContainer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();

            kernel.Load<WarriorModule>();
            IWeapon _obj = GetDependencyFromKernel<IWeapon>(kernel);

            var samurai = new Samurai(_obj);

            samurai.Weapon.Shot();
        }

        static T GetDependencyFromKernel<T>(IKernel kernel)
        {
            T result = kernel.Get<T>();
            if (result == null) result = default(T);
            return result;
        }
    }
}
