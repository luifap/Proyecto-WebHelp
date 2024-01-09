using Microsoft.EntityFrameworkCore;
using WebHelp.Model;
using WebHelp.Services.Contrato;

namespace WebHelp.Services.Implementacion
{
    public class AreaService : IAreaService
    {
        private DbempleadoContext _dbContext;
        
        public AreaService(DbempleadoContext dbContext)
        {
           _dbContext = dbContext;
        }

        public async Task<List<Area>> GetList()
        {
            try{
                List<Area> lista = new List<Area>();
                lista = await _dbContext.Areas.ToListAsync();

                return lista;
            }
            catch(Exception ex){
                throw ex;
            }
        }
    }
}
