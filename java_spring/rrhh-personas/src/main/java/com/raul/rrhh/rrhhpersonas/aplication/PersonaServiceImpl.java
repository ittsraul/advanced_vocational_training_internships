package com.raul.rrhh.rrhhpersonas.aplication;

import com.raul.rrhh.rrhhpersonas.domain.Persona;
import com.raul.rrhh.rrhhpersonas.domain.PersonaRepository;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
class PersonaServiceImpl implements PersonaService {
	private final PersonaRepository personaRepository;
	private final PersonaMapper mapper;
	public  PersonaServiceImpl(PersonaRepository personaRepository, PersonaMapper mapper) {
		this.personaRepository = personaRepository;
		this.mapper = mapper;
	}
	
	@Override
	public List<Persona> getAllPersonas(){
		List<Persona> personas = new ArrayList();
		personaRepository.findAll().forEach(employee -> personas.add(employee));
		return personas;
	}
	
	@Override
	public PersonaDTO createPersona(PersonaDTO personaDto) {
		Persona persona = this.mapperDtoToPersona(personaDto);
		persona = personaRepository.save(persona);
		return this.mapper.personaToPersonaDto(persona);
	}

	@Override
	public void deletePersona(Integer id){
		personaRepository.deleteById(id);
	}

	@Override
	public Optional<PersonaDTO> getPersona(Integer id){
		Optional<Persona> persona = personaRepository.findById(id);
		return  mapper.personaToPersonaDto(persona);
	}

	@Override
	public List<PersonaDTO> getPersonsByCriteria(PersonaCriteria personaCriteria){
		List<PersonaDTO> personas = new ArrayList<>();
		personaRepository.findByNombre(personaCriteria.getNombre().forEach(persona -> personas.add(this.mapper.personaToPersonaDto(persona)))
		return personas;
	}
}
