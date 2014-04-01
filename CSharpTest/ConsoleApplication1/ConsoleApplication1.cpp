// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

class B
{
public:
	void DoSome()
	{

	}
};

template<typename T>
class A
{
public:
	T DoSome(T val)
	{
		val.DoSome();
		return val;	
	}
};

int _tmain(int argc, _TCHAR* argv[])
{
	A<B> a;
	B b;
	a.DoSome(b);
}

