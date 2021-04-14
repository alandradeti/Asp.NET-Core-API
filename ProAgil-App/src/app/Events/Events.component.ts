import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventService } from '../_services/event.service';
import { Event } from '../_models/Event';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale} from 'ngx-bootstrap/chronos';
import { ptBrLocale} from 'ngx-bootstrap/locale';
defineLocale('pt-br', ptBrLocale);

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
  event: Event;

  // Image
  imageWidth = 50;
  imageMargin = 2;
  showImage = false;

  // Form
  registerForm: FormGroup;

  /*---------- Definition of properties ----------*/
  // Filter
  _filterList: string;

  constructor(
    private eventService: EventService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private localeService: BsLocaleService
    ) {
      this.localeService.use('pt-br');
    }

  /*---------- Definition of methods----------*/
  // Perform the filters
  get filterList(): string{
    return this._filterList;
  }
  set filterList(value: string){
    this._filterList = value;
    this.filteredEvents = this.filterList ? this.filterEvents(this.filterList) : this.events;
  }

  openModal(modalEdit: any){
    this.registerForm.reset();
    modalEdit.show();
  }

  // It is initialized before being passed to HTML
  ngOnInit() {
    this.validation();
    this.getEvents();
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

  validation(){
    this.registerForm = this.fb.group({
        theme: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        local: ['', Validators.required],
        date: ['', Validators.required],
        amountPeople: ['', [Validators.required, Validators.max(120000)]],
        imageURL: ['', Validators.required],
        telephone: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]]
    });
  }

  saveChanges(modalEdit: any){
    if (this.registerForm.valid) {
      this.event = Object.assign({}, this.registerForm.value);
      console.log(this.event);
      this.eventService.postEvent(this.event).subscribe(
        (newEvent: Event) => {
          console.log(newEvent);
          modalEdit.hide();
          this.getEvents();
        }, error => {
          console.log(error);
        }
      );
    }
  }

  // Method that retrieves the event data in the API
  getEvents(){
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
