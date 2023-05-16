import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import { ItemService } from '../service/item.service';
import { items } from '../models/items/items.module';
@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss']
})
export class ItemListComponent implements OnInit {
categoryId?: number;
title :string;
items : items[] = [];

constructor(private route : ActivatedRoute, private itemsService : ItemService){}
ngOnInit() :void {
  if(this.route.snapshot.paramMap.get("categoryId")){
    this.categoryId = this.route.snapshot.paramMap.get("categoryId");
    this.title = "Articulos de la categoria" + this.categoryId;
    this.getAllItemsInCategory(this.categoryId);
  }else{
    this.title  = "Lista de articulos de la categoria";
    this.getAllItems();
  }
}
 public getAllItems() :void{
  this.itemsService.getAllItems().subscribe({
    next: (itemsRequest) => {this.items = itemsRequest;},
    error: (err) => {this.handleError(err);}
  });
 }

 public getAllItemsInCategory(categoryId : number) :void{
  this.itemsService.getAllItemsByCategoryId(categoryId).subscribe({
    next: (itemsRequest) => {this.items = itemsRequest;},
    error: (err) => {this.handleError(err);}
  });
 }

 private handleError(error: any){
  
 }

}
