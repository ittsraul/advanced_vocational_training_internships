package com.raul.store.application.services.impl;

import com.raul.store.application.dto.ItemDTO;
import com.raul.store.application.mapper.ItemMapper;
import com.raul.store.application.services.ItemService;
import com.raul.store.domain.entity.Item;
import com.raul.store.domain.persistence.ItemPersistence;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class ItemServiceImpl implements ItemService {
    private final ItemPersistence itemPersistence;
    private final ItemMapper itemMapper;

    public ItemServiceImpl(ItemPersistence itemPersistence, ItemMapper itemMapper) {
        this.itemPersistence = itemPersistence;
        this.itemMapper = itemMapper;
    }

    @Override
    public List<ItemDTO> getAllItemsByCategory(Long categoryId) {
        List<Item> items = this.itemPersistence.getAllItemsByCategory(categoryId);
        return this.itemMapper.toDto(items);
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
