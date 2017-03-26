using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class MyPlugin {
#if UNITY_STANDALONE_WIN
	const string dllPath = "ImageLoadAndSaveWin";
#elif UNITY_STANDALONE_LINUX
	const string dllPath = "ImageLoadAndSaveUNIX";
#else 
	const string dllPath = "";
#endif

	// Type of the file
	public const string FILE_TYPE = ".png";

	[DllImport(dllPath, EntryPoint = "Load", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool LoadP(string path, byte[] bytes, uint size);

	[DllImport(dllPath, EntryPoint = "Save", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool SaveP(byte[] bytes, uint size, string path);

	[DllImport(dllPath, EntryPoint = "GetSize", CallingConvention = CallingConvention.Cdecl)]
	private static extern uint GetSizeP(string path);

	[DllImport(dllPath, EntryPoint = "isAlive", CallingConvention = CallingConvention.Cdecl)]
	private static extern bool isAlive();

	// Load PNG image bytes
	public static bool Load(string path, byte[] bytes, uint size) {
		if ((size == 0) || (String.Equals(dllPath, "", StringComparison.Ordinal))) {
			return false;
		} else {
			return LoadP(path, bytes, size);
		}
	}

	// Save PNG bytes to the file
	public static bool Save(byte[] bytes, uint size, string path) {
		if ((size == 0) || (String.Equals (dllPath, "", StringComparison.Ordinal))) {
			return false;
		} else {
			return SaveP(bytes, size, path);
		}
	}

	// Return the size of the file
	public static uint GetSize(string path) {
		if (String.Equals (dllPath, "", StringComparison.Ordinal)) {
			return 0;
		} else {
			return GetSizeP(path);
		}
	}
}
