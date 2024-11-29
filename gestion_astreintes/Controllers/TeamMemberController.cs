using gestion_astreintes.Data;
using gestion_astreintes.Dtos;
using gestion_astreintes.Exceptions;
using gestion_astreintes.Models;
using gestion_astreintes.Services.Implementation;
using gestion_astreintes.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace gestion_astreintes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private ITeamMemberService _teamMemberService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly gestion_astreintes.Services.Interfaces.IEmailSender _emailSender;


        public TeamMemberController(UserManager<ApplicationUser> userManager, ITeamMemberService teamMemberService, gestion_astreintes.Services.Interfaces.IEmailSender emailSender)
        {
            _userManager = userManager;
            this._teamMemberService = teamMemberService;
            this._emailSender = emailSender;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public ActionResult<IEnumerable<TeamMemberDto>> GetTeamMembers()
        {
            try
            {
                return Ok(_teamMemberService.GetTeamMembers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{id}")]
        public ActionResult<TeamMemberDto> GetTeamMemberById(int id)
        {
            try
            {
                return Ok(_teamMemberService.GetTeamMemberByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Authorize(Policy = "TeamLeaderOnly")]
        [HttpGet("{id}/astreintes")]
        public ActionResult<EmpAstreintesDto> GetAstreintesByEmployeeId(int id)
        {
            return Ok(_teamMemberService.GetAstreintesByEmployeeId(id));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> AddTeamMember([FromBody] TeamMemberForCreationDto teamMemberForCreDto)
        {
            try
            {
                TeamMemberDto teamMemberDto = _teamMemberService.AddTeamMember(teamMemberForCreDto);
                var teamMember = new ApplicationUser { UserName = teamMemberDto.Email, Email = teamMemberDto.Email };
                var result = await _userManager.CreateAsync(teamMember , "ayoubBh123!!!");
                
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(teamMember, teamMemberDto.MemberTypeName.ToUpper());

                    // Générer un token de réinitialisation de mot de passe
                    var token = await _userManager.GeneratePasswordResetTokenAsync(teamMember);
                    // Générer un lien pour réinitialiser le mot de passe
                    var callbackUrl = $"http://localhost:3000/resetPassword?userId={teamMember.Id}&token={Uri.EscapeDataString(token)}";

                    // Construire le contenu de l'email
                    var message = $@"
                    Bonjour {teamMember.UserName},<br><br>
                    Votre compte a été créé avec succès.<br>
                    Cliquez sur le lien ci-dessous pour définir votre mot de passe et accéder à votre compte :<br>
                    <a href='{callbackUrl}'>Définir mon mot de passe</a><br><br>
                       Cordialement,<br> L'équipe.";

                    // Envoyer l'e-mail
                    await _emailSender.SendEmailAsync(teamMember.Email, "Bienvenue dans l'application", message);
                }
                return Created(string.Empty, teamMemberDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut]
        public IActionResult EditTeamMember([FromBody] TeamMemberForEditDto teamMemberForEdit)
        {
            try
            {
                _teamMemberService.EditTeamMember(teamMemberForEdit);
                return Ok(teamMemberForEdit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public IActionResult DeleteTeamMember(int id)
        {
            try
            {
                _teamMemberService.DeleteTeamMember(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
