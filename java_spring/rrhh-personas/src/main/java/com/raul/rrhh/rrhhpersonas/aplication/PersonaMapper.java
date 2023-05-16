package com.raul.rrhh.rrhhpersonas.aplication;

import com.raul.rrhh.rrhhpersonas.domain.Persona;
import org.mapstruct.AfterMapping;
import org.mapstruct.Mapper;
import org.mapstruct.MappingTarget;
import org.mapstruct.factory.Mappers;

import java.util.Optional;

@Mapper (componentModel = "spring")
public abstract class PersonaMapper {
    PersonaMapper INSTANCE= Mappers.getMapper(PersonaMapper.class);
    public  abstract PersonaDTO personaToPersonaDto(Persona persona);
    public abstract Persona personToPersona(PersonaDTO persona);

    public Optional<PersonaDTO> personaToPersonaDto(Optional<Persona> persona){
        if (persona.isPresent()){
            return Optional.of(personaToPersonaDto(persona.get()));
        }else{
            return Optional.empty();
        }
    }
    @AfterMapping
    protected void convertNameToUpperCase(@MappingTarget PersonaDTO personaDTO){
        personaDTO.setName(personaDTO.getName().toUpperCase());
    }

}
