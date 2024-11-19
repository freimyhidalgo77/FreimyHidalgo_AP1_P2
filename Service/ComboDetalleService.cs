using Microsoft.EntityFrameworkCore;
using FreimyHidalgo_AP1_P2.Models;
using FreimyHidalgo_AP1_P2.DAL;
using System.Linq.Expressions;


namespace FreimyHidalgo_AP1_P2.Service
{
    public class ComboDetalleService(IDbContextFactory<Context> DbFactory)
    {

        private readonly Context _context;

        public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Articulo.Where(criterio).ToListAsync();
        }
        public async Task<bool> Agregar(int articuloId, int cantidad)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            if (cantidad <= 0)
            {
                throw new ArgumentException("Error, la cantidad debe ser mayor que cero.");
            }

            var articulo = await contexto.Articulo.FindAsync(articuloId);

            if (articulo != null)
            {
                contexto.Articulo.Update(articulo);
                await contexto.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
