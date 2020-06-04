import { PostoColetaViewModel } from './../models/postocoletaviewmodel.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take, delay, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostoColetaService {

  public postosColetaApi = `${environment.apiUrl}/v1/postoscoleta`;

  constructor(private http: HttpClient) { }

  getPostoColetas() {
    return this.http.get<PostoColetaViewModel[]>(`${this.postosColetaApi}`).pipe(
    );
  }
}
