package com.kreitek.files;

import java.util.ArrayList;
import java.util.List;

public class Directory extends FileSystemItemBase implements FileSystemItem {

    private static final String NO_ES_VALIDO_PARA_DIRECTORIOS = "No es válido para directorios";
    private final List<FileSystemItem> files;
    private int totalSize = 0;

    public Directory(FileSystemItem parent, String name) {
        super(parent, name);
        files = new ArrayList<>();
        // Aquí vendría lógica que rellena la lista de ficheros
    }

    @Override
    public String getExtension() {
        throw new UnsupportedOperationException(NO_ES_VALIDO_PARA_DIRECTORIOS);
    }

    @Override
    public List<FileSystemItem> listFiles() {
        return files;
    }

    @Override
    public void addFile(FileSystemItem file) {
        if (!files.contains(file)) {
            files.add(file);
            file.setParent(this);
        }
    }
 
 







 	
 	@Override
 	  public void removeFile(FileSystemItem file) {
 	      files.remove(file);
 	  }

 
 
 
 


    /* No quiere que lance excepsion sino que devuelva el tamaño total de fichgeros y directorios que contiene */
    @Override
    public int getSize() {
       // throw new UnsupportedOperationException(NO_ES_VALIDO_PARA_DIRECTORIOS);
    	for(int i = 0; i < files.size(); i++) {
    		// obteniendo elemento de file(arrayList) y ejecutando el getSize() y si es un fichero retorna el tamaño y si es un directorio esta ejecutandose a si mismo y suma los elementos y retorna el total
    		totalSize += files.get(i).getSize();
    	}
    	return totalSize;
    }

    @Override
    public void open() {
        throw new UnsupportedOperationException(NO_ES_VALIDO_PARA_DIRECTORIOS);
    }

    @Override
    public void setPosition(int numberOfBytesFromBeginning) {
        throw new UnsupportedOperationException(NO_ES_VALIDO_PARA_DIRECTORIOS);
    }

    @Override
    public byte[] read(int numberOfBytesToRead) {
        throw new UnsupportedOperationException(NO_ES_VALIDO_PARA_DIRECTORIOS);
    }

    @Override
    public void write(byte[] buffer) {
        throw new UnsupportedOperationException(NO_ES_VALIDO_PARA_DIRECTORIOS);

    }

    public void close() {
        throw new UnsupportedOperationException(NO_ES_VALIDO_PARA_DIRECTORIOS);
    }
}
