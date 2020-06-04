import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take, delay, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { MedicoViewModel } from '../models/medicoviewmodel.model';

@Injectable({
  providedIn: 'root'
})
export class MedicoService {

  public medicosApi = `${environment.apiUrl}/v1/medicos`;

  constructor(private http: HttpClient) { }

  getMedicos() {
    return this.http.get<MedicoViewModel[]>(`${this.medicosApi}`).pipe(
    );
  }
}
