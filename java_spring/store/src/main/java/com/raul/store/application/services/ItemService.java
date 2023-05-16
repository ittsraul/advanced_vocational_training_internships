package com.raul.store.application.services;

import com.raul.store.application.dto.CategoryDTO;
import com.raul.store.application.dto.ItemDTO;

import java.util.List;
import java.util.Optional;

public interface ItemService {
    List<ItemDTO> getAllItems();
    List<ItemDTO> getAllItemsByCategory(Long categoryId);
    Optional<ItemDTO> getItemById(Long itemId);
    ItemDTO saveItem(ItemDTO ItemDTO);
    void deleteItems(Long itemId);
}
