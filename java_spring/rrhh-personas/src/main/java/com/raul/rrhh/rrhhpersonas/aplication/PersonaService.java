package com.raul.rrhh.rrhhpersonas.aplication;

import com.raul.rrhh.rrhhpersonas.domain.Persona;

import java.util.Optional;
import java.util.List;

public interface PersonaService {
	List<Persona> getAllPersonas();
	Persona createPersona(Persona persona);
	void deletePersona(Integer id);
	Optional<Persona> getPersona(Integer id);
}
