import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { HttpClient } from '@angular/common/http'

import { UserDataService } from '../../../shared/user-data.service'
import { EventsApiService } from '../shared/events-api.service'
import { ApiService } from '../../../shared/api.service'

const DEBUG = false
const DEFAULT_ERROR_MSG = 'Something went wrong'

@Component({
  selector: 'app-events-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss', '../shared/shared.component.scss']
})
export class EventsListComponent implements OnInit {

  private eventsApiService: EventsApiService
  private apiService: ApiService

  events: Array<any> = []
  myEvents: Array<any> = []

  toastMessage: string
  errorMessage: string
  loggedIn: boolean
  isAdmin: boolean

  constructor (
    private http: HttpClient,
    private router: Router,
    private userDataService: UserDataService
  ) {
    this.eventsApiService = new EventsApiService(http, this, DEBUG)
    this.apiService = new ApiService(http, this, DEBUG)
  }

  ngOnInit (): void {
    this.userDataService.isLoggedInObservable.subscribe(l => {
      this.loggedIn = l
      if (!this.loggedIn) {
        this.errorMessage = ''
        this.toastMessage = ''
        this.myEvents = []
      }
    })
    this.userDataService.isAdminObservable.subscribe(a => this.isAdmin = a)

    if (sessionStorage.getItem('jwt'))
      this.apiService.checkToken(this.updateUserDataService)

    this.eventsApiService.getAllEvents(this.populateAllEvents)
    if (this.loggedIn)
      this.eventsApiService.getMyEvents(this.populateMyEvents)
  }

  updateUserDataService (res: any, _this: any) {
    if (res.body) {
      _this.userDataService.setUsername(res.body['userName'])
      _this.userDataService.setIsLoggedIn(true)
      _this.userDataService.setIsAdmin(res.body['userRoles'].includes('Admin'))
      _this.router.navigate([''])
    }
  }

  populateAllEvents (res: any, _this: any): void {
    if (res.error) _this.errorMessage = res.error.message
    else _this.events = res.body['events']
  }

  populateMyEvents (res: any, _this: any): void {
    if (res.error) _this.errorMessage = res.error.message
    else _this.myEvents = res.body['events'].map((e: any) => e.id)
  }

  attend (event: any): void {
    if (!this.loggedIn) this.router.navigate(['/auth/login'])
    else {
      this.eventsApiService.attendEvent((res: any, _this: any) => {
        if (res.status === 201) {
          this.myEvents.push(event.id)
          this.toastMessage = `Success, you are attending ${event.name}`
        }
        else if (res.error.status === 422) this.toastMessage = `You are already registered to attend ${event.name}`
        else this.errorMessage = DEFAULT_ERROR_MSG
      }, event)
    }
  }

  delete (event: any) {
    console.log(event)
    if (this.isAdmin) {
      this.eventsApiService.deleteEvent((res: any, _this: any) => {
        if (res.status === 200) {
          this.toastMessage = `Deleted event: ${event.name}`
          this.eventsApiService.getAllEvents(this.populateAllEvents)
        }
        else if (res.error.status === 404) this.errorMessage = 'Delete request failed'
        else this.errorMessage = DEFAULT_ERROR_MSG
      }, event)
    }
  }
}
