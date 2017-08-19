using Creational.AbstractFactory.AbstractFactory;

namespace Creational.AbstractFactory.Client
{
    public class Client
    {
        private readonly AbstractElement.BaseElement _element;

        public Client(FactoryBase factory)
        {
            _element = factory.CreateElement();
        }

        public void DoWork()
        {
            _element.DoSomeThing();
        }
    }
}