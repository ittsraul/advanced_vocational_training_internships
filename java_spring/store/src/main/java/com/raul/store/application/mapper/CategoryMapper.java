package com.raul.store.application.mapper;

import com.raul.store.application.dto.CategoryDTO;
import com.raul.store.domain.entity.Category;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface CategoryMapper extends EntityMapper<CategoryDTO, Category> {
    default Category fromId(Long id){
        if (id == null) return null;

        Category category = new Category();
        category .setId(id);
        return category;
    }
}
