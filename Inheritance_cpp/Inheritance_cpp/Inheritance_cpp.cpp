#include <iostream>
using namespace std;

class Car
{
private:
	string brand;
	double tankVolume;
	int wheels;
	int maxSpeedKmH;
public:
	Car(int maxsp);
	~Car();
	int virtual getMaxSpeed();
};

Car::Car(int maxsp)
{
	this->maxSpeedKmH = maxsp;
	cout << "Constructor base class" << endl;
}

Car::~Car()
{
	cout << "Destructor base class." << endl;
}

int Car::getMaxSpeed()
{
	return maxSpeedKmH;
}

class BMW: public Car
{
private:
	int maxSpeedKmH;
public:
	BMW(int maxsp);
	~BMW();
	int getMaxSpeed() override;

};

BMW::BMW(int maxsp) : Car(maxsp)
{
	this->maxSpeedKmH = maxsp;
	cout << "Constructor derived class." << endl;
}

BMW::~BMW()
{
	cout << "Destructor derived class." << endl;
}

int BMW::getMaxSpeed() 
{
	return maxSpeedKmH;
}



int main()
{
	BMW* bmw = new BMW(220);
	int maxspeed = bmw->getMaxSpeed();
	cout << maxspeed << endl;
}