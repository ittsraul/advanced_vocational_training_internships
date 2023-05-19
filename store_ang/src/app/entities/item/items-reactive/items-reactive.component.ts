import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ItemService } from '../service/item.service';
import { items } from '../models/items/items.module';
import { Category } from '../../category/models/category/category.module';
import { CategoryService } from '../../category/service/category.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-items-reactive',
  templateUrl: './items-reactive.component.html',
  styleUrls: ['./items-reactive.component.scss']
})
export class ItemsReactiveComponent {
  node: "NEW" | "UPDATE" = "NEW";
itemId?: number;
item?: items;
selectedCategory?: Category;
categories: Category[] = [];

itemForm :FormGroup;

constructor(private route : ActivatedRoute,private fb : FormBuilder, private itemService: ItemService, private categoryService: CategoryService){}

  ngOnInit(): void {

    this.buildForm();
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
  public getAllCategories(event?: any): void {
    let categorySearch: string | undefined;
    if (event?.query) {
      categorySearch = event.query;
    }

  this.categoryService.getAllCategories().subscribe({
    next: (categoriesFiltered) => {
      this.categories = categoriesFiltered;
    },
    error: (err) => {
      this.handleError(err);
    },
  });
  }
  
  public saveItem(): void {
    const itemToSave: items = this.createFrom();
    if (this.node === "NEW") {
      this.insertItem(itemToSave);
    }

    if (this.node === "UPDATE") {
      this.updateItem(itemToSave);
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

  public includeImageInItems(event : any) :void{
    const inputFile = event.target as HTMLInputElement;
   const file: File | null = inputFile.files?.item(0) ?? null;

    this.readFileAsString(file!).then((result) =>{
      const imageType: string = this.getImageType(result);
      console.log(imageType);
      const ImageBase64: string = this.getImageBase64(result);
      console.log(ImageBase64);

      this.item!.image = ImageBase64;
    },
    (error) => {
      console.log("No se puede cargar la imagen"); 
    })
  }

  public readFileAsString(file: File){
    return new Promise<string>(function(resolve, reject) {
      let reader: FileReader = new FileReader();
      reader.readAsDataURL(file)
      reader.onload = function(){
        resolve(this.result as string)
      }  
    
    });
  }

  private getImageType(imageString :string) :string{
    const imageStringParts :string[] = imageString.split(",");
    if (imageStringParts.length == 2) {
      return imageStringParts[0];
    } else {
      return "";
    }
  }

  private getImageBase64(imageString :string) :string{
    const imageStringParts :string[] = imageString.split(",");
    if (imageStringParts.length == 2) {
      return imageStringParts[1];
    } else {
      return "";
    }
  }
 
  private insertItem(itemToSave: items):void{
    this.itemService.insert(itemToSave).subscribe({
      next: (itemInserted) => {
        console.log("Insertado Correctamente");
        console.log(itemInserted);
      },
      error: (err) => { this.handleError(err)}
    });
  }

  private updateItem(itemToSave: items):void{
    this.itemService.update(itemToSave).subscribe({
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
        this.updateForm(itemRequest);
        this.selectedCategory = new Category(itemRequest.categoryId!, itemRequest.categoryName!)
      },
      error: (err) => {
        this.handleError(err);
      }
    });
  }


  private buildForm(): void {
    this.itemForm = this.fb.group({
      id: [{value: undefined, disabled: true}],
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      description: ['', [Validators.maxLength(2000)]],
      price: [ 0, [Validators.required, Validators.min(0)]],
      category: [undefined, [Validators.required]]
    })
  }

  private updateForm(item: items) :void{
    this.itemForm?.patchValue({
      id: item.id ,
      name: item.name ,
      description: item.description ,
      price: item.price ,
      category: new Category(item.categoryId!, item.categoryName!) ,
    })
  }

  private createFrom(): items {
    return {
      ...this.item,
      id: this.itemForm?.get(['id'])!.value,
      name: this.itemForm?.get(['name'])!.value,
      description: this.itemForm?.get(['description'])!.value,
      price: this.itemForm?.get(['price'])!.value,
      image: this.item!.image,
      categoryId: this.itemForm?.get(['category'])!.value.id,
      categoryName: this.itemForm?.get(['category'])!.value.name,
    };
  }

  private initializeItem():void {
    this.item = new items(undefined, "",0);
  }

  private handleError(err: any):void {
    //ToDo
  }
}
