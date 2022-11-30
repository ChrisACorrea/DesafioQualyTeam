import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Documento } from 'src/app/components/documento/documento.model';
import { BaseService } from 'src/app/components/shared/base.service';

@Injectable({
  providedIn: 'root'
})
export class DocumentoService extends BaseService<Documento>{
  protected resourceName: string = "documentos";

  constructor() {
    super();
  }

  public override save(entity: Documento): Observable<Documento> {
    let formData = new FormData();

    if (entity.id) formData.append("id", entity.id);
    if (entity.codigo) formData.append("codigo", entity.codigo);
    if (entity.titulo) formData.append("titulo", entity.titulo);
    if (entity.categoria?.id) formData.append("categoriaId", entity.categoria.id);
    if (entity.processo?.id) formData.append("processoId", entity.processo.id);
    if (entity.arquivo) formData.append("arquivo", entity.arquivo);

    return super.save(formData);
  }
}
