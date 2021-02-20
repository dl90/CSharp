import { Component } from '@angular/core'
import { MyDataService } from './sample.service'
import { TempService } from './temp.service'

@Component({
  selector: 'app-root',
  template: `<h1>Hello world!  {{title}}</h1>
               <ul><li *ngFor="let name of names">{{name}}</li></ul>
               <div>{{don}}</div>
               <div>{{temp}}</div>
               `,
  providers: [MyDataService, TempService]
})
export class AppComponent {
  public title = 'This is Angular!'
  names: Array<any>
  don: string
  temp: number

  constructor (myDataService: MyDataService, tempService: TempService) {
    this.names = myDataService.getNames()
    this.don = myDataService.getDon()
    this.temp = tempService.CtoF(6)
  }
}
