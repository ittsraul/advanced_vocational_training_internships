package com.raul.rrhh.rrhhpersonas;

import javax.persistence.Entity;
import javax.persistance.GeneratedValue;
import javax.persistance.GenerationType;
import javax.persistance.Id;
@Entity
public class PersonaDTO {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY);
	private Long id;
	@Column(name = "nombre", lenght = 100, nullable = false, unique = true)
	private String name;
	@JsonFormat(pattern= "dd-MM-yyyy")
	private Date fechaNacimiento;

	private integer edad;

	public void setId(Long id) {
		this.id = id;
	}

	public void setName(String name) {
		this.name = name;
	}



	public Long getId() {
		return id;
	}

	public String getName() {
		return name;
	}
}

