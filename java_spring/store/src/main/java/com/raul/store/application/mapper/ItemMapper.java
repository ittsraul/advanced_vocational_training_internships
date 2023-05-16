package com.raul.store.application.mapper;

import com.raul.store.application.dto.ItemDTO;
import com.raul.store.domain.entity.Item;
import org.mapstruct.Mapper;
import org.mapstruct.Mapping;

@Mapper(componentModel = "spring", uses = CategoryMapper.class)
public interface ItemMapper extends EntityMapper<ItemDTO, Item> {

    @Override
    @Mapping(source="categoryId", target="category" )
    Item toEntity(ItemDTO dto);

    @Override
    @Mapping(source= "category.id", target="categoryId")
    @Mapping(source="category.name", target="categoryName")
    ItemDTO toDto(Item entity);
}
