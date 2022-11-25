import { DetalhesArquivo } from "src/app/components/documento/detalhes-arquivo.model";
import { Processo } from "src/app/components/processo/processo.model";
import { BaseModel } from "src/app/components/shared/base.model";

export class Documento extends BaseModel {
  public codigo: string;
  public titulo: string;
  public categoria: string;
  public detalheArquivo: DetalhesArquivo;
  public processoId: string;
  public processo: Processo;
  public arquivo: File;
}

export const TiposArquivosAceitos = [
  "application/msword",
  "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
  "application/pdf",
  "application/vnd.ms-excel",
  "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
]
