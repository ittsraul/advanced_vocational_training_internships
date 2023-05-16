package com.raul.rrhh.rrhhpersonas;

import java.util.List;

public interface PersonaService {
	List<Persona> getAllPersonas();
	Persona createPersona(Persona persona);
}
