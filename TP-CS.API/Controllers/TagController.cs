using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TP_CS.Business.DTO;
using TP_CS.Business.IServices;
using TP_CS.Business.Models;

namespace TP_CS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService ?? throw new ArgumentNullException(nameof(tagService));
        }

        [HttpGet]
        public IActionResult GetTags()
        {
            var tags = _tagService.GetTags();
            return Ok(tags);
        }

        [HttpGet("{id:long}", Name = "GetTagById")]
        public IActionResult GetTagById(long id)
        {
            var tag = _tagService.GetTagById(id);
            if (tag == null)
            {
                return NotFound($"Étiquette avec l'ID {id} introuvable.");
            }

            return Ok(tag);
        }

        [HttpPost]
        public IActionResult CreateTag(TagDto.createTagDto tag)
        {
            Tag createdTag = new Tag()
            {
                Name = tag.Name,
                Color = tag.Color,
                Description = tag.Description,
                Iscomplete = tag.Iscomplete
            };
            var createdTagResult = _tagService.CreateTag(createdTag);
            return CreatedAtRoute("GetTagById", new { id = createdTag.Id }, createdTag);
        }

        [HttpDelete]
        public IActionResult DeleteTag(long id)
        {
            var tag = _tagService.DeleteTag(id);
            if (tag == null)
            {
                return NotFound($"Étiquette avec l'ID {id} introuvable.");
            }

            return NoContent();
        }
        
        [HttpPut("{id:long}")]
        public IActionResult UpdateTag(long id, TagDto.updateTagDto tag)
        {
            return NotFound();
        }
    }
}