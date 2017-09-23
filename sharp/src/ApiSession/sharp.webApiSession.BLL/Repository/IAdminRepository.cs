using System;

namespace sharp.webApiSession.BLL.Repository
{
    public interface IAdminRepository : IDisposable
    {
        int DoWork();
    }
}
