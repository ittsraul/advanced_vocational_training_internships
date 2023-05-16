package com.raul.store.infraestructure.persistence;

import com.raul.store.domain.entity.Item;
import com.raul.store.domain.persistence.ItemPersistence;

import java.util.List;
import java.util.Optional;

public class ItemPersistenceImpl implements ItemPersistence {
    private final ItemRepository itemRepo;

    public ItemPersistenceImpl(ItemRepository itemRepo) {
        this.itemRepo = itemRepo;
    }

    @Override
    public List<Item> getAllItemsByCategory(Long itemId) {
       return this.itemRepo.findByCategoryId(itemId);
    }

    @Override
    public Optional<Item> getItemsById(Long itemId) {
        return this.itemRepo.findById(itemId);
    }

    @Override
    public Item saveItem(Item item) {
        return this.itemRepo.save(item);
    }

    @Override
    public void deleteItem(Long itemId) {
        this.itemRepo.deleteById(itemId);
    }
}
