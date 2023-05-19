package com.raul.store.application.services;

import com.raul.store.application.dto.CategoryDTO;
import com.raul.store.domain.entity.Category;

import java.util.List;
import java.util.Optional;

public interface CategoryService {
    List<CategoryDTO> getAllCategories();
    Optional<CategoryDTO> getCategorieById(Long categoryId);
    CategoryDTO saveCategory(CategoryDTO category);
    void deleteCategory(Long categoryId);

    List<CategoryDTO> getAllCategoriesByName(String partialName);
}
