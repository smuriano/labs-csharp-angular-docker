import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take, delay, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { Exame } from '../models/exame.model';

@Injectable({
  providedIn: 'root'
})
export class ExameService {

  public examesApi = `${environment.apiUrl}/v1/exames`;

  constructor(private http: HttpClient) { }

  getExames() {
    return this.http.get<Exame[]>(`${this.examesApi}`).pipe(
    );
  }
}
