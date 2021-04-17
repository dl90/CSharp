import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { HttpClient } from '@angular/common/http'
import { FormGroup, FormControl, Validators } from '@angular/forms'

import { EventsApiService } from '../shared/events-api.service'

const DEBUG = false

@Component({
  selector: 'app-event-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss', '../shared/shared.component.scss']
})
export class EventCreateComponent implements OnInit {

  private eventsApiService: EventsApiService

  errorMessage: string
  toastMessage: string
  createForm = new FormGroup({
    eventName: new FormControl('', [
      Validators.required,
      Validators.maxLength(30)
    ]),
    eventDate: new FormControl('', [
      Validators.required
    ]),
    eventTime: new FormControl('', [
      Validators.required
    ]),
    eventDesc: new FormControl('', [
      Validators.required,
      Validators.maxLength(512)
    ])
  })


  constructor (
    private http: HttpClient,
    private router: Router
  ) {
    this.eventsApiService = new EventsApiService(http, this, DEBUG)
  }

  ngOnInit () { }

  get eventName () { return this.createForm.get('eventName') }
  get eventDate () { return this.createForm.get('eventDate') }
  get eventTime () { return this.createForm.get('eventTime') }
  get eventDesc () { return this.createForm.get('eventDesc') }

  submit () {
    const now = new Date(Date.now())
    const eventDateTime = new Date(`${this.eventDate.value} ${this.eventTime.value}`)

    if (now >= eventDateTime) this.errorMessage = 'Event date and time must be in the future'
    else {
      this.errorMessage = ''
      const payload = {
        DateTime: eventDateTime.toISOString(),
        Name: this.eventName.value,
        Description: this.eventDesc.value
      }

      this.eventsApiService.createEvent((res: any, _this: any) => {
        console.log(res)
        if (res.status === 201) {
          this.toastMessage = 'Success, event created'
          this.eventName.reset()
          this.eventDate.reset()
          this.eventTime.reset()
          this.eventDesc.reset()
        }
        else if (res.error.status === 422) this.errorMessage = 'Failed to create event'
        else this.errorMessage = 'Something went wrong'
      }, payload)
    }
  }
}