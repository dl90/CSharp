import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { HttpClient } from '@angular/common/http'

import { UserDataService } from '../user-data.service'
import { ApiService } from '../api.service'

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  username: string
  loggedIn: boolean
  isAdmin: boolean
  private apiService: ApiService

  constructor (
    private http: HttpClient,
    private router: Router,
    private userDataService: UserDataService
  ) {
    this.apiService = new ApiService(http, this)
  }

  ngOnInit () {
    this.userDataService.usernameObservable.subscribe(u => this.username = u)
    this.userDataService.isLoggedInObservable.subscribe(l => this.loggedIn = l)
    this.userDataService.isAdminObservable.subscribe(a => this.isAdmin = a)

    if (sessionStorage.getItem('jwt'))
      this.apiService.checkToken((res, _this) => {
        _this.userDataService.setUsername(res['userName'])
        _this.userDataService.setIsLoggedIn(true)
        _this.userDataService.setIsAdmin(res['userRoles'].includes('Admin'))
      })
  }

  logout (): void {
    this.apiService.logout((res: any, _this: any) => {
      if (res && res.status == 200) {
        _this.userDataService.logout()
        sessionStorage.removeItem('jwt')
        this.router.navigate([''])
      }
    })
  }

}
