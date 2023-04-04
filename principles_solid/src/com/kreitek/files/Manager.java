 package com.kreitek.files;
 
 public interface Manager {
 	String getName();
 	void setName(String name);
 	String getExtension();
 	int getSize();
 	void open();
 	void close();
 	void setPosition(int numberOfBytesFromBeginning);
 	byte[] read(int numberOfBytesToRead);
 	void write(byte[] buffer);
 }
