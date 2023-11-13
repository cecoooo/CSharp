#include "Music.h"

Music::Music() {};
Music::Music(string contentType, string mediaFormat, int numOfItems, double price, string bandOrArtist)
{
	this->bandOrArtist = bandOrArtist;
};
Music::~Music() {};

string Music::getBandOrArtist() 
{
	return this->bandOrArtist;
}

string Music::getContentType() 
{
	return Item::getContentType();
}

string Music::getDatePurchased() 
{
	return Item::getDatePurchased();
}

string Music::getMediaFormat() 
{
	return Item::getMediaFormat();
}

double Music::getPrice() 
{
	return Item::getPrice();
}

string Music::getTitle() 
{
	return Item::getTitle();
}

void Music::playOnCD() 
{
	cout << "PLAYING ON CD...";
}

string Music::toString() 
{
	return Item::toString() + '\n' + this->bandOrArtist;
}