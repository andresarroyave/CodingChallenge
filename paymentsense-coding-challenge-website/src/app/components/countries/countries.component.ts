import { Component, OnInit, ViewChild } from '@angular/core';
import { CountryService } from 'src/app/services';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { MatPaginator, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})
export class CountriesComponent implements OnInit {

  private countries: MatTableDataSource<Country>;
  private columnsToDisplay = ['name', 'flag'];

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private countryService: CountryService) { }

  ngOnInit() {
    this.countryService.getAll().subscribe(countryList => {
      this.countries = new MatTableDataSource(countryList);
      this.countries.paginator = this.paginator;
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.countries.filter = filterValue.trim().toLowerCase();

    if (this.countries.paginator) {
      this.countries.paginator.firstPage();
    }
  }
}
