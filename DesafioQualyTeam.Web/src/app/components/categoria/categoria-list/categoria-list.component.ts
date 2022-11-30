import { Component, inject, OnInit } from '@angular/core';
import { Categoria } from 'src/app/components/categoria/categoria.model';
import { CategoriaService } from 'src/app/components/categoria/categoria.service';
import { BaseListComponent } from 'src/app/components/shared/base-list/base-list.component';

@Component({
  selector: 'app-categoria-list',
  templateUrl: './categoria-list.component.html',
  styleUrls: ['./categoria-list.component.scss']
})
export class CategoriaListComponent extends BaseListComponent<Categoria, CategoriaService> {
  protected override service: CategoriaService = inject(CategoriaService);

  constructor() {
    super();
  }

  ngOnInit(): void {
    this.buscarDados();
  }

}
