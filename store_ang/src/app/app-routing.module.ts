import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CategoryListComponent } from './entities/category/category-list/category-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'Home',pathMatch: 'full'},
  { path: 'home', component: HomeComponent},
  { path: 'categories', component: CategoryListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
