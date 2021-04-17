import { HttpClient } from '@angular/common/http'
import { API_URL, ApiService, getSecureHeader } from '../../../shared/api.service'

export class EventsApiService extends ApiService {

  protected http: HttpClient
  protected ref: any
  protected debug: boolean

  constructor (http: HttpClient, ref: any, debug = false) {
    super(http, ref, debug)
    this.http = http
    this.ref = ref
    this.debug = debug
  }

  /**
   * @returns
   * ```
   *  // GET https://localhost:5001/api/event
   *  res = {
   *    events: [
   *      {
   *        id: 1,
   *        name: "Test Event",
   *        attendees: null,
   *        dateTime: "2013-10-07T08:23:19.111",
   *        description: "This is a test event",
   *      }
   *    ]
   *  }
   * ```
   */
  getAllEvents (cb: Function): void {
    super.getReq('/event', (res: any, ref: any) => cb(res, ref))
  }

  /**
   * @returns
   * ```
   * {
   *    "events": [
   *      {
   *        "id": 1,
   *        "name": "Test Event",
   *        "dateTime": "2013-10-07T08:23:19.111",
   *        "description": "This is a test event"
   *      },
   *      {
   *        "id": 2,
   *        "name": "Test Event 1",
   *        "dateTime": "2013-10-07T08:23:19.111",
   *        "description": "This is a test event"
   *      }
   *    ]
   * }
   * ```
   */
  getMyEvents (cb: Function): void {
    super.getReq('/event/mine', (res: any, ref: any) => cb(res, ref))
  }

  /**
   * @returns
   * ```
   * {
   *   "e": {
   *     "id": 5,
   *     "name": "A",
   *     "dateTime": "2021-04-18T03:00:00",
   *     "description": "A event",
   *     "attendees": null
   *   },
   *   "users": [
   *     {
   *       "userName": "test1",
   *       "firstName": "Jane",
   *       "lastName": "Doe"
   *     }
   *   ]
   * }
   * ```
   */
  getAttendees (cb: Function, id: number | string): void {
    super.getReq(`/event/${id}`, (res: any, ref: any) => cb(res, ref))
  }

  attendEvent (cb: Function, { id }): void {
    super.postReq(`/event/${id}/attend`, {}, (res: any, ref: any) => cb(res, ref))
  }

  notAttendEvent (cb: Function, { id }): void {
    super.deleteReq(`/event/${id}/attend`, (res: any, ref: any) => cb(res, ref))
  }

  createEvent (cb: Function, payload: any): void {
    super.postReq('/event', payload, (res: any, ref: any) => cb(res, ref))
  }

  deleteEvent (cb: Function, { id }): void {
    super.deleteReq(`/event/${id}`, (res: any, ref: any) => cb(res, ref))
  }

}