import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseModel } from 'src/app/components/shared/base.model';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService<T extends BaseModel> {
  protected http = inject(HttpClient);

  protected readonly API_URL: string = "https://localhost:7216/api";
  protected abstract resourceName: string;

  public getResourceName(): string {
    return this.resourceName;
  }

  public getResourceUrl(): string {
    return `${this.API_URL}/${this.resourceName}`
  }

  /**
   * getList
   */
  public getList(): Observable<T[]> {
    return this.http.get<T[]>(`${this.getResourceUrl()}`);
  }

  /**
   * getById
   */
  public getById(id: string): Observable<T> {
    return this.http.get<T>(`${this.getResourceUrl()}/${id}`);
  }

  /**
   * save
   */
  public save(entity: T | FormData): Observable<T> {
    const entityId = entity instanceof FormData ? entity.get("id") : entity.id;

    if (entityId) {
      return this.http.put<T>(`${this.getResourceUrl()}/${entityId}`, entity);
    } else {
      return this.http.post<T>(`${this.getResourceUrl()}`, entity);
    }
  }

  /**
   * delete
   */
  public delete(id: string): Observable<any> {
    return this.http.delete<any>(`${this.getResourceUrl()}/${id}`);
  }
}
