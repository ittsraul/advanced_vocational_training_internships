package com.raul.store.application.services.impl;

import com.raul.store.application.dto.CategoryDTO;
import com.raul.store.application.mapper.CategoryMapper;
import com.raul.store.application.services.CategoryService;
import com.raul.store.domain.entity.Category;
import com.raul.store.domain.persistence.CategoryPersistence;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class CategoryServiceImpl implements CategoryService {

    private final CategoryPersistence categoryPersistence;
    private  final CategoryMapper mapper;

    @Autowired
    public CategoryServiceImpl(CategoryPersistence categoryPersistence, CategoryMapper mapper) {
        this.categoryPersistence = categoryPersistence;
        this.mapper = mapper;
    }

    @Override
    public List<CategoryDTO> getAllCategories() {
       List<Category> categories = this.categoryPersistence.getAllCategories();
       return mapper.toDto(categories);
    }

    @Override
    public Optional<CategoryDTO> getCategorieById(Long categoryId) {
        return this.categoryPersistence.getCategorieById(categoryId).map(mapper::toDto);
    }

    @Override
    public CategoryDTO saveCategory(CategoryDTO categoryDTO) {
        Category category = this.categoryPersistence.saveCategory(this.mapper.toEntity(categoryDTO));
        return this.mapper.toDto(category);
    }

    @Override
    public void deleteCategory(Long categoryId) {
        this.categoryPersistence.deleteCategory(categoryId);
    }
}
