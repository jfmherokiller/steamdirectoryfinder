// mountfixhookinjector.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "detours.h"
using namespace std;;

int _tmain(int argc, _TCHAR* argv[])
{
	BOOL result = FALSE;
	STARTUPINFO si = { 0 };
	PROCESS_INFORMATION pi = { 0 };
	si.cb = sizeof(STARTUPINFO);
	DetourCreateProcessWithDllEx("mountfix.exe", NULL, NULL, NULL, FALSE, CREATE_SUSPENDED, NULL, NULL, &si, &pi, "mountfixhook.dll", NULL);
	//result = CreateProcess(NULL, "mountfix.exe", NULL, NULL, FALSE, CREATE_SUSPENDED, NULL, NULL, &si, &pi);
	//if (!result)
	//{
	//	MessageBox(0, "Process could not be loaded!", "Error", MB_ICONERROR);
	//	return -1;
	//}
	////Inject(pi.hProcess, "mountfixhook.dll");
	ResumeThread(pi.hThread);
	//DetourCreateProcessWithDllEx(L"mountfix.exe", NULL, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi, "mountfixhook.dll", NULL);
}