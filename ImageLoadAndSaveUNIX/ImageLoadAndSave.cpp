// ImageLoadAndSave.cpp : Defines the exported functions for the DLL application.
//

#include "ImageLoadAndSave.h"  
#include <iostream>
#include <fstream>

using namespace std;

bool Load(const char* path, char* bytes, unsigned size) {
	ifstream filePNG(path, ios::in | ios::binary);

	if (filePNG.is_open())
	{
		filePNG.read(bytes, size);
		filePNG.close();
		return true;
	}
	return false;
}
	
unsigned GetSize(const char* path) {
	streampos size;
	ifstream filePNG(path, ios::in | std::ifstream::ate);

	if (filePNG.is_open())
	{
		size = filePNG.tellg();
		filePNG.close();
		return size;
	}
	return 0;
}

bool Save(const char* bytes, unsigned size, const char* path) {
	ofstream filePNG(path, ios::out | ios::binary);

	if (filePNG.is_open())
	{
		filePNG.write(bytes, size);
		filePNG.close();
		return true;
	} 
	return false;
}
