using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResumeCurriculum { get; set; }
        public string ImageURL {get; set;}
        public string Telephone { get; set; }
        public string Email { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public List<SpeakerEvent> SpeakersEvents { get; set; }
    }
}