import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const BASE_URL = "https://localhost:44388/api/product/";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  _productsArray: Array<any> = [];
  _http: HttpClient;

  _produceID: Number = 0;
  _description: String = ''
  _price: Number = 0

  _editableDescription: String = '';
  _editablePrice: Number = 0;

  _errorMessage: string = '';
  _editId: Number = 0;

  _singleProductNumber: number = 0;
  _singleProductName: string = "";
  _singleProductPrice: number = 0;

  _firstName: string = '';
  _lastName: string = '';

  constructor (private http: HttpClient) {
    this._http = http
    this.getAllProducts()
    this.getName()
  }

  getAllProducts () {
    let url = BASE_URL;
    this._http.get<any>(url)
      .subscribe(
        result => this._productsArray = result,
        error => this._errorMessage = JSON.stringify(error)
      )
  }

  getProduct (id: string) {
    let url = BASE_URL + id
    this._http.get<any>(url)
      .subscribe(result => {
        this._singleProductName = result.description;
        this._singleProductNumber = result.produceID;
        this._singleProductPrice = result.price
      },
        error => this._errorMessage = JSON.stringify(error)
      )
  }

  createProduct () {
    this.http.post(BASE_URL, { Description: this._description, Price: this._price })
      .subscribe(
        (data: any) => {
          console.log("POST call successful. Inspect response.", JSON.stringify(data))
          this._errorMessage = JSON.stringify(data)
          this.getAllProducts()
        },
        error => this._errorMessage = JSON.stringify(error)
      )
  }

  deleteProduct (_id: string) {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }

    let url = BASE_URL + _id;
    this.http.delete(url, httpOptions)
      .subscribe(
        (data: any) => {
          this._errorMessage = data["errorMessage"]
          this.getAllProducts()
        },
        error => this._errorMessage = JSON.stringify(error)
      )
  }

  updateProduct () {
    this.http.put(BASE_URL + "MyEdit",
      {
        ProduceID: this._editId,
        Description: this._editableDescription,
        Price: this._editablePrice
      })
      .subscribe(
        (data: any) => {
          console.log("PUT call successful. Inspect response.", JSON.stringify(data));
          this._errorMessage = data["errorMessage"]
          this.getAllProducts()
        },
        error => this._errorMessage = JSON.stringify(error)
      )
  }

  getName () {
    this.http.get<any>(BASE_URL + 'name')
      .subscribe(
        obj => { this._firstName = obj.firstName, this._lastName = obj.lastName },
        err => this._errorMessage = JSON.stringify(err)
      )
  }
}
