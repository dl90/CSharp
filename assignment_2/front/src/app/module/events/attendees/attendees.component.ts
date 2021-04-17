import { Component, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'
import { HttpClient } from '@angular/common/http'

import { EventsApiService } from '../shared/events-api.service'

const DEBUG = false

@Component({
  selector: 'app-event-attendees',
  templateUrl: './attendees.component.html',
  styleUrls: ['./attendees.component.scss', '../shared/shared.component.scss']
})
export class EventAttendeesComponent implements OnInit {

  private eventsApiService: EventsApiService
  errorMessage: string
  users: Array<any> = []
  event: any

  constructor (
    private http: HttpClient,
    private route: ActivatedRoute,
  ) {
    this.eventsApiService = new EventsApiService(http, this, DEBUG)
  }

  ngOnInit (): void {
    const id = Number(this.route.snapshot.paramMap.get('id'))
    this.eventsApiService.getAttendees(this.populate, id)
  }

  populate (res: any, _this: any): void {
    if (res.error) _this.errorMessage = res.error.message
    else {
      _this.users = res.body['users']
      _this.event = res.body['e']
    }
  }
}