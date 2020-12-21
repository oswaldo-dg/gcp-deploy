import { environment } from './../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
  })
export class DemoService {
  constructor(private http: HttpClient) { }

  // Obtiene los datos
  public getData(url: string): Observable<unknown[]>{
    console.log(url);
    return this.http.get<unknown[]>(url);
  }

}