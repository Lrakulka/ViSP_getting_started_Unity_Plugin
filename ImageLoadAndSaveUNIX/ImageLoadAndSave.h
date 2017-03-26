#pragma once

extern "C" {
	// Returns bytes of PNG image
	bool Load(const char* path, char* bytes, unsigned size);

	// Returns true if bytes successfully saved in PNG file
	bool Save(const char* bytes, unsigned size, const char* path);

	// Returns the size of PNG image
	unsigned GetSize(const char* path);
}
