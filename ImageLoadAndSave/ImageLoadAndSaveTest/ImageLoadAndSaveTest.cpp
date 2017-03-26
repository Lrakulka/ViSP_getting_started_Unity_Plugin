// ImageLoadAndSaveTest.cpp : Defines the entry point for the console application.
// This application created for testing of DLL 

#include "stdafx.h"
#include "ImageLoadAndSave.h"

int main()
{
	char* path = "D:\\Projects\\visp-gsoc-2017-enter-tasks\\example.png";
	char* path2 = "D:\\Projects\\visp-gsoc-2017-enter-tasks\\exampleProcessed.png";
	int size = GetSize(path);
	char* bytes = new char[size];
	Load(path, bytes, size);
	Save(bytes, size, path2);
    return 0;
}

