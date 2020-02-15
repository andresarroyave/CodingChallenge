import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  constructor(private httpClient: HttpClient) {}

  public getAll(): Observable<Country[]> {
    return this.httpClient.get<Country[]>('https://localhost:44341/PaymentsenseCodingChallenge');
  }
  
  public getByName(name: string): Observable<Country> {
    return this.httpClient.get<Country>('https://localhost:44341/PaymentsenseCodingChallenge/' + name);
  }
}
