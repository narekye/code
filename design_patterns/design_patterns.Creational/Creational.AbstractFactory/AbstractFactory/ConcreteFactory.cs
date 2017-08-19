using Creational.AbstractFactory.AbstractElement;

namespace Creational.AbstractFactory.AbstractFactory
{
    public class ConcreteFactory : FactoryBase
    {
        public override BaseElement CreateElement()
        {
            return new ConcreteElement();
        }
    }
}
