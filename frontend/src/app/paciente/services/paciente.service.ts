import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take, delay, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { PacienteViewModel } from '../models/pacienteviewmodel.model';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {

  public pacientesApi = `${environment.apiUrl}/v1/pacientes`;

  constructor(private http: HttpClient) { }

  getPacientes() {
    return this.http.get<PacienteViewModel[]>(`${this.pacientesApi}`).pipe(
    );
  }
}
