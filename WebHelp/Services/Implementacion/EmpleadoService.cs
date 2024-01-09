﻿using Microsoft.EntityFrameworkCore;
using WebHelp.Model;
using WebHelp.Services.Contrato;

namespace WebHelp.Services.Implementacion
{
    public class EmpleadoService : IEmpleadoService
    {
        private DbempleadoContext _dbContext;

        public EmpleadoService(DbempleadoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Empleado>> GetList()
        {
            try{
                List<Empleado>lista = new List<Empleado>();
                lista = await _dbContext.Empleados.Include(dpt => dpt.IdPaisNavigation).ToListAsync();
                lista = await _dbContext.Empleados.Include(dpt => dpt.IdAreaNavigation).ToListAsync();
                lista = await _dbContext.Empleados.Include(dpt => dpt.IdSubareaNavigation).ToListAsync();

                return lista;
            }
            catch (Exception ex) {
                throw ex;
            }

        }

        public async Task<Empleado> Get(int idEmpleado)
        {
            try
            {
                Empleado? encontrado = new Empleado();
                encontrado = await _dbContext.Empleados.Include(dpt => dpt.IdPaisNavigation)
                   .Where(e => e.IdEmpleado == idEmpleado).FirstOrDefaultAsync();

                encontrado = await _dbContext.Empleados.Include(dpt => dpt.IdAreaNavigation)
                    .Where(e => e.IdEmpleado == idEmpleado).FirstOrDefaultAsync();

                encontrado = await _dbContext.Empleados.Include(dpt => dpt.IdSubareaNavigation)
                    .Where(e => e.IdEmpleado == idEmpleado).FirstOrDefaultAsync();

                return encontrado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Empleado> Add(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(Empleado modelo)
        {
            try
            {
                _dbContext.Empleados.Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
