#pragma once
#include "Item.h"
#include "string"

class Game: public Item
{
	enum DifficultyLevel
	{
		Easy,
		Medium,
		Hard,
		VeryHard
	};

private:
	DifficultyLevel difficultyLevel;
	int rating;
public:
	Game() {};
	Game(string contentType, string mediaFormat, int numOfItems, double price, string title, 
		double rating);
	~Game();
	string getContentType() override;
	string getDatePurchased() override;
	string getDifficultyLevel();
	int getRating();
	string getMediaFormat() override;
	double getPrice() override;
	string getTitle() override;
	void playOnCD();
	void playOnDVD();
	string toString() override;
};

