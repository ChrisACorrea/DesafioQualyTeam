import { Component, inject } from '@angular/core';
import { Documento, TiposArquivosAceitos } from 'src/app/components/documento/documento.model';
import { DocumentoService } from 'src/app/components/documento/documento.service';
import { Processo } from 'src/app/components/processo/processo.model';
import { ProcessoService } from 'src/app/components/processo/processo.service';
import { BaseDetailComponent } from 'src/app/components/shared/base-details/base-details.component';

@Component({
  selector: 'app-documento-detail',
  templateUrl: './documento-detail.component.html',
  styleUrls: ['./documento-detail.component.scss']
})
export class DocumentoDetailComponent extends BaseDetailComponent<Documento, DocumentoService> {
  protected service: DocumentoService = inject(DocumentoService);
  private processoService: ProcessoService = inject(ProcessoService);

  public processos: Processo[] = [];
  public tiposDocumentosAceitos: string = TiposArquivosAceitos.join(",");
  public arquivo: any[];
  public nomeArquivo: string;

  constructor() {
    super();
    this.entidade = new Documento();
  }

  ngOnInit(): void {
    this.carregarDadosRelacionados();
    this.buscarDados();
  }

  private carregarDadosRelacionados(): void {
    this.carregarProcessos();
  }

  private carregarProcessos(): void {
    this.processoService.getList().subscribe({
      next: (value) => {
        this.processos = value;
      }
    })
  }

  public prepararArquivo(event: any): void {
    this.entidade.arquivo = event.currentFiles[0];
  }

  protected override aposBuscarDados(): void {
    this.nomeArquivo = this.entidade?.detalheArquivo?.nome;
  }

  protected override aposSalvar(): void {
    this.nomeArquivo = this.entidade?.detalheArquivo?.nome;
  }

  public getLinkDownload(): string {
    return `${this.service.getResourceUrl()}/${this.entidade.id}/DownloadArquivo`
  }

}
