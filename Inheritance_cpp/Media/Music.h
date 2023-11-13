#pragma once
#include "Item.h"

class Music : public Item
{
private:
	string bandOrArtist;
public:
	Music();
	Music(string contentType, string mediaFormat, int numOfItems, double price, string bandOrArtist);
	~Music();
	string getBandOrArtist();
	string getContentType() override;
	string getDatePurchased() override;
	string getMediaFormat() override;
	double getPrice() override;
	string getTitle() override;
	void playOnCD();
	string toString() override;
};