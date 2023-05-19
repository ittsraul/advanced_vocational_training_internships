package com.raul.store.application.services.impl;

import com.raul.store.application.dto.ItemDTO;
import com.raul.store.application.mapper.ItemMapper;
import com.raul.store.application.services.ItemService;
import com.raul.store.domain.entity.Item;
import com.raul.store.domain.persistence.ItemPersistence;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class ItemServiceImpl implements ItemService {
    private final ItemPersistence itemPersistence;
    private final ItemMapper itemMapper;

    @Autowired
    public ItemServiceImpl(ItemPersistence itemPersistence, ItemMapper itemMapper) {
        this.itemPersistence = itemPersistence;
        this.itemMapper = itemMapper;
    }

    @Override
    public Page<ItemDTO> getItemsByCriteriaStringPaged(Pageable pageable, String filter) {
        Page<Item> itemPage = this.itemPersistence.findAll(pageable, filter);
        return itemPage.map(itemMapper::toDto);
    }

    @Override
    public List<ItemDTO> getAllItems() {
        List<Item> items = this.itemPersistence.getAllItems();
        return this.itemMapper.toDto(items);
    }

    @Override
    public List<ItemDTO> getAllItemsByCategory(Long categoryId) {
        List<Item> items = this.itemPersistence.getAllItemsByCategory(categoryId);
        return this.itemMapper.toDto(items);
    }

    @Override
    public Optional<ItemDTO> getItemById(Long itemId) {
        return Optional.empty();
    }

    @Override
    public ItemDTO saveItem(ItemDTO ItemDTO) {
        return null;
    }

    @Override
    public void deleteItems(Long itemId) {
        this.itemPersistence.deleteItem(itemId);
    }

    @Override
    public Optional<ItemDTO> getCategorieById(Long itemId) {
        return this.itemPersistence.getItemsById(itemId).map(itemMapper::toDto);
    }

    @Override
    public ItemDTO saveCategory(ItemDTO ItemDTO) {
        Item itemSaved = this.itemPersistence.saveItem(this.itemMapper.toEntity(ItemDTO));
        return this.itemMapper.toDto(itemSaved);
    }

    @Override
    public void deleteCategory(Long itemId) {
        this.itemPersistence.deleteItem(itemId);
    }


}
