using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        // General
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangeAsync();

         //Events
         Task<Event[]> GetAllEventsAsyncByTheme(string theme, bool includeSpeakers);
         Task<Event[]> GetAllEventsAsync(bool includeSpeakers);
         Task<Event> GetEventAsyncById(int eventId, bool includeSpeakers);

         //Speakers
         Task<Speaker[]> GetAllSpeakersAsyncByName(string nameSpeaker, bool includeEvents);
         Task<Speaker> GetSpeakersAsyncById(int speakerId, bool includeEvents);

    }
}