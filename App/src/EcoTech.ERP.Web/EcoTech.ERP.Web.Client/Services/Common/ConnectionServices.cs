using EcoTech.ERP.Web.Client.Services.Implementations;
using EcoTech.ERP.Web.Client.Services.Interfaces;

namespace EcoTech.ERP.Web.Client.Services.Common
{
    public static class ConnectionServices
    {
        public static void AddAllServices(this IServiceCollection collection)
        {
            collection.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
