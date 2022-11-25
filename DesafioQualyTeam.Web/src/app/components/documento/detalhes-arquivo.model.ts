import { BaseModel } from "src/app/components/shared/base.model";

export class DetalhesArquivo extends BaseModel {
  public nome: string;
  public contentType: string;
  public documentoId: string;
}
