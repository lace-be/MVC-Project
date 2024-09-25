using MvcProject.Data.Repository;
using MvcProject.Models;

namespace MvcProject.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Studiebezoek> StudiebezoekRepository { get; }
        IRepository<FotoAlbum> FotoAlbumsRepository { get; }
        IRepository<Afwezigheid> AfwezighedenRepository { get; }
        IRepository<Navorming> NavormingRepository { get; }
        IRepository<Rol> RollenRepository { get; }
        IRepository<Gebruiker> GebruikersRepository { get; }
        IRepository<GebruikerRol> GebruikerRolRepository { get; }
        public void SaveChanges();
    }
}