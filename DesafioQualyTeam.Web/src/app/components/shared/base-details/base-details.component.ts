import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { BaseModel } from 'src/app/components/shared/base.model';
import { BaseService } from 'src/app/components/shared/base.service';

@Component({
  selector: 'app-base-details',
  template: `<p>base-details works!</p>`,
  styles: [
  ]
})
export abstract class BaseDetailComponent<T extends BaseModel, U extends BaseService<T>> implements OnInit {
  protected abstract readonly service: U
  protected readonly route: ActivatedRoute = inject(ActivatedRoute)
  protected readonly router: Router = inject(Router)

  public entidadeId: string | null = null;
  public entidade: T;

  public modoEdicao: boolean = false;

  abstract ngOnInit(): void;

  private recuperarId(): void {
    this.entidadeId = this.route.snapshot.paramMap.get('id');
  }

  public buscarDados(): void {
    this.recuperarId();

    if (!this.entidadeId) return;

    if (this.isNovaEntidade()) {
      this.modoEdicao = true;
      return;
    }

    this.service.getById(this.entidadeId).subscribe({
      next: (resposta) => {
        this.entidade = resposta;
        this.aposBuscarDados();
      }
    })
  }

  protected aposBuscarDados(): void {
    return;
  }

  protected antesDeSalvar(): void {
    return;
  }

  public salvar() {
    this.antesDeSalvar();
    this.service.save(this.entidade).subscribe(
      {
        next: (value) => {
          this.entidade = value;
          this.desabilitarModoEdicao();
          this.aposSalvar();
          this.router.navigate([this.service.getResourceName(), value.id]);
        }
      }
    );
  }

  protected aposSalvar(): void {
    return;
  }

  public deletar(): void {
    this.recuperarId();

    if (!this.entidade.id || this.isNovaEntidade()) return;

    this.service.delete(this.entidade.id).subscribe({
      next: (resposta) => {
        console.log("Deletado com sucesso");
        this.router.navigate([".."], { relativeTo: this.route });
      }
    })
  }

  public voltarParaLista(): void {
    this.router.navigate([".."], { relativeTo: this.route });
  }

  public habilitarModoEdicao(): void {
    this.modoEdicao = true;
  }

  public desabilitarModoEdicao(): void {
    this.modoEdicao = false;
  }

  public cancelarEdicao(): void {
    this.desabilitarModoEdicao();
    if (this.isNovaEntidade()) {
      this.router.navigate([".."], { relativeTo: this.route });
      return;
    }

    this.buscarDados();
  }

  public alternarModoEdicao(): void {
    if (this.modoEdicao)
      this.desabilitarModoEdicao();
    else
      this.habilitarModoEdicao();
  }

  public isNovaEntidade(): boolean {
    return this.entidadeId === "novo";
  }
}
