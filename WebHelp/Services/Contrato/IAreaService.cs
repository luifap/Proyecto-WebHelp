using System.Collections.Generic;
using WebHelp.Model;
namespace WebHelp.Services.Contrato
{
    public interface IAreaService
    {
        Task<List<Area>> GetList();
    }
}
