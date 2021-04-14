using System;
using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Event
    {
        public int Id  { get; set; }
        public string Local { get; set; }
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public int AmountPeople { get; set; }
        public string ImageURL {get; set;}
        public string Telephone { get; set; }
        public string Email { get; set; }
        public List<Lot> Lots { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public List<SpeakerEvent> SpeakersEvents { get; set; }
    }
}