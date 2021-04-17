import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http'
import { FormGroup, FormControl, Validators } from '@angular/forms'

import { UserDataService } from '../../../shared/user-data.service'
import { AuthApiService } from '../shared/auth-api.service'
import { ApiService } from '../../../shared/api.service'

const DEBUG = false

@Component({
  selector: 'app-auth-login',
  templateUrl: './login.component.html',
  styleUrls: ['../shared/styles.component.scss']
})
export class LoginComponent implements OnInit {

  private authApiService: AuthApiService
  private apiService: ApiService

  loginError: string
  loginForm = new FormGroup({
    username: new FormControl('', [
      Validators.required,
      Validators.minLength(3),
      Validators.maxLength(30),
      Validators.pattern(/^[a-zA-Z0-9_-]+$/)
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(100),
      Validators.pattern(/^[^ ]+$/)
    ])
  })

  constructor (
    private http: HttpClient,
    private router: Router,
    private userDataService: UserDataService
  ) {
    this.authApiService = new AuthApiService(http, this, DEBUG)
    this.apiService = new ApiService(http, this, DEBUG)
  }

  ngOnInit () {
    if (sessionStorage.getItem('jwt'))
      this.apiService.checkToken(this.updateUserDataService)
  }

  get username () { return this.loginForm.get('username') }
  get password () { return this.loginForm.get('password') }

  submit () {
    if (this.loginForm.valid)
      this.authApiService.login(this.updateUserDataService, {
        username: this.username.value,
        password: this.password.value,
      })
  }

  updateUserDataService (result: any, _this: any) {
    if (result.body) {
      _this.userDataService.setUsername(result.body['userName'])
      _this.userDataService.setIsLoggedIn(true)
      _this.userDataService.setIsAdmin(result.body['userRoles'].includes('Admin'))
      _this.router.navigate([''])
    }
  }
}
