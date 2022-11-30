import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriaDetailComponent } from 'src/app/components/categoria/categoria-detail/categoria-detail.component';
import { CategoriaListComponent } from 'src/app/components/categoria/categoria-list/categoria-list.component';
import { DocumentoDetailComponent } from 'src/app/components/documento/documento-detail/documento-detail.component';
import { ProcessoDetailComponent } from 'src/app/components/processo/processo-detail/processo-detail.component';
import { DocumentoListComponent } from './components/documento/documento-list/documento-list.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ProcessoListComponent } from './components/processo/processo-list/processo-list.component';

const routes: Routes = [
  { path: "home", component: HomeComponent, title: "Início" },
  { path: "documentos", component: DocumentoListComponent, title: "Documentos" },
  { path: "documentos/:id", component: DocumentoDetailComponent, title: "Documento" },
  { path: "processos", component: ProcessoListComponent, title: "Processos" },
  { path: "processos/:id", component: ProcessoDetailComponent, title: "Processos" },
  { path: "categorias", component: CategoriaListComponent, title: "Categorias" },
  { path: "categorias/:id", component: CategoriaDetailComponent, title: "Categorias" },

  { path: "", redirectTo: "/home", pathMatch: "full" },
  { path: "**", component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
