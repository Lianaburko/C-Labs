#include "triangle.h"
#include "pch.h"
#include <cmath>

using namespace std;

double _stdcall GetPerimetr(double a, double b, double c) {
    return a + b + c;
}

double _cdecl GetSquareBySideAndHeight(double a, double h) {
    return a * h / 2;
}

double _cdecl GetSquareBySides(double a, double b, double c) {
    double p = (a + b + c) / 2.0;
    double Sq = sqrt(p * (p - a) * (p - b) * (p - c));
    return Sq;
}

double _cdecl RadiusOfInscribedCircle(double a, double b, double c) {
    double p = (a + b + c) / 2.0;
    double Sq = sqrt(p * (p - a) * (p - b) * (p - c));
    double rad = 2 * Sq / (a + b + c);
    return rad;
}

double _cdecl RadiusOfDescribedCircle(double a, double b, double c) {
    double p = (a + b + c) / 2.0;
    double Sq = sqrt(p * (p - a) * (p - b) * (p - c));
    double rad = a * b * c / 4 / Sq;
    return rad;
}




