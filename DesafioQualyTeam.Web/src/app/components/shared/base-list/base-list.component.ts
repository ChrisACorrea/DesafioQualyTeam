import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseModel } from 'src/app/components/shared/base.model';
import { BaseService } from 'src/app/components/shared/base.service';

@Component({
  selector: 'app-base-list',
  template: `<p>base-list works!</p>`,
  styles: [],
})
export abstract class BaseListComponent<T extends BaseModel, U extends BaseService<T>> implements OnInit {
  protected abstract readonly service: U
  protected readonly route: ActivatedRoute = inject(ActivatedRoute)
  protected readonly router: Router = inject(Router)

  public entidades: T[] = [];

  abstract ngOnInit(): void;

  public buscarDados(): void {
    this.service.getList().subscribe({
      next: (resposta) => {
        this.entidades = resposta;
      }
    })
  }

  public irParaDetalhe(entidade: T) {
    this.router.navigate([entidade.id], { relativeTo: this.route });
  }

  public criar() {
    this.router.navigate(["novo"], { relativeTo: this.route });
  }

}
