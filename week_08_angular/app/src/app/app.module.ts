import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'

import { ChildComponent } from './app.child'
import { FormsModule } from '@angular/forms' // Needed to enable form inputs.

import { HighlightDirective } from './app.highlight.directive' // custom element directive

@NgModule({
  declarations: [
    AppComponent, ChildComponent, HighlightDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
