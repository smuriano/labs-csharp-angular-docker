import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take, delay, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { Paciente } from '../models/paciente.model';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {

  public pacientesApi = `${environment.apiUrl}/v1/pacientes`;

  constructor(private http: HttpClient) { }

  getPacientes() {
    return this.http.get<Paciente[]>(`${this.pacientesApi}`).pipe(
      delay(800), // Simular uma demora no retorno da API
      tap((res: any) => console.log('getPacientes:', res))
    );
  }
}
