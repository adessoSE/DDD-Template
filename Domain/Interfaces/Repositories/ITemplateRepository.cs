using DDDTemplate.Domain.Entities;

using Kernel.Contracts.Interfaces.Repositories;

namespace DDDTemplate.Domain.Interfaces.Repositories
{   
    public interface ITemplateRepository : IRepository<TemplateEntity, Guid>
    {        
        Task<TemplateEntity?> GetTemplateDetailsByIdAsync(Guid id);                
    }
}
