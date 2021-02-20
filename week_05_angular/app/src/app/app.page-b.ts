import { Component } from '@angular/core'
import { ActivatedRoute, Params } from '@angular/router'

@Component({
  template: `ID: {{id}}<br/>Name: {{firstName}}`
})
export class PageBComponent {
  id: number = 0
  firstName: string = ''

  // The constructor sets up the class.
  constructor (private route: ActivatedRoute) {
    let str = "This is where the class is initialized.";
    console.log(str)
  }

  // ngOnInit() gets called after the class is set up.
  // At this point, the class is able to handle the parameters passed to it.
  ngOnInit () {
    this.route.params.forEach((params: Params) => {
      let localID = params['id']
      let localName = params['firstname']
      this.id = localID
      this.firstName = localName
    });
  }
}
