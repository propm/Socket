#ifndef __CLIENT_H__
#define __CLIENT_H__

extern "C"
{
	__declspec(dllexport) bool __stdcall setup();

	__declspec(dllexport) int __stdcall update();

	__declspec(dllexport) void __stdcall close();
}

#endif