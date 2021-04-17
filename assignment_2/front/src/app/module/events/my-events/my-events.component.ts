import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { HttpClient } from '@angular/common/http'

import { UserDataService } from '../../../shared/user-data.service'
import { EventsApiService } from '../shared/events-api.service'

const DEBUG = false

@Component({
  selector: 'app-my-events',
  templateUrl: './my-events.component.html',
  styleUrls: ['./my-events.component.scss', '../shared/shared.component.scss']
})
export class MyEventsComponent implements OnInit {

  private eventsApiService: EventsApiService
  myEvents: Array<any> = []
  toastMessage: string
  errorMessage: string

  constructor (
    private http: HttpClient,
    private router: Router,
    private userDataService: UserDataService
  ) {
    this.userDataService.isLoggedInObservable.subscribe(l => {
      if (!l) {
        this.errorMessage = ''
        this.toastMessage = ''
      }
    })
    this.eventsApiService = new EventsApiService(http, this, DEBUG)
  }

  ngOnInit (): void {
    this.eventsApiService.getMyEvents(this.populate)
  }

  populate (res: any, _this: any): void {
    if (res.error) _this.errorMessage = res.error.message
    else _this.myEvents = res.body['events']
  }

  notAttend (event: any): void {
    this.eventsApiService.notAttendEvent((res: any, _this: any) => {
      if (res.status === 201) {
        this.eventsApiService.getMyEvents(this.populate)
        this.toastMessage = `Success, you are no longer attending ${event.name}`
      }
      else if (res.error.status === 422) this.toastMessage = `Unable to processes request${event.name}`
      else this.errorMessage = 'Something went wrong'
    }, event)
  }
}
