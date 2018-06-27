#pragma once
#define _CRT_SECURE_NO_WARNINGS
#define _AFXDLL
#include <fstream>
#include <afxcmn.h>
#include <tchar.h>
#include <windows.h>
#include <tlhelp32.h>
#include <windowsX.h>
#include <string>
#include <iomanip>
#include <ctime>
#include <io.h>
#include "resource.h"
struct elem{
	HWND * hList;
	HWND * hListBox;
	HWND * hEditF;
	HWND * hEditT;
	HWND * hStatics;
};
