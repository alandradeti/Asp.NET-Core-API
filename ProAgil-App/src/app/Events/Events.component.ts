import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventService } from '../_services/event.service';
import { Event } from '../_models/Event';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-events',
  templateUrl: './Events.component.html',
  styleUrls: ['./Events.component.css'],
})
export class EventsComponent implements OnInit {

  /*---------- Definition of variables ----------*/
  // Events
  filteredEvents: Event[];
  events: Event[];

  // Image
  imageWidth = 50;
  imageMargin = 2;
  showImage = false;

  // Modal
  modalRef: BsModalRef;

  /*---------- Definition of properties ----------*/
  // Filter
  _filterList: string;

  constructor(
    private eventService: EventService,
    private modalService: BsModalService
    ) {}

  /*---------- Definition of methods----------*/
  // Perform the filters
  get filterList(): string{
    return this._filterList;
  }
  set filterList(value: string){
    this._filterList = value;
    this.filteredEvents = this.filterList ? this.filterEvents(this.filterList) : this.events;
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  // It is initialized before being passed to HTML
  ngOnInit() {
    this.getEventos();
  }

  filterEvents(filterBy: string): Event[]{
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      event => event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  // Method to show images or hide
  switchImage(){
    this.showImage = !this.showImage;
  }

  // Method that retrieves the event data in the API
  getEventos(){
    this.eventService.getAllEvents().subscribe(
      (_events: Event[]) => {
      this.events = _events;
      this.filteredEvents = this.events;
      console.log(_events);
    }, error => {
      console.log(error);
    });
  }

}
