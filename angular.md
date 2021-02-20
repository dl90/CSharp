# Angular

1. [modules](https://angular.io/guide/architecture-modules):
    collection of related components or services, modular, can import/export, root module, children modules
1. components: class, encapsulates data/logic for view
1. directives: component containing custom content and behavior, built-in or custom
1. model: holds/transfers data across view and component

```js
// src/app/app.component.ts => application root component
import { Component } from '@angular/core'

// decorator identifies class immediately following as a component
@Component({
  selector: 'app-root', // html element id to attach
  templateUrl: './app.component.html', // or template
  styleUrls: ['./app.component.css']
})

// data/functions of the component, aka 'Model'
export class AppComponent {
  title = 'This is Angular'
}
```
