#include "Game.h"

Game::Game(string contentType, string mediaFormat, int numOfItems, double price, 
	string title, double rating) :Item(contentType, mediaFormat, numOfItems, price, title)
{
	this->rating = rating;
};
Game::~Game() {}
string Game::getContentType() 
{
	return Item::getContentType();
}

string Game::getDatePurchased() 
{
	return Item::getDatePurchased();
}

string Game::getMediaFormat() 
{
	return Item::getMediaFormat();
}

double Game::getPrice() 
{
	return Item::getPrice();
}

string Game::getTitle() 
{
	return Item::getTitle();
}

string Game::getDifficultyLevel()
{
	switch (this->difficultyLevel)
	{
	case Easy: return "Easy"; break;
	case Medium: return "Medium"; break;
	case Hard: return "Hard"; break;
	case VeryHard: return "Very Hard"; break;
	default: return "DIFFICULTY LEVEL NOT SET UP."; break;
	}
}

int Game::getRating()
{
	return this->rating;
}

void Game::playOnCD()
{
	cout << "PLAYING ON CD...";
}

void Game::playOnDVD()
{
	cout << "PLAYING ON DVD...";
}

string Game::toString() 
{
	string diffLevel = getDifficultyLevel();
	return Item::toString() + '\n' + diffLevel +'\n' + to_string(this->rating);
}
