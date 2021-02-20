import { Component, Input } from '@angular/core'

@Component({
  selector: 'second-directive',
  template: `<h3>This is the second directive! {{firstName}}</h3><third-directive [eg]="example" ></third-directive>`
})

export class NewDirective {
  @Input() firstName: string = ''
  example = 'test'
 }
