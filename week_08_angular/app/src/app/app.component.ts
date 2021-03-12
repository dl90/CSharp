import { Component } from '@angular/core'
import { MyDataService } from '../data/myDataService'
import { TempService } from '../data/tempService'

@Component({
  selector: 'app-root',
  template: `
  <h1>Hello world!  {{title}}</h1>
  <ul><li *ngFor="let name of names">{{name}}</li></ul>
  {{myName}}
  {{temp}}
  <hr>
  <h3>Please enter the customer informatino:</h3>
  <child [callParent]="parentFuncRef" [region]="'BC'"></child>
  {{dataFromChild}}
  <hr>
  <input type="submit" value="my button" (mouseenter)="myMouseEnter($event)" (mouseleave)="myMouseLeave($event)">
  <br>
  {{msg}}
  <hr>
  <input type='text' (keydown)="myKeyDown($event)" (keyup)="myKeyUp($event)">
  {{key}}
  <div (mousedown)="myMouseHandler($event, 'mouse down')"
    (mouseup)="myMouseHandler($event, 'mouse up')"
    (mousemove)="myMouseHandler($event, 'mouse moved')" >
    This area has<br />
    mouse-down<br />
    and<br />
    mouse-up<br />
    enabled.
  </div>
  <p [myHighlight]="''">Highlight me!</p>
  <p [myHighlight]="'violet'">Highlight me too!</p>
  <p [myHighlight]="'green'">Highlight me too!</p>
  <hr>
  <label [class.danger]="foodWarning">Has food allergy.</label>
  <input type="checkbox" [(ngModel)]="foodWarning" />
  <br>
  <label [class.green]="greenToggle">Make me green</label>
  <input type="checkbox" [(ngModel)]="greenToggle" />
  <hr>

  <input type="checkbox" [(ngModel)]="doesNotExercise" (change)="adjustCSS()"/>Does not exercise.
  <input type="checkbox" [(ngModel)]="over55" (change)="adjustCSS()"/>Is over 55.
  <div *ngIf="doesNotExercise || over55" [ngClass]="myClasses" >Is at risk of heart disease.</div>
  <hr>

  <p [style.font-weight]="myWeight" [style.color]="blue">style binding example</p>
  `,
  styles: [`
    .green { color:green; }

    .warning { font-weight:bold; }
    .danger { color:red; }
    `
  ],
  // 'providers' allows you to create and pass an instance of the class to the constructor
  providers: [MyDataService, TempService]
})

export class AppComponent {
  title = 'This is Angular!'
  names: Array<any>
  myName = ''
  temp = 0

  parentFuncRef: Function = this.myCallBackFunction.bind(this);
  dataFromChild = ''

  msg = ''
  key = ''

  foodWarning = false
  greenToggle = false

  doesNotExercise = false;
  over55 = false;

  myClasses = {
    warning: false,
    danger: false
  }

  adjustCSS () {
    this.doesNotExercise && this.over55
      ? this.myClasses.warning = this.myClasses.danger = true
      : this.myClasses.warning = this.myClasses.danger = false
  }

  myWeight = "bold"
  blue = "blue"

  // Create instance of 'MyDataService' right in the constructor
  constructor (myDataService: MyDataService, tempService: TempService) {
    this.names = myDataService.getNames()
    this.myName = myDataService.myName()
    this.temp = tempService.toF(6)
  }

  // This function is called by the Angular framework after the constructor executes.
  public ngOnInit () { }

  // This function can be called by child.
  public myCallBackFunction (streetAddress = "", city = "", region = '') {
    this.dataFromChild = 'Street Address: ' + streetAddress + ' City: ' + city + ' Region: ' + region
  }

  public myMouseEnter (e: any) { console.log(e); this.msg = 'entered' }
  public myMouseLeave (e: any) { console.log(e); this.msg = 'left' }
  public myKeyDown (e: any) { console.log(e); console.log(e.key) }
  public myKeyUp (e: any) { this.key = e.key }
  public myMouseHandler (event: MouseEvent, description = "") {
    console.log(description + " X: " + event.screenX.toString() + " Y:" + event.screenY.toString())
  }
  public myMouseMoveHandler (e: MouseEvent) { console.log(e) }
}
