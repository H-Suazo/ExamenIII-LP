using Datos.Repositorios;
using Examen_III_Parcial.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Security.Claims;

namespace Examen_III_Parcial.Controllers
{
    public class LoginController : Controller
    {
        private readonly MySqlConfigurations _configuration;
        private UsuarioRepositorio _usuarioRepositorio;

        public LoginController(MySqlConfigurations configuration)
        {
            _configuration = configuration;
            _usuarioRepositorio = new UsuarioRepositorio(configuration.CadenaConexion);
        }

        [HttpPost("/account/login")]
        public async Task<IActionResult> Login(Login login)
        {
            string rol = string.Empty;
            try
            {
                bool usuarioValido = await _usuarioRepositorio.ValidaUsuario(login);
                if (usuarioValido)
                {
                    Usuario usu = await _usuarioRepositorio.GetPorCodigo(login.Codigo);
                    if (usu.EstaActivo)
                    {
                        rol = usu.Rol;

                        var claims = new[]
                        {
                        new Claim(ClaimTypes.Name, usu.Codigo),
                        new Claim(ClaimTypes.Role, rol)
                    };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,
                                                    new AuthenticationProperties
                                                    {
                                                        IsPersistent = true,
                                                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                                                    });
                    }
                    else
                    {
                        return LocalRedirect("/login/Usuario Inactivo");
                    }
                }
                else
                {
                    return LocalRedirect("/login/Datos de usuario Inválido");
                }
            }
            catch (Exception ex)
            {
                return LocalRedirect("/login/Datos de usuario Inválido");
            }
            return LocalRedirect("/");
        }

        [HttpGet("/account/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}
