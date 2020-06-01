import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take, delay, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { OrdemServicoList } from './../models/ordemservico.list.model';

@Injectable({
  providedIn: 'root'
})
export class OrdemServicoService {

  public ordensApi = `${environment.apiUrl}/v1/ordens`;

  constructor(private http: HttpClient) { }

  getOrdens() {
    return this.http.get<OrdemServicoList[]>(`${this.ordensApi}`).pipe(
      delay(800), // Simular uma demora no retorno da API
      tap((res: any) => console.log('getOrdens:', res))
    );
  }
}
