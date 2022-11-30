import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/components/categoria/categoria.model';
import { BaseService } from 'src/app/components/shared/base.service';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService extends BaseService<Categoria> {
  protected override resourceName: string = "categorias";

  constructor() {
    super()
  }

  public getListByProcesso(processoId: string): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(`${this.getResourceUrl()}/byProcesso`, {
      params: {
        "processoId": processoId
      }
    });
  }
}
