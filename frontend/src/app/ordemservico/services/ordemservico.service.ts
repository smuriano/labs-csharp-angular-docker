import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take, delay, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { OrdemServicoList } from './../models/ordemservico.list.model';
import { OrdemServico } from '../models/ordemservico.model';

@Injectable({
  providedIn: 'root'
})
export class OrdemServicoService {

  public ordensApi = `${environment.apiUrl}/v1/ordens`;

  constructor(private http: HttpClient) { }

  getOrdens() {
    return this.http.get<OrdemServicoList[]>(`${this.ordensApi}`).pipe(
      delay(200) // Simular uma demora no retorno da API
    );
  }

  getOrdemById(id: string) {
    return this.http.get<OrdemServico>(`${this.ordensApi}/${id}`).pipe(
      take(1)
    );
  }

  
}
