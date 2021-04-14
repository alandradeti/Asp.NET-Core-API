using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;

        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // General
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

         public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        // Events
        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events 
                .Include(c => c.Lots)
                .Include(c => c.SocialNetworks);

            if(includeSpeakers)
            {
                query = query
                        .Include(se => se.SpeakersEvents)
                        .ThenInclude(s => s.Speaker);
            }

            query = query.AsNoTracking()
                    .OrderByDescending(c => c.Date);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsAsyncByTheme(string theme, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events 
                .Include(c => c.Lots)
                .Include(c => c.SocialNetworks);

            if(includeSpeakers)
            {
                query = query
                        .Include(se => se.SpeakersEvents)
                        .ThenInclude(s => s.Speaker);
            }

            query = query.AsNoTracking()
                    .OrderByDescending(c => c.Date)
                    .Where(c => c.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventAsyncById(int eventId, bool includeSpeakers = false)
        {
             IQueryable<Event> query = _context.Events 
                .Include(c => c.Lots)
                .Include(c => c.SocialNetworks);

            if(includeSpeakers)
            {
                query = query
                        .Include(se => se.SpeakersEvents)
                        .ThenInclude(s => s.Speaker);
            }

            query = query.AsNoTracking()
                    .OrderByDescending(c => c.Date)
                    .Where(c => c.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }

        // Speakers
        public async Task<Speaker[]> GetAllSpeakersAsyncByName(string nameSpeaker, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(c => c.SocialNetworks);

            if(includeEvents)
            {
                query = query
                        .Include(se => se.SpeakersEvents)
                        .ThenInclude(e => e.Event);
            }

            query = query.AsNoTracking()
                    .Where(c => c.Name.ToLower().Contains(nameSpeaker.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakersAsyncById(int SpeakerId, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(c => c.SocialNetworks);

            if(includeEvents)
            {
                query = query
                        .Include(se => se.SpeakersEvents)
                        .ThenInclude(e => e.Event);
            }

            query = query.AsNoTracking()
                    .OrderBy(c => c.Name)
                    .Where(c => c.Id == SpeakerId);

            return await query.FirstOrDefaultAsync();
        }

       
    }
}