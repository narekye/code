using Ninject;

namespace sharp.IocContainer.Console
{
    class Service
    {
        [Inject]
        private IMailSender sender;

        public Service(IMailSender sender)
        {
            this.sender = sender;
        }
    }
}
