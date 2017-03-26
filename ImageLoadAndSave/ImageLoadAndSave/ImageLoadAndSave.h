#pragma once

#ifdef ImageLoadAndSaveLIBRARY_EXPORTS  
#define ImageLoadAndSaveIBRARY_API __declspec(dllexport)   
#else  
#define ImageLoadAndSaveLIBRARY_API __declspec(dllimport)   
#endif  

extern "C" {
	// Returns bytes of PNG image
	ImageLoadAndSaveLIBRARY_API bool Load(const char* path, char* bytes, unsigned size);

	// Returns true if bytes successfully saved in PNG file
	ImageLoadAndSaveLIBRARY_API bool Save(const char* bytes, unsigned size, const char* path);

	// Returns the size of PNG image
	ImageLoadAndSaveLIBRARY_API unsigned GetSize(const char* path);
}
