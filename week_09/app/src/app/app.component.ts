import { Component } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { ApiService } from './api.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public site = 'https://localhost:5001/api/login'

  username = 'don@test.com'
  password = 'Test!123'
  _currentUser = ''

  token = ''
  message = 'Not logged in.'

  _apiService: ApiService
  secureData = ''

  managerData = ''
  reqInfo = null
  msgFromServer = ''

  techArray = null

  num_1 = 0
  num_2 = 0
  sum = 0

  constructor (private http: HttpClient) {
    // Pass in http module and pointer to AppComponent.
    this.showContentIfLoggedIn()
    this._apiService = new ApiService(http, this)
  }

  //------------------------------------------------------------
  // Either shows content when logged in or clears contents.
  //------------------------------------------------------------
  showContentIfLoggedIn () {
    // Logged in if token exists in browser cache.
    if (sessionStorage.getItem('auth_token') != null) {
      this.token = sessionStorage.getItem('auth_token')
      this.message = "The user has been logged in."
    }
    else {
      this.message = "Not logged in."
      this.token = ''
    }
  }

  //------------------------------------------------------------
  // Log user in.
  //------------------------------------------------------------
  login () {
    let url = this.site

    // This free online service receives post submissions.
    this.http.post(url, {
      Email: this.username,
      Password: this.password,
      RememberMe: false
    })
      .subscribe(
        // Data is received from the post request.
        (data) => {
          // Inspect the data to know how to parse it.
          // console.log(JSON.stringify(data))

          if (data["tokenString"] != null) {
            this._currentUser = data['currentUser']
            this.token = data["tokenString"]
            sessionStorage.setItem('auth_token', data["tokenString"])
            sessionStorage.setItem('firstName', data['currentUser'])
            this.message = "The user has been logged in."
          }
        },
        // An error occurred. Data is not received.
        error => alert(JSON.stringify(error))
      )
  }

  //------------------------------------------------------------
  // Log user out. Destroy token.
  //------------------------------------------------------------
  logout () {
    sessionStorage.clear()
    this.showContentIfLoggedIn()

    // Clear data.
    this.username = ""
    this.password = ""
    this.token = ''
    this.message = 'Not logged in.'
    this.secureData = ''

    this.managerData = ''
    this.reqInfo = null
    this.msgFromServer = ''

    this.techArray = null

    this.num_1 = 0
    this.num_2 = 0
    this.sum = 0
  }

  getSecureData () {
    var url = this.site + '/list'

    // Passing in the reference to the callback function.
    this._apiService.getData(url, this.secureDataCallback)
  }

  // Callback needs a pointer '_this' to current instance.
  secureDataCallback (result, _this) {
    if (result.errorMessage == "") {
      _this.secureData = JSON.stringify(result)
      _this.techArray = result.techArray
    }
    else alert(JSON.stringify(result.errorMessage))
  }

  postSecureMessage () {
    const url = this.site + '/SecurePostArea'
    let dataObject = { msgFromClient: 'hi from client' }
    this._apiService.postData(url, dataObject, this.securePostCallback);
  }

  postNumber () {
    const url = this.site + '/custom'
    const body = { num_1: this.num_1, num_2: this.num_2 }
    this._apiService.postData(url, body, (result, _this) => {
      if (result.errorMessage === '') _this.sum = result.sum
      else this.message = result.errorMessage
    });
  }

  // Callback needs a pointer '_this' to current instance.
  securePostCallback (result, _this) {
    if (result.errorMessage == '') _this.msgFromServer = result['msgFromServer']
    else alert(JSON.stringify(result.errorMessage))
  }
}
