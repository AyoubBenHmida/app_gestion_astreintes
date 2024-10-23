﻿using AutoMapper;
using gestion_astreintes.Data;
using gestion_astreintes.Dtos;
using gestion_astreintes.Exceptions;
using gestion_astreintes.Models;
using gestion_astreintes.Repositories.Implementation;
using gestion_astreintes.Services.Implementation;
using gestion_astreintes.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestion_astreintes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;
        
        public TeamController(ITeamService teamService )
        {
            this._teamService = teamService;
            
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<TeamDto>> GetTeams()
        {
            return Ok(_teamService.GetTeams());
    }

        [HttpGet("{id}")]
        public ActionResult<TeamDto> GetTeamById(int id) {
            try
            {
                return Ok(_teamService.GetTeamByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/details")]
        public ActionResult<TeamDetailsDto> GetTeamDetailsById(int id)
        {
            return Ok(_teamService.GetTeamDetailsById(id));
        }

        [HttpPost] 
        public IActionResult AddTeam([FromBody] TeamForCreationDto teamForCreDto )
        {
            try
            {
                TeamDto teamDto = _teamService.AddTeam(teamForCreDto);
                return Created(string.Empty , teamDto);
            }
            catch (TeamExistsException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditTeam([FromBody] TeamDto teamDto ) {
            try
            {
                _teamService.EditTeam(teamDto);
                return Ok(teamDto);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id) {
            try
            {
                _teamService.DeleteTeam(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        


    }
}
