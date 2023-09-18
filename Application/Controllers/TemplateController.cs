using Microsoft.AspNetCore.Mvc;
using DDDTemplate.Application.Dtos.TemplateDetailDtos;
using DDDTemplate.Application.Mappings;
using DDDTemplate.Domain.Interfaces.Services;
using DDDTemplate.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DDDTemplate.Application.Controllers
{    
    [ApiController]
    [Route("[controller]s")]
    [AllowAnonymous]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _templateService;
        
        public TemplateController(ITemplateService templateService)
        {
            _templateService = templateService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<TemplateDto>>> GetTemplateListAsync()
        {
            var list = await _templateService.GetTemplateEntityListAsync();
            return Ok(list);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateDetailDto>> GetTemplateDetailsAsync(Guid id)
        {
            var template = await _templateService.GetTemplateEntityDetailsAsync(id);
            var templateDto = MapTemplateEntityToTemplateDetailDto.GetTemplateDetailsDtoFromTemplateEntity(template);
            return Ok(templateDto);
        }

        [HttpPost()]
        public async Task<ActionResult> CreateTemplateAsync([FromBody] TemplateDetailDto templateDetailDto)
        {
            if (templateDetailDto is not null)
            {
                var templateEntity = MapTemplateDetailDtoToTemplateEntity.GetTemplateEntityFromTemplateDetailDto(templateDetailDto);
                await _templateService.CreateTemplateEntityAsync(templateEntity);
                return Ok();
            }
            else 
            { 
                return BadRequest(); 
            }            
        }

        [HttpPut("/confirm/{id}")]
        public async Task<ActionResult> ConfirmTemplateAsync([FromRoute] string id)
        {
            var entityId = Guid.Parse(id);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            await _templateService.ConfirmPriceTemplateEntityAsync(entityId, Guid.Parse(userId));
            return Ok();
        }
    }
}
