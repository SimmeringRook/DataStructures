#ifndef TEST_H
#define TEST_H

#include <string>
#include <fstream>
#include <ctime>

class Test
{
protected:
	std::string test_name;

	std::ofstream *logger;


public:
	Test(std::string);
	~Test();
};

#endif // !TEST_H
