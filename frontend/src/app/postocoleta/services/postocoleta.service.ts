import { PostoColeta } from './../models/postocoleta.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take, delay, tap } from 'rxjs/operators';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostoColetaService {

  public postoColetasApi = `${environment.apiUrl}/v1/postocoletas`;

  constructor(private http: HttpClient) { }

  getPostoColetas() {
    return this.http.get<PostoColeta[]>(`${this.postoColetasApi}`).pipe(
    );
  }
}
