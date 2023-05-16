package com.raul.store.domain.persistence;

import com.raul.store.domain.entity.Item;

import java.util.List;
import java.util.Optional;

public interface ItemPersistence {
    List<Item> getAllItemsByCategory(Long categoryId);
    Optional<Item> getItemsById(Long itemId);
    Item saveItem(Item item);
    void deleteItem(Long itemId);
}
