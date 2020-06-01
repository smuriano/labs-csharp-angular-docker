import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take, delay, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { Medico } from '../models/medico.model';

@Injectable({
  providedIn: 'root'
})
export class MedicoService {

  public medicosApi = `${environment.apiUrl}/v1/medicos`;

  constructor(private http: HttpClient) { }

  getMedicos() {
    return this.http.get<Medico[]>(`${this.medicosApi}`).pipe(
      delay(800), // Simular uma demora no retorno da API
      tap((res: any) => console.log('getMedicos:', res))
    );
  }
}
