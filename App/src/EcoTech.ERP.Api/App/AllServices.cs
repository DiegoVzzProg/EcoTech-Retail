using EcoTech.ERP.Api.App.Interfaces;
using EcoTech.ERP.Api.App.Services;

namespace EcoTech.ERP.Api.App
{
    public static class AllServices
    {
        internal static void AddAllServices(this IServiceCollection collection)
        {
            collection.AddScoped<IUsuariosService, UsuariosService>();
        }
    }
}
