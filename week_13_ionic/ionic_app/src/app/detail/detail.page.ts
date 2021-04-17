import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NavParams } from '@ionic/angular';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.page.html',
  styleUrls: ['./detail.page.scss'],
  providers: [NavParams]
})
export class DetailPage implements OnInit {
  id: string
  item: any

  constructor (private route: ActivatedRoute, private router: Router) {
    this.route.queryParams.subscribe(_p => {
      const navParams = this.router.getCurrentNavigation().extras.state
      if (navParams) this.item = navParams.item
    })
  }

  // Ionic tab pages are initialized in the constructor only once.
  // ionViewWillEnter() is called every time the tab page is viewed.
  ionViewWillEnter () {
    this.id = this.route.snapshot.paramMap.get('id')
    // console.log(this.item)
  }

  ngOnInit () { }
}
