﻿using AutoMapper;
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

namespace gestion_astreintes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AstreinteController : ControllerBase
    {
        private IAstreinteService _astreinteService;

        public AstreinteController(IAstreinteService astreinteService)
        {
            this._astreinteService = astreinteService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<AstreinteDto>> GetAstreintes()
        {
            return Ok(_astreinteService.GetAstreintes());
        }

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

        [HttpDelete("{id}")]
        public IActionResult DeleteTeamMember(int id)
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