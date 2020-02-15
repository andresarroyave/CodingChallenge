import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CountriesComponent } from './components';
import { CountryComponent } from './components/country/country.component';

const routes: Routes = [
  { path: '',   component: CountriesComponent },
  { path: 'country/:countryName',   component: CountryComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }