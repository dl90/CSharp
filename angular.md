# Angular

1. [modules](https://angular.io/guide/architecture-modules):
    collection of related components or services, modular, can import/export, root module (xyz.module.ts), children modules
1. components: class, encapsulates data/logic for view, can also import services
1. directives: component containing custom content and behavior, built-in or custom
1. model: holds/transfers data across view and component

```ts
// module
import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { AppComponent } from './app.component'


@NgModule({
  declarations: [ // components
    AppComponent
  ],
  imports: [ // modules, libraries
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent] // only in main module to declare main (entry) component
})
export class AppModule { }
```

```ts
// component (/app.component.ts => application root component)
import { Component } from '@angular/core'

// decorator identifies class immediately following as a component
@Component({
  selector: 'app-root', // html element id to attach
  templateUrl: './app.component.html', // or template
  styleUrls: ['./app.component.css'],
  providers: [] // provides instantiation of imported classes to the constructor (AppComponent)
})

// data/functions of the component, aka 'Model'
export class AppComponent {
  title = 'This is Angular'
}
```
