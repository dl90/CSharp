import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { AppRoutingModule } from '../../app-routing.module'

import { UserDataService } from '../../shared/user-data.service'

import { EventsListComponent } from './list/list.component'
import { MyEventsComponent } from './my-events/my-events.component'
import { EventCreateComponent } from './create/create.component'
import { EventAttendeesComponent } from './attendees/attendees.component'

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  declarations: [
    EventsListComponent,
    MyEventsComponent,
    EventCreateComponent,
    EventAttendeesComponent
  ],
  exports: [],
  providers: [UserDataService]
})
export class EventsModule { }