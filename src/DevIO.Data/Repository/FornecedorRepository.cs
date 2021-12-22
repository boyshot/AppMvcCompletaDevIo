using DevIO.Business.Models;
using DevIO.Business.Interfaces;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDBContext db) : base(db) { }

        public async Task<Fornecedor> ObterEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                              .Include(e => e.Endereco)
                              .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterProdutos(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                              .Include(p => p.Produtos)
                              .Include(e => e.Endereco)
                              .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
