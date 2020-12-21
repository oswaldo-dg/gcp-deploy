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
  public getData(): Observable<unknown[]>{
    return this.http.get<unknown[]>(environment.url);
  }

}