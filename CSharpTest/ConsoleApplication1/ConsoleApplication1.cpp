// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
class A
{
public:
	int field;
};

int _tmain(int argc, _TCHAR* argv[])
{
	A a;
	auto b = &a;
	return 0;
}

