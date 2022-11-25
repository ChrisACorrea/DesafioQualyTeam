import { Injectable } from '@angular/core';
import { Processo } from 'src/app/components/processo/processo.model';
import { BaseService } from 'src/app/components/shared/base.service';

@Injectable({
  providedIn: 'root'
})
export class ProcessoService extends BaseService<Processo>{
  protected resourceName: string = "processos";

  constructor() {
    super();
  }
}
