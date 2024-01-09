using Microsoft.EntityFrameworkCore;
using WebHelp.Model;
using WebHelp.Services.Contrato;

namespace WebHelp.Services.Implementacion
{
    public class SubareaService : ISubareaService
    {
        private DbempleadoContext _dbContext;

        public SubareaService(DbempleadoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Subarea>> GetList()
        {
            try{
                List<Subarea> lista = new List<Subarea>();
                lista = await _dbContext.Subareas.ToListAsync();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
