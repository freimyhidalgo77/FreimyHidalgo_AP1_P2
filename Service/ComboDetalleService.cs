using Microsoft.EntityFrameworkCore;
using FreimyHidalgo_AP1_P2.Models;
using FreimyHidalgo_AP1_P2.DAL;
using System.Linq.Expressions;



namespace FreimyHidalgo_AP1_P2.Service
{
    public class ComboDetalleService(IDbContextFactory<Context> DbFactory)
    {

        private readonly Context _context;

        public async Task<List<Producto>> Listar(Expression<Func<Producto, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Producto.Where(criterio).ToListAsync();
        }

        public async Task<bool> Eliminar(int detalleId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            var detalle = await contexto.CombosDetalles.FindAsync(detalleId);
            if (detalle != null)
            {
               
                contexto.CombosDetalles.Remove(detalle);
                await contexto.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
