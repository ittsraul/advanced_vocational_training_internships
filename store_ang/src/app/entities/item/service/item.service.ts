import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { items } from '../models/items/items.module';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  
  
  constructor(private http: HttpClient) { }

  public getAllItems(page: number, size: number, sort: string, filters?: string): Observable<items[]> {
    let urlItems = "http://localhost:8080/store/items?page" + page + "&size=" +size + "&sort=" + sort;
    if (filters) {
      urlItems += "&filters" + filters;
    }
    return this.http.get<items[]>(urlItems);
  }
  public deleteItem(itemIdToDelete: number | undefined) :Observable<any> {
    let urlItems = "http://localhost:8080/store/items/" + itemIdToDelete ;
    return this.http.delete<any>(urlItems);
  }
  
  public getItemById(itemId: number) :Observable<items>{
    let urlItems = "http://localhost:8080/store/items/" + itemId ;
    return this.http.delete<any>(urlItems);
  }

  public insert(itemId: items) :Observable<items>{
    let urlItems = "http://localhost:8080/store/items/" ;
    return this.http.patch<items>(urlItems, items);
  }

  public update(itemId: items) :Observable<items>{
    let urlItems = "http://localhost:8080/store/items/" ;
    return this.http.patch<items>(urlItems, items);
  }


  /* 
  public getAllItemsByCategoryId(categoryId: number, page: number, size: number, sort: string): Observable<items[]> {
    const urlItemsByCategory = "http://localhost:8080/store/items?filter=category.id:EQUAL:" + categoryId + "&page=" + page + "&size=" + size + "&sort=" + sort;
    return this.http.get<items[]>(urlItemsByCategory);
  } 
  */
}
