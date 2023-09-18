using Microsoft.EntityFrameworkCore;
using DDDTemplate.Domain.Interfaces.Repositories;
using DDDTemplate.Domain.Entities;
using Kernel.Base.Repositories;

namespace DDDTemplate.Infrastructure.Persistence
{    
    public class TemplateRepository 
        : RepositoryBase<TemplateEntity, Guid, TemplateDbContext>, ITemplateRepository
    {        
        public TemplateRepository(TemplateDbContext dbContext) : base(dbContext)
        {            
        }            
        
        public async Task<TemplateEntity?> GetTemplateDetailsByIdAsync(Guid id)
        {
            var templateEntity = await DbContext
                .TemplateEntities
                .Include(x => x.TemplatePositions)                
                .FirstOrDefaultAsync(x => x.Id == id);

            return templateEntity;
        }         
    }
}
