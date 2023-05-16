package com.kreitek.store.infrastructure.specs;


import com.raul.store.domain.entity.Item;
import com.raul.store.infrastructure.specs.shared.*;
import org.springframework.data.jpa.domain.Specification;
import java.util.List;

public class ItemSpecification extends EntitySpecification<Item> implements Specification<Item> {
    public ItemSpecification(List<SearchCriteria> criteria) {
        this.criteria = criteria;
    }

}