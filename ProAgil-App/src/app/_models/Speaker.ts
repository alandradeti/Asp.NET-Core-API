import { SocialNetwork } from './SocialNetwork';
import { Event } from './Event';

export interface Speaker {
    id: number; 
    name: string; 
    resumeCurriculum: string;
    imageURL: string;
    telephone: string;
    email: string;
    socialNetworks: SocialNetwork[];
    speakersEvents: Event[];
}
