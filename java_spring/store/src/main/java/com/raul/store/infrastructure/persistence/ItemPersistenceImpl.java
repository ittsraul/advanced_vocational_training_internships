package com.raul.store.infrastructure.persistence;

import com.raul.store.domain.entity.Item;
import com.raul.store.domain.persistence.ItemPersistence;
import com.raul.store.infrastructure.specs.shared.SearchCriteriaHelper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import com.raul.store.infrastructure.specs.ItemSpecification;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public class ItemPersistenceImpl implements ItemPersistence {
    private final ItemRepository itemRepo;

    @Autowired
    public ItemPersistenceImpl(ItemRepository itemRepo) {
        this.itemRepo = itemRepo;
    }

    @Override
    public List<Item> getAllItems(){
        return this.itemRepo.findAll();
    }
    @Override
    public List<Item> getAllItemsByCategory(Long itemId) {
       return this.itemRepo.findAllByCategoryId(itemId);
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

    @Override
    public Page<Item> findAll(Pageable pageable, String filter) {
        ItemSpecification specification = new ItemSpecification(SearchCriteriaHelper.fromFilterString(filter));
        return this.itemRepo.findAll(specification, pageable);
    }
}
