namespace sharp.IocContainer.Console.Interfaces
{
    class Sword : IWeapon
    {
        public void Shot()
        {
            System.Console.WriteLine("Sword shot");
        }
    }
}
