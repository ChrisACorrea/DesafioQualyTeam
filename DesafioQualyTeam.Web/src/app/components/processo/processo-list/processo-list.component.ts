import { Component, inject, OnInit } from '@angular/core';
import { Processo } from 'src/app/components/processo/processo.model';
import { ProcessoService } from 'src/app/components/processo/processo.service';
import { BaseListComponent } from 'src/app/components/shared/base-list/base-list.component';

@Component({
  selector: 'app-processo-list',
  templateUrl: './processo-list.component.html',
  styleUrls: ['./processo-list.component.scss']
})
export class ProcessoListComponent extends BaseListComponent<Processo, ProcessoService> {
  protected service: ProcessoService = inject(ProcessoService);

  constructor() {
    super();
  }

  ngOnInit(): void {
    this.buscarDados();
  }

}
