package com.raul.store.infraestructure.rest;

import com.raul.store.application.dto.ItemDTO;
import com.raul.store.application.services.ItemService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class ItemRestController {
    private final ItemService itemService;

    public ItemRestController(ItemService itemService) {
        this.itemService = itemService;
    }

    @GetMapping(value = "/categories/{idCategory}/items", produces = "application/json")
    ResponseEntity<List<ItemDTO>>getAllItemsFromCategory(@PathVariable Long idCategory){
        List <ItemDTO> items = this.itemService.getAllItemsByCategory(idCategory);
        return new ResponseEntity<>(items, HttpStatus.OK);
    }

    @PostMapping(value = "/items", produces = "application/json", consumes = "application/json")
    ResponseEntity<ItemDTO> insertItem(@RequestBody ItemDTO itemDTO){
        ItemDTO itemSaved = this.itemService.saveItem(itemDTO);
        return new ResponseEntity<>(itemSaved, HttpStatus.CREATED);
    }
}
