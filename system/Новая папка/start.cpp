#include "Poisk.h"
int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrev, LPTSTR lpszCmdLine, int nCmdShow)
{

	Poisk dlg;
	return DialogBox(hInst, MAKEINTRESOURCE(IDD_DIALOG1), NULL, Poisk::DlgProc);

}
/*TCHAR *temp = new TCHAR[200];
for (int i = 0; Text_str[i] != '.'; i++)
{
temp[i] = Text_str[i];
}
if (wcscmp(temp, fd.name) == 0)
{
prov = true;
}*/