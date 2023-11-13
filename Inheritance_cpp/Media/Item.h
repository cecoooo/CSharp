#pragma once
#include <string>
#include <map>
#include <iostream>
using namespace std;

struct Date
{
	int year;
	int month;
	int day;

	string toString()
	{
		string dayStr, monthStr, yearStr;
		if (day < 10)
			dayStr = '0' + to_string(day);
		else
			dayStr = to_string(day);
		if (month < 10)
			monthStr = '0' + to_string(month);
		else
			monthStr = to_string(month);
		yearStr = to_string(year);

		return dayStr + '/' + monthStr + '/' + yearStr;
	}
};

class Item
{
	enum MediaFormat {
		DVD,
		CD,
		Video
	};

private:
	string contentType;
	Date date;
	int itemId;
	MediaFormat mediaFormat;
	int numberOfItems;
	double price;
	string title;
	void virtual setMediaFormat(string format);
public:
	Item() {};
	Item(string contentType, string mediaFormat, int numOfItems, double price, string title);
	~Item();
	string virtual getContentType();
	string virtual getDatePurchased();
	int virtual getItemId();
	string virtual getMediaFormat();
	int virtual getNumberOfItems();
	double virtual getPrice();
	string virtual getTitle();
	void virtual setItemId(int id);
	void virtual setItemDate(int y, int m, int d);
	string virtual toString();
};