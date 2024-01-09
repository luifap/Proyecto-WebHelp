using System.Collections.Generic;
using WebHelp.Model;
namespace WebHelp.Services.Contrato
{
    public interface IPaisService
    {
        Task<List<Area>> GetList();
    }
}
