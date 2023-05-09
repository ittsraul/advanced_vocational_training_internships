package com.raul.rrhh.rrhhpersonas;

import java.util.optional;
import java.util.ArrayList;
import java.util.List;

@Service
public class PersonaServiceImpl implements PersonaService {
	private final PersonaRepository personaRepository;
	
	public  PersonaServiceImpl(PersonaRepository personaRepository) {
		this.personaRepository = personaRepository;
	}
	
	@Override
	public List<Persona> getAllPersonas(){
		List<Persona> personas = new ArrayList();
		personaRepository.findAll().forEach(employee -> personas.add(employee));
		return personas;
	}
	
	@Override
	public Persona createPersona(Persona persona) {
		return personaRepository.save(persona);
	}

	@Override
	public void deletePersona(Integer id){
		personaRepository.deleteById(id);
	}

	@Override
	public Optional<Persona> getPersona(Integer id){
		return personaRepository.findById(id);
	}
}
