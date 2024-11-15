using FreimyHidalgo_AP1_P2.DAL;
using FreimyHidalgo_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;



namespace FreimyHidalgo_AP1_P2.Service
{
    public class RegistroService(IDbContextFactory<Context> DbFactory)
    {
        public async Task<bool> Existe(int RegistroId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Registro.AnyAsync(r => r.RegistroId == RegistroId);
        }

        private async Task<bool> Insertar(Registro registro)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Registro.Add(registro);
            return await context.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(Registro registro)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Registro.Update(registro);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Registro registro)
        {
            if (!await Existe(registro.RegistroId))
                return await Insertar(registro);
            else
                return await Modificar(registro);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var eliminado = await contexto.Registro
                .Where(r => r.RegistroId == id)
                .ExecuteDeleteAsync();
            return eliminado > 0;
        }
        public async Task<Registro?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Registro
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.RegistroId == id);
        }

        public async Task<List<Registro>> Listar(Expression<Func<Registro, bool>> Criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Registro
                .AsNoTracking()
                .Where(Criterio)
                .ToListAsync();


        }

    }

}


