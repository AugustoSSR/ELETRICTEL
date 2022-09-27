using ELETRICTEL.Data;
using ELETRICTEL.Models;

namespace ELETRICTEL.Services
{
    public class TypesService
    {
        private readonly ELETRICTELContext _context;
        public TypesService(ELETRICTELContext context)
        {
            _context = context;
        }

        public List<Types> findAll()
        {
            // retornando uma lista ordenada pelo nome, ou seja, ela estara em ordem.
            return _context.Types.OrderBy(x => x.Name).ToList();
        }
    }
}
