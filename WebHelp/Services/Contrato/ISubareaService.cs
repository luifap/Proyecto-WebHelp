using WebHelp.Model;
namespace WebHelp.Services.Contrato
{
    public interface ISubareaService
    {
        Task<List<Subarea>> GetList();
    }
}
