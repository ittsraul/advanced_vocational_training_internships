package com.raul.rrhh.rrhhpersonas.aplication;

import com.fasterxml.jackson.annotation.JsonFormat;
import java.sql.Date;

public class PersonaDTO {
	private Integer id;
	private String surnames;
	private String name;
	@JsonFormat(pattern="dd-MM-yyyy")
	private Date fechaNacimiento;
	private Integer edad;


	public Integer getEdad() {
		return edad;
	}

	public Integer getId() {
		return id;
	}

	public String getName() {
		return name;
	}
	public String getSurnames(){
		return surnames;
	}

	public Date getFechaNacimiento() { return fechaNacimiento;}

	public void setId(Integer id) {
		this.id = id;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setSurnames(String surnames){ this.surnames = surnames;}

	public void setEdad(Integer edad) {
		this.edad = edad;
	}

	public void setFechaNacimiento(Date fechaNacimiento){ this.fechaNacimiento = fechaNacimiento;}

}

