using System;
using System.Collections.Generic;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace EcoTech.ERP.Enterprise.Application.Features.Common
{
    internal static class PasswordHelper
    {
        /// <summary>
        /// Hashea una contraseña en texto plano
        /// </summary>
        public static string HashPassword(string password)
        {
            return BC.EnhancedHashPassword(password, 13); // 13 es un buen costo actual
        }

        /// <summary>
        /// Verifica si una contraseña coincide con el hash
        /// </summary>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BC.EnhancedVerify(password, hashedPassword);
        }
    }
}
