using DDDTemplate.Application.Dtos.TemplateDetailDtos;
using DDDTemplate.Domain.Entities;

namespace DDDTemplate.Application.Mappings
{    
    public static class MapTemplateEntityToTemplateDetailDto
    {       
        public static TemplateDetailDto? GetTemplateDetailsDtoFromTemplateEntity(TemplateEntity? templateEntity)
        {
            if (templateEntity is null)
            {
                return null;
            }

            var templateDetailsDto = new TemplateDetailDto();
            SetSimpleProperties(templateDetailsDto, templateEntity);
            SetPositions(templateDetailsDto, templateEntity);
            return templateDetailsDto;
        }
        
        private static void SetSimpleProperties(TemplateDetailDto templateDetailsDto, TemplateEntity templateEntity)
        {
            templateDetailsDto.Id = templateEntity.Id;
            templateDetailsDto.Created = templateEntity.Created;
            templateDetailsDto.Name = templateEntity.Name;
            templateDetailsDto.Price = templateEntity.Price;
        }
        
        private static void SetPositions(TemplateDetailDto templateDetailsDto, TemplateEntity templateEntity)
        {
            foreach (var templatePosition in templateEntity.TemplatePositions)
            {                
                templateDetailsDto.TemplatePositions.Add(new TemplatePositionDto
                {
                    Name = templatePosition.Name
                });
            }
        }        
    }
}
