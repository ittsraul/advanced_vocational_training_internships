package com.example.rrhh.personas.personas.raul;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id
@Entity
public class Persona {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY);
	private Long id;
	@Column(name = "nombre", lenght = 100, nullable = false, unique = true)
	private String name;
	@Transient
	private Double price;

	public void setId(Long id) {
		this.id = id;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setUnitPrice(Double price) {
		this.price = price;
	}

	public Double getPrice() {
		return price;
	}

	public Long getId() {
		return id;
	}

	public String getName() {
		return name;
	}
}

