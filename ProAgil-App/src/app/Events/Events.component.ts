import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-Events',
  templateUrl: './Events.component.html',
  styleUrls: ['./Events.component.css']
})
export class EventsComponent implements OnInit {

  events: any;

  constructor(private http: HttpClient) { }

  /* It is initialized before being passed to HTML */
  ngOnInit() {
    this.getEventos();
  }

  getEventos(){
    this.http.get('http://localhost:5000/api/values').subscribe( response => {
      this.events = response;
    }, error => {
      console.log(error);
    });
  }

}
