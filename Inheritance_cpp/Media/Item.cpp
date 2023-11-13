#include "Item.h"

Item::Item(string contentType, string mediaFormat, int numOfItems, double price, string title)
{
	this->contentType = contentType;
	setMediaFormat(mediaFormat);
	this->numberOfItems = numOfItems;
	this->price = price;
	this->title = title;
}

Item::~Item()
{

}

string Item::getContentType()
{
	return this->contentType;
}

string Item::getDatePurchased()
{
	return date.toString();
}

int Item::getItemId()
{
	return this->itemId;
}

string Item::getMediaFormat()
{
	switch (this->mediaFormat)
	{
	case DVD: return "DVD"; break;
	case CD: return "CD"; break;
	case Video: return "Video"; break;
	default: return "MEDIA FORMAT NOT SET UP."; break;
	}
}

int Item::getNumberOfItems()
{
	return this->numberOfItems;
}

double Item::getPrice()
{
	return this->price;
}

string Item::getTitle()
{
	return this->title;
}

void Item::setItemId(int id)
{
	this->itemId = id;
}

void Item::setItemDate(int y, int m, int d)
{
	this->date.year = y;
	this->date.month = m;
	this->date.day = d;
}

void Item::setMediaFormat(string format) {
	if (format.compare("DVD"))
		mediaFormat = DVD;
	else if (format.compare("CD"))
		mediaFormat = CD;
	else if (format.compare("Video"))
		mediaFormat = Video;
	else {
		cout << "Invaid Media Format.";
		exit(-1);
	}
}

string Item::toString()
{
	return contentType + '\n' +
		date.toString() + '\n' +
		to_string(itemId) + '\n' +
		getMediaFormat() + '\n' +
		to_string(numberOfItems) + '\n' +
		to_string(price) + '\n' +
		title;
}