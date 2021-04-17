import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http'
import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors } from '@angular/forms'

import { UserDataService } from '../../../shared/user-data.service'
import { AuthApiService } from '../shared/auth-api.service'
import { ApiService } from '../../../shared/api.service'

const DEBUG = false;

@Component({
  selector: 'app-auth-register',
  templateUrl: './register.component.html',
  styleUrls: ['../shared/styles.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm = new FormGroup({
    username: new FormControl('', [
      Validators.required,
      Validators.minLength(3),
      Validators.maxLength(30),
      Validators.pattern(/^[a-zA-Z0-9_-]+$/)
    ]),
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    firstName: new FormControl('', [
      Validators.required,
      Validators.maxLength(30),
      Validators.pattern(/^[a-zA-Z]+$/)
    ]),
    lastName: new FormControl('', [
      Validators.required,
      Validators.maxLength(30),
      Validators.pattern(/^[a-zA-Z]+$/)
    ]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(100),
      Validators.pattern(/^[^ ]+$/)
    ]),
    passwordConfirm: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(100),
      Validators.pattern(/^[^ ]+$/)
    ])
  }, { validators: this.comparisonValidator() })

  private authApiService: AuthApiService
  private apiService: ApiService
  registerError = ''
  registerMsg = ''
  verifyLink = ''

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

  comparisonValidator (): ValidatorFn {
    return (group: FormGroup): ValidationErrors => {
      const password = group.controls['password']
      const passwordConfirm = group.controls['passwordConfirm']
      if (password.value && password.value === passwordConfirm.value)
        passwordConfirm.setErrors(null)
      else
        passwordConfirm.setErrors({ mismatch: true })
      return
    }
  }

  get username () { return this.registerForm.get('username') }
  get email () { return this.registerForm.get('email') }
  get firstName () { return this.registerForm.get('firstName') }
  get lastName () { return this.registerForm.get('lastName') }
  get password () { return this.registerForm.get('password') }
  get passwordConfirm () { return this.registerForm.get('passwordConfirm') }

  submit () {
    if (this.password.value != this.passwordConfirm.value) this.registerError = 'Passwords do not match'
    if (this.registerForm.valid && this.password.value === this.passwordConfirm.value)
      this.authApiService.register(this.registerCb, {
        username: this.username.value,
        email: this.email.value,
        firstName: this.firstName.value,
        lastName: this.lastName.value,
        password: this.password.value
      })
  }

  registerCb (result, _this) {
    if (result['confirmUrl']) {
      _this.registerMsg = 'Register Successful'
      _this.verifyLink = result['confirmUrl']
      _this.email.setValue('')
      _this.firstName.reset()
      _this.lastName.reset()
      _this.password.reset()
      _this.passwordConfirm.reset()
    } else {
      _this.registerError = 'Register Failed'
      _this.password.reset()
      _this.passwordConfirm.reset()
    }
  }

  updateUserDataService (result, _this) {
    if (result) {
      _this.userDataService.setUsername(result['userName'])
      _this.userDataService.setIsLoggedIn(true)
      _this.userDataService.setIsAdmin(result['userRoles'].includes('Admin'))
      _this.router.navigate([''])
    }
  }
}
