using gestion_astreintes.Dtos;
using gestion_astreintes.Exceptions;
using gestion_astreintes.Models;
using gestion_astreintes.Services.Implementation;
using gestion_astreintes.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gestion_astreintes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private ITeamMemberService _teamMemberService;

        public TeamMemberController(ITeamMemberService teamMemberService)
        {
            this._teamMemberService = teamMemberService;
        }

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

        [HttpGet("{id}/astreintes")]
        public ActionResult<EmpAstreintesDto> GetAstreintesByEmployeeId(int id)
        {
            return Ok(_teamMemberService.GetAstreintesByEmployeeId(id));
        }

        [HttpPost]
        public IActionResult AddTeamMember([FromBody] TeamMemberForCreationDto teamMemberForCreDto)
        {
            try
            {
                TeamMemberDto teamMemberDto = _teamMemberService.AddTeamMember(teamMemberForCreDto);
                return Created(string.Empty, teamMemberDto);
            }
            catch (TeamMemberExistsException ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
