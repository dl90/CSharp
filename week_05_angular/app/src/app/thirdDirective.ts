import { Component, Input } from '@angular/core'

@Component({
  selector: 'third-directive',
  template: `<h3>hello from the third directive<h3> {{eg}}`
})

export class ThirdDirective {
  @Input() eg = ''
 }
