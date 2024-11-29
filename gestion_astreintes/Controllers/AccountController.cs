using gestion_astreintes.Data;
using gestion_astreintes.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace gestion_astreintes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) return BadRequest("Utilisateur introuvable.");

            var result = await _userManager.ResetPasswordAsync(user, Uri.UnescapeDataString(model.Token), model.NewPassword);
            if (result.Succeeded) return Ok("Mot de passe réinitialisé avec succès.");

            return BadRequest(result.Errors);
        }
    }
}
