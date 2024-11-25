using Microsoft.EntityFrameworkCore;
using FreimyHidalgo_AP1_P2.DAL;
using FreimyHidalgo_AP1_P2.Models;
using System.Linq.Expressions;

namespace FreimyHidalgo_AP1_P2.Service
{
    public class ComboService(IDbContextFactory<Context> DbFactory)
    {

        public async Task<bool> Existe(int RegistroId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Combo1.AnyAsync(r => r.ComboId == RegistroId);
        }

        private async Task<bool> Insertar(Combo1 combo)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Combo1.Add(combo);
            return await context.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(Combo1 combo)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Combo1.Update(combo);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Combo1 combo)
        {
            if (!await Existe(combo.ComboId))
                return await Insertar(combo);
            else
                return await Modificar(combo);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var eliminado = await contexto.Combo1
                .Where(r => r.ComboId == id)
                .ExecuteDeleteAsync();
            return eliminado > 0;
        }
        public async Task<Combo1?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Combo1
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.ComboId == id);
        }

        public async Task<List<Combo1>> Listar(Expression<Func<Combo1, bool>> Criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Combo1
                .AsNoTracking()
                .Where(Criterio)
                .ToListAsync();

        }


        public async Task<Combo1> BuscarConDetalles(int Id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Combo1
                .Include(t => t.ComboDetalle)
                .ThenInclude(td => td.Articulos)
                .FirstOrDefaultAsync(t => t.ComboId == Id);
        }



    }
}
