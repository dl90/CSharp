import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageAComponent }        from './app.page-a';
import { PageBComponent }        from './app.page-b';
import { PageDefault }           from './app.page-default';

const routes: Routes = [
  { path: 'page-a', component: PageAComponent },
  { path: 'page-b/:id/:firstname', component: PageBComponent },
  { path: '', redirectTo: '/page-a', pathMatch: 'full' },
  { path: '**', component: PageDefault }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
