using Ninject;
using sharp.IocContainer.Console.Interfaces;

namespace sharp.IocContainer.Console
{
    public class Samurai
    {
        [Inject]
        public IWeapon Weapon { get; private set; }

        public Samurai(IWeapon weapon)
        {
            Weapon = weapon;
        }
    }
}