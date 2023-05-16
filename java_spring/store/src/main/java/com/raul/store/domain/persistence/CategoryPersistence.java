package com.raul.store.domain.persistence;

import com.raul.store.domain.entity.Category;
import org.springframework.stereotype.Repository;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.List;
import java.util.Optional;

@Repository
public interface CategoryPersistence {
    List<Category> getAllCategories();
    Optional<Category> getCategorieById(Long categoryId);
    Category saveCategory(Category category);
    void deleteCategory(Long categoryId);

}
