using DDDTemplate.Application.Dtos.TemplateDetailDtos;
using DDDTemplate.Domain.Entities;

namespace DDDTemplate.Application.Mappings
{    
    public static class MapTemplateDetailDtoToTemplateEntity
    {       
        public static TemplateEntity GetTemplateEntityFromTemplateDetailDto(TemplateDetailDto templateDto)
        {
            var templateEntity = new TemplateEntity 
            {
                Name = templateDto.Name
            };            
            SetPositions(templateDto, templateEntity);
            return templateEntity;
        }        
       
        
        private static void SetPositions(TemplateDetailDto templateDto, TemplateEntity templateEntity)
        {
            foreach (var positionDto in templateDto.TemplatePositions)
            {                
                templateEntity.TemplatePositions.Add(new TemplatePosition
                {
                    Name = positionDto.Name
                });
            }
        }         
    }
}
