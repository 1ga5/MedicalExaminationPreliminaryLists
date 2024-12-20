﻿using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Infrastructure.Repositories;
using MedicalExaminationPreliminaryLists.Share.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalExaminationPreliminaryLists.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UploadFilesController : ControllerBase
    {
        private readonly IUploadFileRepository _repository;

        public UploadFilesController(IUploadFileRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UploadFileModel>>> GetAll()
        {
            var files = await _repository.GetAll().ToListAsync();

            var dictionariesDTO = files.Select(f => new UploadFileModel
            {
                Id = f.Id,
                FileName = f.FileName,
                UploadDate = f.UploadDate
            });

            return Ok(dictionariesDTO);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UploadFile>>> Update(Guid id, UploadFile newFileDTO)
        {
            var file = await _repository.GetByKeyAsync(id);

            if (file == null)
            {
                return NotFound();
            }

            file.FileName = newFileDTO.FileName;
            file.UploadDate = newFileDTO.UploadDate;

            await _repository.SaveChangesAsync();

            newFileDTO.Id = file.Id;

            return Ok(newFileDTO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UploadFile>>> Delete(Guid id)
        {
            var dictionary = await _repository.GetByKeyAsync(id);

            if (dictionary == null)
            {
                return NotFound();
            }

            await _repository.VirtualDelete(dictionary, 0);
            await _repository.SaveChangesAsync();

            return Ok("Успешно удалено");
        }
    }
}
