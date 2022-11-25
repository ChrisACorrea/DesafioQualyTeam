import { Component, inject } from '@angular/core';
import { Documento } from 'src/app/components/documento/documento.model';
import { DocumentoService } from 'src/app/components/documento/documento.service';
import { BaseListComponent } from 'src/app/components/shared/base-list/base-list.component';

@Component({
  selector: 'app-documento-list',
  templateUrl: './documento-list.component.html',
  styleUrls: ['./documento-list.component.scss']
})
export class DocumentoListComponent extends BaseListComponent<Documento, DocumentoService> {
  protected service: DocumentoService = inject(DocumentoService);

  constructor() {
    super();
  }

  ngOnInit(): void {
    this.buscarDados();
  }

  public getLinkDownload(documentoId: string): string {
    return `${this.service.getResourceUrl()}/${documentoId}/DownloadArquivo`
  }

}
