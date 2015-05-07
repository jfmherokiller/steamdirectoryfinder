// mountfixhook.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "mountfixhook.h"
static BOOL(WINAPI * TrueShellExecuteExA)(SHELLEXECUTEINFOA* pExecInfo) = ShellExecuteExA;
static LSTATUS(WINAPI * TrueRegQueryValueEx)(
	_In_ HKEY hKey,
	_In_opt_ LPCSTR lpValueName,
	_Reserved_ LPDWORD lpReserved,
	_Out_opt_ LPDWORD lpType,
	_Out_writes_bytes_to_opt_(*lpcbData, *lpcbData) __out_data_source(REGISTRY) LPBYTE lpData,
	_When_(lpData == NULL, _Out_opt_)
	_When_(lpData != NULL, _Inout_opt_) LPDWORD lpcbData
	) = RegQueryValueEx;
MOUNTFIXHOOK_API LSTATUS HAXREGQuiry(
	_In_ HKEY hKey,
	_In_opt_ LPCSTR lpValueName,
	_Reserved_ LPDWORD lpReserved,
	_Out_opt_ LPDWORD lpType,
	_Out_writes_bytes_to_opt_(*lpcbData, *lpcbData) __out_data_source(REGISTRY) LPBYTE lpData,
	_When_(lpData == NULL, _Out_opt_)
	_When_(lpData != NULL, _Inout_opt_) LPDWORD lpcbData
	)
{
	OutputDebugString("Hooked Reghax");
	return false;
}

MOUNTFIXHOOK_API BOOL WINAPI HaxShellExecuteExA(_Inout_  SHELLEXECUTEINFO* pExecInfoa)
{
	OutputDebugString("Hooked ShellExecute");
	std::ofstream myfile;
	myfile.open("example.txt");
	myfile.write((const char*)pExecInfoa, sizeof(pExecInfoa));
	myfile.close();
	return TrueShellExecuteExA(pExecInfoa);
}

// This is the constructor of a class that has been exported.
// see mountfixhook.h for the class definition

extern "C" __declspec(dllexport) void Initialize()
{
	OutputDebugString("DLL Injection Successful!");
}

BOOL WINAPI DllMain(HINSTANCE hinst, DWORD dwReason, LPVOID reserved)
{
	if (DetourIsHelperProcess())
	{
		return TRUE;
	}

	if (dwReason == DLL_PROCESS_ATTACH)
	{
		DetourRestoreAfterWith();

		DetourTransactionBegin();
		DetourUpdateThread(GetCurrentThread());
		DetourAttach(&(PVOID&)TrueRegQueryValueEx, HAXREGQuiry);
		DetourAttach(&(PVOID&)TrueShellExecuteExA, HaxShellExecuteExA);
		DetourTransactionCommit();
		Initialize();
	}
	else if (dwReason == DLL_PROCESS_DETACH)
	{
		DetourTransactionBegin();
		DetourUpdateThread(GetCurrentThread());
		DetourDetach(&(PVOID&)TrueRegQueryValueEx, HAXREGQuiry);
		DetourDetach(&(PVOID&)TrueShellExecuteExA, HaxShellExecuteExA);
		DetourTransactionCommit();
	}

	return TRUE;
}