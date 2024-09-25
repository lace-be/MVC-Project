using MvcProject.Data.Repository;
using MvcProject.Models;

namespace MvcProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            StudiebezoekRepository = new Repository<Studiebezoek>(_context);
            FotoAlbumsRepository = new Repository<FotoAlbum>(_context);
            NavormingRepository = new Repository<Navorming>(_context);
            AfwezighedenRepository = new Repository<Afwezigheid>(_context);
            RollenRepository = new Repository<Rol>(_context);
            GebruikersRepository = new Repository<Gebruiker>(_context);
        }

        public IRepository<Studiebezoek> StudiebezoekRepository { get; }
        public IRepository<FotoAlbum> FotoAlbumsRepository { get; }
        public IRepository<Navorming> NavormingRepository { get; }
        public IRepository<Afwezigheid> AfwezighedenRepository { get; }
        public IRepository<Rol> RollenRepository { get; }
        public IRepository<Gebruiker> GebruikersRepository { get; }
        public IRepository<GebruikerRol> GebruikerRolRepository { get; }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}