import { HttpClient } from '@angular/common/http'
import { ApiService, TOKEN_KEY } from '../../../shared/api.service'

export class AuthApiService extends ApiService {

  protected http: HttpClient
  protected ref: any
  protected debug: boolean

  constructor (http: HttpClient, ref: any, debug = false) {
    super(http, ref, debug)
    this.http = http
    this.ref = ref
    this.debug = debug
  }

  login (cb: Function, { username, password, rememberMe = false }: {
    username: string, password: string, rememberMe?: boolean
  }): void {

    super.postReq('/auth/login', {
      UserName: username,
      Password: password,
      RememberMe: rememberMe
    }, (res: any, ref: any) => {
      if (res.error || !res) cb(false, ref)
      else {
        sessionStorage.setItem(TOKEN_KEY, res.body.token)
        cb(res, ref)
      }
    })
  }

  register (cb: Function, { username, email, password, firstName, lastName }: {
    username: string, email: string, password: string, firstName: string, lastName: string
  }): void {

    super.postReq('/register', {
      UserName: username,
      Email: email,
      FirstName: firstName,
      LastName: lastName,
      Password: password,
      ConfirmPassword: password
    }, (res: any, ref: any) => {
      if (res.error || !res) cb(false, ref)
      else cb(res, ref)
    })
  }
}
