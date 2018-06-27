#pragma once
#include "header.h"

class Poisk
{
public:
	Poisk(void);

public:
	static BOOL CALLBACK DlgProc(HWND hWnd, UINT mes, WPARAM wp, LPARAM lp);
	static Poisk* ptr;
	void MessageAboutError(DWORD dwError);
	BOOL Cls_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam);
	void Cls_OnCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify);
	void Cls_OnClose(HWND hwnd);
	void GetDrivers();

	bool poisk1, poisk2;
	HWND hList, hStart, hStop, hKatolog, hListBox, hEditF, hEditT, hDialog, hStatics;
	HANDLE hProzes1, hProzes2;
	elem tem;
};