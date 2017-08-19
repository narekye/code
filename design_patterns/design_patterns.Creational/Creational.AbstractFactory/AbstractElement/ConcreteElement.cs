using System;

namespace Creational.AbstractFactory.AbstractElement
{
    public class ConcreteElement : BaseElement
    {
        public override void DoSomeThing()
        {
            Console.WriteLine("Work goes");
        }
    }
}
