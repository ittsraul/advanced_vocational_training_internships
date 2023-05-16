package com.raul.store.infraestructure.persistence;

import com.raul.store.domain.entity.Item;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface ItemRepository extends JpaRepository<Item, Long> {

    List<Item> findByCategoryId(Long id);
}
