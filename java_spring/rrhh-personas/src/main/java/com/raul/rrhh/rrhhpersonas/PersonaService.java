package com.raul.rrhh.rrhhpersonas;

import java.util.Optional;
import java.util.List;

public class PersonaService {
	List<Persona> getAllPersonas();
	Persona createPersona(Persona persona);
	void deletePersona(Integer id);
	Optional<Persona> getPersona(Integer id);
}
