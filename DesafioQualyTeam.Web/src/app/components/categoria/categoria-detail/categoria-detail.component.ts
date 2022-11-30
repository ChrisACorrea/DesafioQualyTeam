import { Component, inject, OnInit } from '@angular/core';
import { Categoria } from 'src/app/components/categoria/categoria.model';
import { CategoriaService } from 'src/app/components/categoria/categoria.service';
import { Processo } from 'src/app/components/processo/processo.model';
import { ProcessoService } from 'src/app/components/processo/processo.service';
import { BaseDetailComponent } from 'src/app/components/shared/base-details/base-details.component';

@Component({
  selector: 'app-categoria-detail',
  templateUrl: './categoria-detail.component.html',
  styleUrls: ['./categoria-detail.component.scss']
})
export class CategoriaDetailComponent extends BaseDetailComponent<Categoria, CategoriaService> {
  protected override service: CategoriaService = inject(CategoriaService);
  private processoService: ProcessoService = inject(ProcessoService);

  public processos: Processo[] = [];

  constructor() {
    super();
    this.entidade = new Categoria();
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

  protected override antesDeSalvar(): void {
    super.antesDeSalvar();

    this.entidade.processoId = this.entidade.processo.id;
  }

}
