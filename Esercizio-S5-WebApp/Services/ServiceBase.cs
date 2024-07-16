using System.Data.Common;

namespace Esercizio_S5_WebApp.Services
{
    public abstract class ServiceBase
    {
        protected abstract DbConnection GetConnection();
        protected abstract DbCommand GetCommand(string commandText);

    }
}
