package com.raul.rrhh.rrhhpersonas.domain;

import com.fasterxml.jackson.annotation.JsonFormat;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import javax.persistence.*;
import java.sql.Date;

@Entity
public class Persona {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Integer id;
	private String name;
	private String surnames;
	private Date fechaNacimiento;
	@Transient
	private Integer edad;

	public void setId(Integer id) {
		this.id = id;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setSurnames(String surnames) {
		this.surnames = surnames;
	}

	public void setEdad(Integer edad) {
		this.edad = edad;
	}

	public void setFechaNacimiento(Date fechaNacimiento){ this.fechaNacimiento = fechaNacimiento;}

	public Integer getEdad() {
		return edad;
	}

	public Integer getId() {
		return id;
	}

	public String getName() {
		return name;
	}

	public String getSurnames() {
		return surnames;
	}

	public Date getFechaNacimiento() { return fechaNacimiento;}
}

