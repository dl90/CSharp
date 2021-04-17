import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EventsListComponent } from './module/events/list/list.component'
import { RegisterComponent } from './module/auth/register/register.component'
import { LoginComponent } from './module/auth/login/login.component'
import { MyEventsComponent } from './module/events/my-events/my-events.component'
import { EventCreateComponent } from './module/events/create/create.component'
import { EventAttendeesComponent } from './module/events/attendees/attendees.component'


import { PageDefault } from './app-page-defaults'

const routes: Routes = [
  { path: '', redirectTo: 'events/all', pathMatch: 'full' },
  {
    path: 'auth', children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent }
    ]
  },
  {
    path: 'events', children: [
      { path: 'all', component: EventsListComponent },
      { path: 'create', component: EventCreateComponent },
      { path: 'my', component: MyEventsComponent },
      { path: 'attendees/:id', component: EventAttendeesComponent }
    ]
  },
  { path: '**', component: PageDefault }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
