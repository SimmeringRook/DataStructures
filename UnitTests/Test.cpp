#include "Test.h"

using namespace std;

Test::Test(string testname)
{
	this->test_name = testname;
	this->logger = &ofstream(this->test_name, ios::out);
};


Test::~Test()
{
	this->logger = NULL;
};
