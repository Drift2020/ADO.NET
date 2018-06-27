
#include "Poisk.h"

using namespace std;

Poisk* Poisk::ptr = NULL;
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void poisk_size(TCHAR * put, long long & size, _wfinddata_t  fd){
	TCHAR  *Temp = new TCHAR[MAX_PATH];
	TCHAR  *Temp_put = new TCHAR[MAX_PATH];

	wcscpy(Temp, put);
	wcscpy(Temp_put, put);

	if (put[wcslen(put) - 1] == '*')
	{
		Temp_put[wcslen(put) - 1] = '\0';
		Temp_put[wcslen(Temp_put) - 1] = '\0';
	}
	
	else
	wcscat(Temp, L"\\*");


	int OK = _wfindfirst(Temp, &fd);
	int result = OK;
	while (result != -1)
	{
		if (wcscmp(fd.name, L".") != 0 && wcscmp(fd.name, L"..") != 0)
		{
			if (fd.attrib == 16)
			{

				TCHAR  *pathname = new TCHAR[MAX_PATH];
				wcscpy(pathname, Temp_put);
				wcscat(pathname, L"\\");
				wcscat(pathname, fd.name);
				wcscat(pathname, L"\\*");
				poisk_size(pathname, size, fd);
				delete[]pathname;
				
			}
			size += fd.size;
		}
		result = _wfindnext(OK, &fd);

	}
	delete []Temp;
	delete[] Temp_put;
	_findclose(OK);
}
void Size(long long & size, _wfinddata_t fd, TCHAR * Text_str1, TCHAR * way_file)
{
	TCHAR * Text_str = new TCHAR[200];
	wcscpy(Text_str, Text_str1);

	if (fd.attrib == 16 || fd.attrib == 17)
	{
		bool Znaki = false;
	
			for (int i = 0, len = wcslen(Text_str) - 1; i <= len; i++)
				Text_str[i] == '?' ? Znaki = true : 0;
		

		if (Znaki)
		{
			delete[]Text_str;
			Text_str = new TCHAR[MAX_PATH];

			wcscpy(Text_str, way_file);

			for (int len = wcslen(Text_str) - 1; Text_str[len] == '?';)
			{
				Text_str[len] = '\0';
				len = wcslen(Text_str) - 1;
			}
			wcscat(Text_str, fd.name);
			poisk_size(Text_str, size, fd);
			delete[]Text_str;
		}
		else if (fd.attrib & _A_SUBDIR&&way_file[wcslen(way_file) - 1] == '*'&&wcsstr(way_file, L".*") == NULL)/////////////////
		{
			delete[]Text_str;
			Text_str = new TCHAR[MAX_PATH];
			wcscpy(Text_str, way_file);
			Text_str[wcslen(Text_str) - 1] = '\0';
			wcscat(Text_str, fd.name);
			poisk_size(Text_str, size, fd);
			delete[]Text_str;
		}////////////////////////////////////////////////////////////////////////////////////////
		else if (fd.attrib & _A_SUBDIR && wcsstr(way_file, L".*") != NULL)
		{
			delete[]Text_str;
			Text_str = new TCHAR[MAX_PATH];
			wcscpy(Text_str, way_file);
			Text_str[wcslen(Text_str) - 1] = '\0';
			Text_str[wcslen(Text_str) - 1] = '\0';
			wcscat(Text_str, L"\\*");
			poisk_size(Text_str, size, fd);
			delete[]Text_str;
		}
		else
		{//////////////////////////////////////////////
			poisk_size(way_file, size, fd);
		}/////////////////////////////////////////////
		
	}
}
////////////////////////
bool Poisk_M(TCHAR * Text_str, _wfinddata_t fd)
{
	bool prov = true;

	if (wcscmp(Text_str, L".*") == 0)
	{
		return  true;
	}
	if (Text_str[wcslen(Text_str) - 1] == '?' || Text_str[0] == '?'&&wcsstr(Text_str, L".*") != 0)
	{
		int i = 0;
		for (int leg = wcslen(Text_str);
			i<leg&&Text_str[i] != '.';
			i++);
	
		int len=0;
		for (int leg = wcslen(fd.name); len < leg && fd.name[len] != '.'; len++);
	
		if (len<=i)
		{
			return  true;
		}
		else
			return  false;
	}
	else if (Text_str[0] == '?'&&wcsstr(Text_str, L".") != 0 && wcsstr(Text_str, L".*")==0 && wcslen(fd.name) <= wcslen(Text_str))
		{
			int i = 0, ii = 0;
			for (int leg = wcslen(Text_str);
				i<leg&&Text_str[i] != '.';
				i++);
			TCHAR *Mask = new TCHAR[wcslen(Text_str) - i];
			for (int leg = wcslen(Text_str);i <= leg;ii++, i++)
			{
				Mask[ii] = Text_str[i];
			}
			

			ii = 0;
			i = 0;
			for (int leg = wcslen(fd.name);
				i<leg&&fd.name[i] != '.';
				i++);
			TCHAR *Masks = new TCHAR[wcslen(fd.name) - i];
			for (int leg = wcslen(fd.name); i <= leg; ii++, i++)
			{
				Masks[ii] = fd.name[i];
			}
			

			if (wcscmp(Masks, Mask) == NULL)
			{
			
				return true;
			}
			
			return  false;
		}
	///////////////////////////////////////////////////////////
	if (wcslen(fd.name) >= wcslen(Text_str))
	{
		int  len_name = wcslen(fd.name) - 1, len_Text= wcslen(Text_str) - 1;
		int len = len_name - len_Text;
		if (fd.name[len] == '.')
		{
			for (int i = 0; len < len_name&&i < len_Text; len++, i++)
			{
				fd.name[len] != Text_str[i] ? prov = false : 0;
			}
		}
		else
			prov = false;
	} 
	else
		prov = false;
	///////////////////////////////////////////////////////////////
	 if (wcslen(fd.name) <= wcslen(Text_str) 
		&& Text_str[wcslen(Text_str) - 1] == '*'
		&& Text_str[wcslen(Text_str) - 2] == '.'||
		wcslen(fd.name) >= wcslen(Text_str)
		&& Text_str[wcslen(Text_str) - 1] == '*'
		&& Text_str[wcslen(Text_str) - 2] == '.')
	{
		TCHAR * temp = new TCHAR[200];
		TCHAR * temp1 = new TCHAR[200];
		int i = 0;
		for (; Text_str[i] != '.'; i++)
		{
			temp[i] = Text_str[i];
		}
		temp[i] = '\0';

		i = 0;
		int len = wcslen(fd.name);

		for (; i<len && fd.name[i] != '.'; i++)
			{
				temp1[i] = fd.name[i];
			}
		
		temp1[i] = '\0';

		if (wcscmp(temp, temp1) == 0)
		{
			prov = true;
		}
		else
			prov = false;
		
		delete []temp;
		delete []temp1;
		
	}
	//////////////////////////////////////////////////////////////
	return prov;
}
////////////////////////
void Put(_wfinddata_t fd,TCHAR *& PUT, TCHAR *way_file)
{
	wcscpy(PUT, way_file);
	if (PUT[wcslen(PUT) - 1] == '*')
	{
		PUT[wcslen(PUT) - 1] = '\0';
		if (PUT[wcslen(PUT) - 2] == '\\')
			PUT[wcslen(PUT) - 1] = '\0';
	}
	if (PUT[wcslen(PUT) - 1] == '\\')
	wcscat(PUT, fd.name);
	if (PUT[wcslen(PUT) - 1] == '.')
	{
		for (; PUT[wcslen(PUT) - 1] != '\\';)
		{
			PUT[wcslen(PUT) - 1] = '\0';
		}
		wcscat(PUT, fd.name);
	}
	bool prow = false;
	for (int i = wcslen(PUT)-1; PUT[i] != '\\';i--)
	if (PUT[i] == '?')
	{
		for (; PUT[wcslen(PUT) - 1] != '\\';)
		{
			PUT[wcslen(PUT) - 1] = '\0';
		}
		wcscat(PUT, fd.name);
	}
}
void Prift_elem_list(elem *temp, _wfinddata_t fd, long long &coutns, TCHAR *way_file, TCHAR *Text_str)
{
	long long size = 0;
	TCHAR *buffer = new TCHAR[MAX_PATH];
	TCHAR * times;
	LVITEM item;
	memset(&item, 0, sizeof(LVITEM));
	item.mask = LVIF_TEXT | LVIF_COLUMNS | LVIF_COLFMT;
	item.pszText = fd.name;
	item.iItem = 0;
	ListView_InsertItem(*temp->hList, &item);

	TCHAR *PUT = new TCHAR[MAX_PATH];
	Put(fd, PUT, way_file);

	ListView_SetItemText(*temp->hList, item.iItem, 1, PUT);

	size = fd.size;
	////////////////////////////////////////////////////////////////////////////////
	Size(size, fd, Text_str, way_file/*, P*/);
	//////////////////////////////////////////////////////////////////////////////

	_i64tow(size, buffer, 10);
	ListView_SetItemText(*temp->hList, item.iItem, 2, buffer);

	
	//delete []buffer;

	times = new TCHAR[MAX_PATH];

	_wctime_s(times, 30, &fd.time_write);
	ListView_SetItemText(*temp->hList, item.iItem, 3, times);


	TCHAR * STATIC = new TCHAR[200];
	coutns++;
	_i64tow(coutns, STATIC, 10);
	SetWindowText(*temp->hStatics, STATIC);
	//delete[]STATIC;
	delete[]buffer;
	delete[]times;
}
static long long coutns1 = 0;
bool Poisk_Text_File(TCHAR * Text_FILE, TCHAR * PUT, _wfinddata_t fd)
{
	char* Text_FILEs = new char[wcslen(Text_FILE)];
	CharToOem(Text_FILE, Text_FILEs);

	if (fd.size == 0)
		return 0;

	ifstream in(PUT);
	if (!in.is_open())
	{
		MessageBox(0, L"Error open file", TEXT("Поисковик"), MB_YESNO | MB_ICONINFORMATION);
		return 0;
	}


	while (!in.eof()) // цикл продолжается до тех пор, пока не наступит конец файла
	{
		char buf[200];

		in.getline(buf, 200);

		if (strstr(buf, Text_FILEs) != NULL)
		{

			in.close();
			return 1;
		}



	}

	//delete[]Text_FILEs;
	in.close();

	return 0;
}
void Poisk_pod(TCHAR * put, TCHAR * Text_str, _wfinddata_t  fd, elem *temp)
{

	TCHAR  *Temp = new TCHAR[MAX_PATH];
	TCHAR  *Temp_put = new TCHAR[MAX_PATH];
	wcscpy(Temp, put);
	wcscpy(Temp_put, put);
	////////////////////////////////////////////////////



	if (put[wcslen(put) - 1] == '*'&&put[wcslen(put) - 2] == '\\')
	{
		Temp_put[wcslen(put) - 1] = '\0';
	}
	else if (put[wcslen(put) - 1] == '*'&&put[wcslen(put) - 2] == '.'&&fd.attrib & _A_SUBDIR)
	{
		Temp_put[wcslen(put) - 1] = '\0';
		Temp_put[wcslen(put) - 2] = '\0';

		if (Temp_put[wcslen(Temp_put) - 1] == '?')
		{
			while (Temp_put[wcslen(Temp_put) - 1] != '\\')
				Temp_put[wcslen(Temp_put) - 1] = '\0';

		}
	}
	
	else if (wcschr(Temp_put,'?'))
	{
		while (Temp_put[wcslen(Temp_put) - 1] != '\\')
			Temp_put[wcslen(Temp_put) - 1] = '\0';
	}
	else
		wcscat(Temp, L"\\*");



	//////////////////////////////////////////

	
	int OK = _wfindfirst(Temp, &fd);
	int result = OK;


	//////////////////////////////////////////


	TCHAR pUt[200];
	wcscpy(pUt, Temp);
  	while (pUt[wcslen(pUt) - 1] != '\\'){
		pUt[wcslen(pUt) - 1] = '\0';
	}
	wcscat(pUt, Text_str);

	_wfinddata_t  fd_t;
	int OKS =_wfindfirst(pUt, &fd_t);
	int results = OKS;


	///////////////////////////////////////////////////////////////////////////////////////



//	while (result != -1)
	while (results != -1)
	{
		if (wcscmp(fd_t.name, L".") != 0 && wcscmp(fd_t.name, L"..") != 0)
		{
			
			if (wcscmp(fd_t.name, Text_str) == 0 || Poisk_M(Text_str, fd_t) || Text_str[0] == '*')
			{

				bool TEXT_FILE=false;
				TCHAR Text_FILE[MAX_PATH];
				if (GetWindowText(*temp->hEditT, Text_FILE, MAX_PATH) != 0)
				{
					TEXT_FILE = true;
				}
				TCHAR *PUT = new TCHAR[200];
				Put(fd_t, PUT, put);

				if (TEXT_FILE == true ? Poisk_Text_File(Text_FILE, PUT, fd_t) : true)
				Prift_elem_list(temp, fd_t, coutns1, put, Text_str);
			}


		}

	//	result = _wfindnext(OK, &fd);
		results = _wfindnext(OKS, &fd_t);
	}


	///////////////////////////////////////////////////////////////////////////////////
	OK = _wfindfirst(Temp, &fd);
	result = OK;

	/////////////////////////////////////////////////////////////////////////////////
	while (result != -1)
	{
		if (wcscmp(fd.name, L".") != 0 && wcscmp(fd.name, L"..") != 0)
		{
			if (fd.attrib == 16)
			{

				TCHAR  *pathname = new TCHAR[MAX_PATH];
				wcscpy(pathname, Temp_put);

				if (pathname[wcslen(pathname) - 1] == '\\')
					wcscat(pathname, fd.name);
				else
				{
					wcscat(pathname, L"\\");
					wcscat(pathname, fd.name);
				}


				wcscat(pathname, L"\\*");

			

				Poisk_pod(pathname, Text_str, fd, temp);
				delete[]pathname;
				
			}
			
		}
		result = _wfindnext(OK, &fd);
		
	}
	/////////////////////////////////////////////////////////////////////////////////////
	delete[]Temp;
	delete[] Temp_put;
	
	_findclose(OK);
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
DWORD WINAPI Thread(LPVOID lp)
{
	
	elem *temp;
	temp = (struct elem*)lp;

	_wfinddata_t fd;
	TCHAR * Driver = new TCHAR[MAX_PATH];
	TCHAR * way_file= new TCHAR[MAX_PATH];
	TCHAR *  Text_str = new TCHAR[MAX_PATH];
	TCHAR *  Text_FILE = new TCHAR[MAX_PATH];
	bool  attrib = false,TEXT_FILE=false;//поиск
	
	long long coutns = 0;
	

	if (GetWindowText(*temp->hEditT, Text_FILE, MAX_PATH) != 0)
	{
		TEXT_FILE = true;
	}
	
	GetWindowText(*temp->hListBox, Driver, MAX_PATH);
	wcscpy(way_file, Driver);

	if (GetWindowText(*temp->hEditF, Text_str, MAX_PATH) != 0)
	{
		if (Text_str[0] != '.')
		{
			if (Text_str[wcslen(Text_str) - 1] != '*'&&Text_str[wcslen(Text_str) - 2] != '.'&&Text_str[0]!='?')
			{

				wcscat(way_file, Text_str);
				wcscat(way_file, L".*");
			}
			else
				wcscat(way_file, Text_str);
		}
		else
		{
			attrib = true;
			wcscat(way_file, L"\\*");
		}
	
	}
	else
		return 0;


	int OK = _wfindfirst(way_file, &fd);
	int result = OK;
	
	while (result != -1)
	{
	
		int i = wcscmp(fd.name, L"."), ii = wcscmp(fd.name, L"..");
		if (i != 0 && ii != 0 && !attrib)
		{
			TCHAR *PUT = new TCHAR[200];
			Put(fd, PUT, way_file);
			
			if (TEXT_FILE == true ? fd.attrib & _A_SUBDIR ? false :Poisk_Text_File(Text_FILE, PUT, fd) : true)
				Prift_elem_list(temp, fd, coutns, way_file, Text_str);

			
		
		}
		else if (i != 0 && ii != 0 && Poisk_M(Text_str, fd))
		{
			TCHAR *PUT = new TCHAR[200];
			Put(fd, PUT, way_file);
			
			if (TEXT_FILE == true ? Poisk_Text_File(Text_FILE, PUT, fd) : true)
			Prift_elem_list(temp, fd, coutns,  way_file, Text_str);

			
			
		}
		
		result = _wfindnext(OK, &fd);

	}

	_findclose(OK);

	MessageBox(0, L"Вторичный поток завершил работу!", L"Многопоточность", MB_OK);
	//delete temp;
	delete []Driver;
	delete[]way_file;
	delete[]Text_str;
	delete[]Text_FILE;
	
	return 0;
}
DWORD WINAPI Thread_popap(LPVOID lp)
{
	///////////////////////////////////////////////////////////////////////////////////
	elem *temp;
	temp = (struct elem*)lp;

	_wfinddata_t fd;
	
	TCHAR * Driver = new TCHAR[MAX_PATH];
	TCHAR * way_file = new TCHAR[MAX_PATH];
	TCHAR *  Text_str = new TCHAR[MAX_PATH];
	
	bool P = false, attrib = false;//поиск
	long long size = 0;
	TCHAR *buffer;
	buffer = new TCHAR[MAX_PATH];

	////////////////////////////////////////////////////////////////////////////////
	GetWindowText(*temp->hListBox, Driver, MAX_PATH);
	wcscpy(way_file, Driver);


	if (GetWindowText(*temp->hEditF, Text_str, MAX_PATH) != 0)
	{
		if (Text_str[0] != '.')
			wcscat(way_file, L"\\*");
			//wcscat(way_file, Text_str);
		else
		{
			attrib = true;
			wcscat(way_file, L"\\*");
		}

		if (way_file[wcslen(way_file) - 1] != '*')
			P = true;
	}
	else
		wcscat(way_file, L"\\*");


	if (wcschr(Text_str, L'.')==NULL)
		if (Text_str[wcslen(Text_str) - 1] != '*'&&Text_str[wcslen(Text_str) - 2] != '.')
	{
		wcscat(Text_str, L".*");
	}
	
	int OK = _wfindfirst(way_file, &fd);
	int result = OK;

		///////////////////////////////////////////////////////////////////////////////////////////////////
	

			if (wcscmp(fd.name, L".") != 0 && wcscmp(fd.name, L"..") != 0 && !attrib)
			{
				Poisk_pod(way_file, Text_str, fd, temp);

			}
			else if (wcscmp(fd.name, L".") != 0 && wcscmp(fd.name, L"..") != 0)
			{
				Poisk_pod(way_file, Text_str, fd, temp);

			}
			
			

		
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	delete [] Driver;
	
	delete[] way_file;
	
	delete[]  Text_str;
	
	delete[]buffer;
	
	coutns1 = 0;
	_findclose(OK);
	MessageBox(0, L"Вторичный поток завершил работу!", L"Многопоточность", MB_OK);
	return 0;
}
Poisk::Poisk(void)
{
	ptr = this;
}

void Poisk::Cls_OnClose(HWND hwnd)
{
	EndDialog(hwnd, 0);
}
void Poisk::MessageAboutError(DWORD dwError)
{
	LPVOID lpMsgBuf = NULL;
	TCHAR szBuf[80];
	BOOL fOK = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM//флаг сообщает функции, что нужна строка, соответствующая коду ошибки, определённому в системе
		| FORMAT_MESSAGE_ALLOCATE_BUFFER, NULL,//нужно выделить соответствующий блок памяти для хранения текста
		dwError,//код ошибки
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),//язык, на котором выводится описание ошибки (язык пользователя по умолчанию)
		(LPTSTR)&lpMsgBuf,//адрес выделенного блока памяти записывается в эту переменную
		0,//минимальный размер буфера для выделения памяти
		NULL);
	if (lpMsgBuf != NULL)
	{
		wsprintf(szBuf, TEXT("Ошибка %d: %s"), dwError, lpMsgBuf);
		MessageBox(hDialog, szBuf, TEXT("Сообщение об ошибке"), MB_OK | MB_ICONSTOP);
		LocalFree(lpMsgBuf);
	}
}
void Poisk::GetDrivers()
{
	int Resurt = SendMessage(hListBox, CB_GETCOUNT, 0, 0);
	if (Resurt > 0)
	{
		SendMessage(hListBox, CB_RESETCONTENT, 0, 0);
	}
	TCHAR * strl = nullptr;
	DWORD dr = GetLogicalDrives();
	for (int i = 0, n; i < 26; i++)
	{
		n = ((dr >> i) & 0x00000001);
		if (n == 1)
		{
			strl = new TCHAR[5];
			wsprintf(strl, L"%c:\\", 65 + i);
			TCHAR * str = new TCHAR[50];
			wcscpy(str, strl);
			SendMessage(hListBox, CB_ADDSTRING, 0, LPARAM(str));
		}
	}
}
BOOL Poisk::Cls_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam)
{
	// Получим дескрипторы элементов управлени

	hList = GetDlgItem(hwnd, IDC_LIST1);
	hStart = GetDlgItem(hwnd, IDOK);
	hStop = GetDlgItem(hwnd, IDCANCEL);
	hKatolog = GetDlgItem(hwnd, IDC_CHECKs);
	hListBox = GetDlgItem(hwnd, IDC_COMBO1);
	hEditF = GetDlgItem(hwnd, IDC_EDIT1);
	hEditT = GetDlgItem(hwnd, IDC_EDIT2);
	hStatics = GetDlgItem(hwnd, IDC_STATICj);
	hDialog = hwnd;

	tem.hEditF = &hEditF;
	tem.hEditT = &hEditT;
	tem.hList = &hList;
	tem.hListBox = &hListBox;
	tem.hStatics = &hStatics;


	LV_COLUMN lvColumn;
	memset(&lvColumn, 0, sizeof(LV_COLUMN));

	DWORD dwStyle = GetWindowLong(hList, GWL_STYLE);
	SetWindowLong(hList, GWL_STYLE, dwStyle | LVS_REPORT);

	ListView_SetExtendedListViewStyleEx(hList,
		LVS_EX_GRIDLINES, LVS_EX_GRIDLINES);
	ListView_SetExtendedListViewStyleEx(hList,
		LVS_EX_FULLROWSELECT, LVS_EX_FULLROWSELECT);

	lvColumn.mask = LVCF_FMT | LVCF_WIDTH | LVCF_TEXT;
	lvColumn.fmt = LVCFMT_LEFT;
	lvColumn.cx = 120;

	lvColumn.pszText = TEXT("Имя файла");
	ListView_InsertColumn(hList, 0, &lvColumn);

	lvColumn.cx = 350;
	lvColumn.pszText = L"Папка";
	ListView_InsertColumn(hList, 1, &lvColumn);

	lvColumn.cx = 75;
	lvColumn.pszText = L"Размер";
	ListView_InsertColumn(hList, 2, &lvColumn);

	lvColumn.cx = 95;
	lvColumn.pszText = L"Дата изменения";
	ListView_InsertColumn(hList, 3, &lvColumn);

	GetDrivers();
	return TRUE;
}

void Poisk::Cls_OnCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify)
{
	switch (id)
	{
	case IDOK:
		if (poisk1)
		{
			SetWindowText(hStatics, L"0");
			poisk1 = false;
			TerminateThread(hProzes1, 0);
			CloseHandle(hProzes1);
			coutns1 = 0;
		}
		else if (poisk2)
		{
			SetWindowText(hStatics, L"0");
			poisk2 = false;
			TerminateThread(hProzes2, 0);
			CloseHandle(hProzes2);
			coutns1 = 0;
		}

		if (SendMessage(hKatolog, BM_GETCHECK, 0, 0))
		{
			SetWindowText(hStatics, L"0");
			ListView_DeleteAllItems(hList);
			hProzes2=CreateThread(nullptr, 0, Thread_popap, &tem, 0, nullptr);
			poisk2 = true;
		}
		else
		{
			

			SetWindowText(hStatics, L"0");
			ListView_DeleteAllItems(hList);
			hProzes1=CreateThread(nullptr, 0, Thread, &tem, 0, nullptr);
			poisk1 = true;
		}
		break;
	case	IDCANCEL:
		if (poisk2)
		{
			//SetWindowText(hStatics, L"0");
			poisk2 = false;
			TerminateThread(hProzes2, 0);
			CloseHandle(hProzes2);
			coutns1 = 0;
		}
		if (poisk1)
		{
			//SetWindowText(hStatics, L"0");
			poisk1 = false;
			TerminateThread(hProzes1, 0);
			CloseHandle(hProzes1);
			coutns1 = 0;
		}
		break;
	default:

		break;
	}


}

BOOL CALLBACK Poisk::DlgProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
		HANDLE_MSG(hwnd, WM_CLOSE, ptr->Cls_OnClose);
		HANDLE_MSG(hwnd, WM_INITDIALOG, ptr->Cls_OnInitDialog);
		HANDLE_MSG(hwnd, WM_COMMAND, ptr->Cls_OnCommand);
	}
	return FALSE;
}