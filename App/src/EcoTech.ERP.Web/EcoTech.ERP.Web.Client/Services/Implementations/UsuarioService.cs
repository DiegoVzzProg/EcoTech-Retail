using System.Net.Http.Json;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.DTOs;
using EcoTech.ERP.Web.Client.Services.Common;
using EcoTech.ERP.Web.Client.Services.Interfaces;

namespace EcoTech.ERP.Web.Client.Services.Implementations
{
    public class UsuarioService(HttpClient http) 
        : BaseService<UsuariosDto>(http, "usuarios"), IUsuarioService
    {

    }
}
