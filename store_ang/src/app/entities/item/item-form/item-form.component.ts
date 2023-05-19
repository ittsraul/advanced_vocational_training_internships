import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ItemService } from '../service/item.service';
import { items } from '../models/items/items.module';
import { Category } from '../../category/models/category/category.module';
import { CategoryService } from '../../category/service/category.service';

@Component({
  selector: 'app-item-form',
  templateUrl: './item-form.component.html',
  styleUrls: ['./item-form.component.scss']
})
export class ItemFormComponent implements OnInit {
node: "NEW" | "UPDATE" = "NEW";
itemId?: number;
item?: items;
selectedCategory?: Category;
categories: Category[] = [];

constructor(private route : ActivatedRoute, private itemService: ItemService, private categoryService: CategoryService){}

  ngOnInit(): void {
    const entryParam: string =this.route.snapshot.paramMap.get("itemId") ?? "new"; 
    if(entryParam !== "new"){
      this.itemId = +this.route.snapshot.paramMap.get("itemId")!;
      this.node = "UPDATE";
      this.getItemById(this.itemId!);
    }else{
      this.node = "NEW";
      this.initializeItem();
    }
  }

  public getAllCategories(event?: any) :void{
    let categorySearch: string | undefined;
    if (event?.query) {
      categorySearch = event.query;
    }
    this.categoryService.getAllCategories(categorySearch).subscribe({
      next: (categoriesFiltered) => { this.categories = categoriesFiltered},
      error: (err) =>{this.handleError(err);},
    });
  }

  public saveItem() :void{
    if (this.node === "NEW") {
      this.insertItem();
    }

    if (this.node === "UPDATE") {
      this.updateItem();
    }
  }

  public categorySelected() :void{
    this.item!.categoryId = this.selectedCategory!.id;
    this.item!.categoryName = this.selectedCategory!.name;
  }


  public categoryUnselected() :void{
    this.item!.categoryId = undefined;
    this.item!.categoryName = undefined;
  }

 
  private insertItem():void{
    this.itemService.insert(this.item!).subscribe({
      next: (itemInserted) => {
        console.log("Insertado Correctamente");
        console.log(itemInserted);
      },
      error: (err) => { this.handleError(err)}
    });
  }

  private updateItem():void{
    this.itemService.update(this.item!).subscribe({
      next: (itemUpdated) => {
        console.log("Insertado Correctamente");
        console.log(itemUpdated);
      },
      error: (err) => { this.handleError(err)}
    });
  }

  private getItemById(itemId: number){
    this.itemService.getItemById(itemId).subscribe({
      next: (itemRequest) =>{
        this.item = itemRequest;
        this.selectedCategory = new Category(itemRequest.categoryId!, itemRequest.categoryName!)
      },
      error: (err) => {
        this.handleError(err);
      }
    });
  }

  private initializeItem():void {
    this.item = new items(undefined, "",0);
  }

  private handleError(err: any):void {
    //ToDo
  }
}
