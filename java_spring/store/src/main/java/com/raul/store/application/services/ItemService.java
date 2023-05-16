package com.raul.store.application.services;

import com.raul.store.application.dto.CategoryDTO;
import com.raul.store.application.dto.ItemDTO;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.List;
import java.util.Optional;

public interface ItemService {
    Page<ItemDTO> getItemsByCriteriaStringPaged(Pageable pageable, String filter);

    List<ItemDTO> getAllItems();
    List<ItemDTO> getAllItemsByCategory(Long categoryId);
    Optional<ItemDTO> getItemById(Long itemId);
    ItemDTO saveItem(ItemDTO ItemDTO);
    void deleteItems(Long itemId);

    abstract Optional<ItemDTO> getCategorieById(Long itemId);

    ItemDTO saveCategory(ItemDTO ItemDTO);

    void deleteCategory(Long itemId);
}
