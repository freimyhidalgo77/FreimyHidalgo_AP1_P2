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
            return await contexto.Combo.AnyAsync(r => r.ComboId == RegistroId);
        }

        private async Task<bool> Insertar(Combo combo)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Combo.Add(combo);
            return await context.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(Combo combo)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Combo.Update(combo);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Combo combo)
        {
            if (!await Existe(combo.ComboId))
                return await Insertar(combo);
            else
                return await Modificar(combo);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var eliminado = await contexto.Combo
                .Where(r => r.ComboId == id)
                .ExecuteDeleteAsync();
            return eliminado > 0;
        }
        public async Task<Combo?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Combo
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.ComboId == id);
        }

        public async Task<List<Combo>> Listar(Expression<Func<Combo, bool>> Criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Combo
                .AsNoTracking()
                .Where(Criterio)
                .ToListAsync();

        }


       /* public async Task<Combo> BuscarConDetalles(int Id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Combo
                .Include(t => t.ComboDetalle)
                .ThenInclude(td => td.Articulo)
                .FirstOrDefaultAsync(t => t.ComboId == Id);
        }*/



    }
}
