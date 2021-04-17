import { Injectable } from '@angular/core'
import { BehaviorSubject } from 'rxjs'

@Injectable()
export class UserDataService {
  private username = new BehaviorSubject('')
  private isLoggedIn = new BehaviorSubject(false)
  private isAdmin = new BehaviorSubject(false)

  usernameObservable = this.username.asObservable()
  isLoggedInObservable = this.isLoggedIn.asObservable()
  isAdminObservable = this.isAdmin.asObservable()

  /*
    using observables with injected service

    ngOnInit () {
      this.userDataService.usernameObservable.subscribe(u => this.username = u)
    }
  */

  constructor () { }

  setUsername (username: string) {
    if (username && username.trim().length > 3)
      this.username.next(username)
  }

  setIsLoggedIn (state: boolean) {
    this.isLoggedIn.next(state)
  }

  setIsAdmin (state: boolean) {
    this.isAdmin.next(state)
  }

  logout () {
    this.username.next('')
    this.isLoggedIn.next(false)
    this.isAdmin.next(false)
  }
}
