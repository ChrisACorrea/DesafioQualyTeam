import { Component, inject, OnInit } from '@angular/core';
import { Processo } from 'src/app/components/processo/processo.model';
import { ProcessoService } from 'src/app/components/processo/processo.service';
import { BaseDetailComponent } from 'src/app/components/shared/base-details/base-details.component';

@Component({
  selector: 'app-processo-detail',
  templateUrl: './processo-detail.component.html',
  styleUrls: ['./processo-detail.component.scss']
})
export class ProcessoDetailComponent extends BaseDetailComponent<Processo, ProcessoService> {
  protected service: ProcessoService = inject(ProcessoService);

  constructor() {
    super();
    this.entidade = new Processo();
  }

  ngOnInit(): void {
    this.buscarDados();
  }

}
