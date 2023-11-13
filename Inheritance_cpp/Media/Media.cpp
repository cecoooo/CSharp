#include <iostream>
#include <string>
#include "Item.h"
#include "Game.h";
#include "Movie.h";
#include "Music.h";
using namespace std;

int main()
{
	string content = "Best Content type ever.";
	string type = "DVD";
	string title = "Alo.bg";
	int num = 5;
	double price = 123.23;
	int rating = 5;
	/*Item* item = new Item(content, type, num, price, title);
	item->setItemDate(2000, 9, 1);
	item->setItemId(234214);
	cout << item->toString();
	delete item;*/

	string content1 = "Best Content type ever. 1";
	string type1 = "DVD 1";
	string title1 = "Alo.bg 1";
	int num1 = 51;
	double price1 = 111.11;
	string bandOrArtist = "Mia Khalifa";
	int rating1 = 51;

	//Game* game = new Game(content, type, num, price, title, rating);
	//cout << game->toString();

	//Item* ptr = new Game(content, type, num, price, title, rating);
	Music* music = new Music(content, type, num, price, bandOrArtist);
}