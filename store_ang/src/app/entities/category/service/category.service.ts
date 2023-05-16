import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../models/category/category.module';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  urlCategories = "http://localhost:8080/store/categories";

  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.urlCategories)
  }
}
