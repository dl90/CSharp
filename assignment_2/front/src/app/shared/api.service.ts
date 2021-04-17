import { HttpClient, HttpHeaders } from '@angular/common/http'

export const API_URL = 'https://localhost:5001/api'
export const TOKEN_KEY = 'jwt'
export const getSecureHeader = () => {
  const token = sessionStorage.getItem(TOKEN_KEY)
  return new HttpHeaders({
    'Content-Type': 'application/json; charset=utf-8',
    'Authorization': 'Bearer ' + token
  })
}

export class ApiService {

  protected http: HttpClient
  protected ref: any
  protected debug: boolean

  constructor (http: HttpClient, ref: any, debug = false) {
    this.http = http
    this.ref = ref
    this.debug = debug
  }

  logout (cb: Function): void {
    this.http.post(API_URL + '/auth/logout', {}, { observe: 'response' })
      .subscribe(res => {
        if (this.debug) console.log(res)
        cb(res, this.ref)
      }, err => {
        if (this.debug) console.log(err)
        cb(false, this.ref)
      })
  }

  checkToken (cb: Function): void {
    const headers = getSecureHeader()
    this.http.get(API_URL + '/auth/token', { headers })
      .subscribe(
        res => {
          if (this.debug) console.log(res)
          cb(res, this.ref)
        },
        err => {
          if (this.debug) console.log(err);
          cb(false, this.ref)
        }
      )
  }


  getReq (uri: string, cb: Function): void {
    const headers = getSecureHeader()
    this.http.get<any>(API_URL + uri, { headers, observe: 'response' })
      .subscribe(
        res => {
          if (this.debug) console.log(res)
          cb(res, this.ref)
        },
        error => {
          if (this.debug) console.log(error);
          cb({ error }, this.ref)
        }
      )
  }

  postReq (uri: string, payload: any, cb: Function): void {
    const headers = getSecureHeader()
    this.http.post(API_URL + uri, payload, { headers, observe: 'response' })
      .subscribe(
        res => {
          if (this.debug) console.log(res, this.ref)
          cb(res, this.ref)
        },
        error => {
          if (this.debug) console.log(error);
          cb({ error }, this.ref)
        }
      )
  }

  patchReq (uri: string, payload: any, cb: Function): void {
    const headers = getSecureHeader()
    this.http.patch(API_URL + uri, payload, { headers, observe: 'response' })
      .subscribe(
        res => {
          if (this.debug) console.log(res)
          cb(res, this.ref)
        },
        error => {
          if (this.debug) console.log(error)
          cb({ error }, this.ref)
        }
      )
  }

  deleteReq (uri: string, cb: Function): void {
    const headers = getSecureHeader()
    this.http.delete(API_URL + uri, { headers, observe: 'response' })
      .subscribe(
        res => {
          if (this.debug) console.log(res)
          cb(res, this.ref)
        },
        error => {
          if (this.debug) console.log(error)
          cb({ error }, this.ref)
        }
      )
  }

}
