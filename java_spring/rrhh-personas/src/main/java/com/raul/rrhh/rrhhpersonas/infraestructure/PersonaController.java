package com.raul.rrhh.rrhhpersonas.infraestructure;

import com.raul.rrhh.rrhhpersonas.aplication.PersonaDTO;
import com.raul.rrhh.rrhhpersonas.domain.Persona;
import com.raul.rrhh.rrhhpersonas.aplication.PersonaService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;
import javax.servlet.http.HttpServletRequest;
import java.util.List;

@RestController
public class PersonaController {
	private final HttpServletRequest request;
	private final PersonaService personaService;

	public PersonaController(HttpServletRequest request, PersonaService personaService) {
		this.request = request;
		this.personaService = personaService;
	}

	@GetMapping("/persona")
	public ResponseEntity<List<PersonaDTO>> getPersonas(){
		String accept = request.getHeader("Accept");
		if(accept != null && accept.contains("application/json")) {
			List<PersonaDTO> personas = personaService.getAllPersonas();
			return new ResponseEntity<>(personas, HttpStatus.OK);
		}

		return new ResponseEntity<List<PersonaDTO>>(HttpStatus.NOT_IMPLEMENTED);
	}
	@PostMapping("/persona")
	public ResponseEntity<PersonaDTO> postPersona(@RequestBody Persona nuevaPersona){
		String accept = request.getHeader("Accept");
		if(accept != null && accept.contains("application/json")) {
			PersonaDTO persona = personaService.createPersona(nuevaPersona);
			return new ResponseEntity<>(persona, HttpStatus.OK);
		}

		return new ResponseEntity<PersonaDTO>(HttpStatus.NOT_IMPLEMENTED);
	}

	@GetMapping("/persona")
	public ResponseEntity<List<Persona>> getPersonas(){
		String accept = request.getHeader("Accept");
		if(accept != null && accept.contains("application/json")) {
			List<Persona> personas = personaService.getAllPersonas();
			return new ResponseEntity<>(personas, HttpStatus.OK);
		}

		return new ResponseEntity<List<Persona>>(HttpStatus.NOT_IMPLEMENTED);
	}
}