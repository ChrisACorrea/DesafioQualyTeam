import { Processo } from "src/app/components/processo/processo.model";
import { BaseModel } from "src/app/components/shared/base.model";

export class Categoria extends BaseModel {
  public nome: string;
  public processoId: string;
  public processo: Processo;
}
