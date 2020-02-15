import { Component, OnInit } from '@angular/core';
import { CountryService } from 'src/app/services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss']
})
export class CountryComponent implements OnInit {

  private country: Country;
  private languageColumnsToDisplay = ['name', 'nativeName'];
  private curerncyColumnsToDisplay = ['code', 'name', 'symbol'];
  private regionalBlocsColumnsToDisplay = ['acronym', 'name'];

  constructor(
    private countryService: CountryService, 
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      let countryName = params.get('countryName');
      
      this.countryService.getByName(countryName).subscribe(country => {
        this.country = country;
      });
    });
  }

}
