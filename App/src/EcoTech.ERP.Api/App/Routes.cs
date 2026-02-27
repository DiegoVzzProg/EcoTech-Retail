using System.Reflection;
using EcoTech.ERP.Api.App.Common.Responses;
using EcoTech.ERP.Api.App.Interfaces;
using EcoTech.ERP.Api.App.Services;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.Commands;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.DTOs;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcoTech.ERP.Api.App
{
    public static class Routes
    {
        private static readonly string _groupRoute = "/api";

        internal static void Endpoints(this IEndpointRouteBuilder app)
        {
            RouteGroupBuilder group = app.MapGroup(_groupRoute);
            group.UsuariosEndpoints();
        }

        private static void UsuariosEndpoints(this RouteGroupBuilder group)
        {
            string groupRoute = "/usuarios";
            group.MapGet($"{groupRoute}/", ([FromServices] IUsuariosService service) => service.GetAll());
            
            group.MapGet($"{groupRoute}/{{id}}", ([FromServices] IUsuariosService service, Guid id) => service.GetByIdUsuario(id));

            group.MapPost($"{groupRoute}/", ([FromServices] IUsuariosService service, [FromBody] AddUsuarioCommand command) => service.CreateUsuario(command));
        }
    }
}
