import { Component } from '@angular/core';
import { Category } from '../models/category/category.module';
import { CategoryService } from '../service/category.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent {
  categories :Category[] = [];

  constructor(private CategoryService : CategoryService){}

  ngOnInit() :void {
    this.getCategorias();
  }

  private getCategorias() :void{
    this.CategoryService.getAllCategories().subscribe({
      next: (categoriesRequest) =>{ this.categories = this.categoriesRequest;},
      error: (err) => { this.handleError(err);}
    });
  }

  private handleError(error: any) :void{
    console.log(error);
    
  }
}
