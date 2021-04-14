import { Lot } from './Lot';
import { SocialNetwork } from './SocialNetwork';
import { Speaker } from './Speaker';

export interface Event {
    id: number;
    local: string;
    date: Date;
    theme: string;
    amountPeople: number;
    imageURL: string;
    telephone: string;
    email: string;
    lots: Lot[];
    socialNetworks: SocialNetwork[];
    speakersEvents: Speaker[];
}
