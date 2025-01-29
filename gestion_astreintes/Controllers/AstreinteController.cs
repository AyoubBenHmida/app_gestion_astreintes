using AutoMapper;
using gestion_astreintes.Data;
using gestion_astreintes.Dtos;
using gestion_astreintes.Exceptions;
using gestion_astreintes.Models;
using gestion_astreintes.Repositories.Implementation;
using gestion_astreintes.Repositories.Interfaces;
using gestion_astreintes.Services.Implementation;
using gestion_astreintes.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace gestion_astreintes.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AstreinteController : ControllerBase
    {
        private IAstreinteService _astreinteService;

        public AstreinteController(IAstreinteService astreinteService)
        {
            this._astreinteService = astreinteService;

        }

        [Authorize(Policy = "TeamLeaderOnly")]
        [HttpGet]
        public ActionResult<IEnumerable<AstreinteDto>> GetAstreintes()
        {
            return Ok(_astreinteService.GetAstreintes());
        }

        [Authorize(Policy = "TeamLeaderOnly")]
        [HttpGet("{id}")]
        public ActionResult<AstreinteDto> GetAstreinteById(int id)
        {
            try
            {
                return Ok(_astreinteService.GetAstreinteByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "EmployeeOnly")]
        [HttpPost]
        public IActionResult AddAstreinte([FromBody] AstreinteForCreationDto astreinteForCreDto)
        {
            try
            {
                AstreinteDto astreinteDto = _astreinteService.AddAstreinte(astreinteForCreDto);
                return Created(string.Empty, astreinteDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "EmployeeOnly")]
        [HttpPut]
        public IActionResult EditAstreinte([FromBody] AstreinteForEditDto astreinteForEdit)
        {
            try
            {
                _astreinteService.EditAstreinte(astreinteForEdit);
                return Ok(astreinteForEdit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "EmployeeOnly")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAstreinte(int id)
        {
            try
            {
                _astreinteService.DeleteAstreinte(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "TeamLeaderOnly")]
        [HttpPatch("{id}")]
        public IActionResult ChangeAstreinteStatus(int id, [FromBody] JsonPatchDocument<AstreinteDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            AstreinteDto astreinte = _astreinteService.GetAstreinteByID(id);
            patchDoc.ApplyTo(astreinte, (error) =>
            {
                ModelState.AddModelError(error.AffectedObject.ToString(), error.ErrorMessage);
            });

            _astreinteService.UpdateStatus(astreinte) ;

            return Ok(astreinte);
        }
    }
}
