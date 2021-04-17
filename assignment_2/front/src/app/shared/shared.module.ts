import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { RouterModule } from '@angular/router';

import { NavComponent } from './nav/nav.component'
import { UserDataService } from './user-data.service'

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [NavComponent],
  exports: [NavComponent],
  providers: [UserDataService]
})
export class SharedModule { }