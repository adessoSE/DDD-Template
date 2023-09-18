using DDDTemplate.Domain.Entities;

namespace DDDTemplate.Domain.Interfaces.Services
{      
    public interface ITemplateService
    {
        Task<TemplateEntity> CreateTemplateEntityAsync(TemplateEntity templateEntity);        
        Task<TemplateEntity> UpdateTemplateEntityAsync(TemplateEntity templateEntity);       
        Task DeleteTemplateEntityAsync(Guid id);
        Task<TemplateEntity?> GetTemplateEntityAsync(Guid id);
        Task<IEnumerable<TemplateEntity>> GetTemplateEntityListAsync();
        Task<TemplateEntity?> GetTemplateEntityDetailsAsync(Guid id);
        Task<TemplateEntity> CalculateTemplateEntityAsync(Guid id);
        Task ConfirmPriceTemplateEntityAsync(Guid entityId, Guid userId);
    }
}
