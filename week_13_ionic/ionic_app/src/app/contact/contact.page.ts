import { Component, OnInit } from '@angular/core'
import { NavController } from '@ionic/angular'

@Component({
  selector: 'app-contact',
  templateUrl: './contact.page.html',
  styleUrls: ['./contact.page.scss']
})
export class ContactPage implements OnInit {
  private icons = [
    'flask',
    'wifi',
    'beer',
    'football',
    'basketball',
    'paper-plane',
    'american-football',
    'boat',
    'bluetooth',
    'build'
  ]
  // Create an array of custom objects.
  public items: Array<{ title: string; note: string; icon: string }> = [];

  constructor (private nav: NavController) {
    for (let i = 0; i < this.icons.length; i++) {
      this.items.push({
        title: 'Item ' + i,
        note: 'This is item #' + i,
        icon: this.icons[i]
      })
    }
  }

  ngOnInit () { }

  private showDetail (_event, idx, item) {
    this.nav.navigateForward(`detail/${idx}`, { state: { item } })
  }
}
