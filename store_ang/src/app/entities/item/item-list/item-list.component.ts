import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import { ItemService } from '../service/item.service';
import { items } from '../models/items/items.module';
@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss'],
})
export class ItemListComponent implements OnInit {
  categoryId?: number;
  title: string;
  items: items[] = [];

  page: number = 0;
  size: number = 25;
  sort: string = 'name.asc';

  first: boolean = false;
  last: boolean = false;
  totalPages: number = 0;
  totalElements: number = 0;

  nameFilter?: string;
  priceFilter?: number;

  itemIdToDelete?: number;

  constructor(
    private route: ActivatedRoute,
    private itemsService: ItemService
  ) {}

  ngOnInit(): void {
    if (this.route.snapshot.paramMap.get('categoryId')) {
      this.categoryId = +this.route.snapshot.paramMap.get('categoryId')!;
      this.title = 'Articulos de la categoria' + this.categoryId;
    } else {
      this.title = 'Lista de articulos de la categoria';
    }
    this.getAllItems();
  }

  public nextPage(): void {
    this.page = this.page + 1;
    this.getAllItems();
  }

  public previousPage(): void {
    this.page = this.page - 1;
    this.getAllItems();
  }

  public searchByFilters(): void {
    this.getAllItems();
  }

  public prepareItemToDelete(itemId: number) {
    this.itemIdToDelete = itemId;
  }

  public deleteItem(): void {
    if (this.itemIdToDelete) {
      this.itemsService.deleteItem(this.itemIdToDelete!).subscribe({
        next: (data) => {
          this.getAllItems();
        },
        error: (err) => {
          this.handleError(err);
        }
      });
    }
  }

  public buildFilters(): string | undefined {
    const filters: string[] = [];

    if (this.categoryId) {
      filters.push('category.id:EQUAL:' + this.categoryId);
    }

    if (this.nameFilter) {
      filters.push('name:MATCH;' + this.nameFilter);
    }
    if (this.priceFilter) {
      filters.push('price:LESS_THAN_EQUAL;' + this.priceFilter);
    }
    if (filters.length > 0) {
      let globalFilters: string = '';
      for (let filter of filters) {
        globalFilters = globalFilters + filter + ',';
      }
      globalFilters = globalFilters.substring(0, globalFilters.length - 1);
      return globalFilters;
    } else {
      return undefined;
    }
  }

  public getAllItems(): void {
    const filters: string | undefined = this.buildFilters();

    this.itemsService
      .getAllItems(this.page, this.size, this.sort, filters)
      .subscribe({
        next: (data: any) => {
          this.items = data.content;
          this.first = data.first;
          this.last = data.last;
          this.totalPages = data.totalPages;
          this.totalElements = data.totalElements;
        },
        error: (err) => {
          this.handleError(err);
        },
      });
  }

  /*  
public getAllItemsInCategory(categoryId : number) :void{
  this.itemsService.getAllItemsByCategoryId(categoryId).subscribe({
    next: (itemsRequest) => {this.items = itemsRequest;},
    error: (err) => {this.handleError(err);}
  });
 } 
 */

  private handleError(error: any) {}
}
