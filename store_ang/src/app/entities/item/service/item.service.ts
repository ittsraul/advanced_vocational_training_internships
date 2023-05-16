import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { items } from '../models/items/items.module';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http: HttpClient) { }

  urlItems = "http://localhost:8080/store/items";
 

  public getAllItems(): Observable<items[]> {
    
    return this.http.get<items[]>(this.urlItems)
  }

  public getAllItemsByCategoryId(categoryId: number): Observable<items[]> {
    const urlItemsByCategory = "http://localhost:8080/store/categories/" + categoryId + "/items";
    return this.http.get<items[]>(urlItemsByCategory);
  }
}
