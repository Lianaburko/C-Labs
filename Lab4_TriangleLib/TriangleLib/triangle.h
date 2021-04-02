#pragma once

#ifdef TRIANGLEDLL_EXPORTS
#define DLLIMPORT_EXPORT __declspec(dllexport)
#else
#define DLLIMPORT_EXPORT __declspec(dllimport)
#endif

extern "C" {
	DLLIMPORT_EXPORT double _stdcall GetPerimetr(double a, double b, double c);
	DLLIMPORT_EXPORT double _cdecl GetSquareBySides(double a, double b, double c);
	DLLIMPORT_EXPORT double _cdecl GetSquareBySideAndHeight(double a, double h);
	DLLIMPORT_EXPORT double _cdecl RadiusOfInscribedCircle(double a, double b, double c);
	DLLIMPORT_EXPORT double _cdecl RadiusOfDescribedCircle(double a, double b, double c);
}