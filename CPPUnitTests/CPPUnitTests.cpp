#include "CppUnitTest.h"
#include "../CPlusPlus/node.h"
#include "../CPlusPlus/node.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

using namespace CPlusPlus;

namespace CPPUnitTests
{
	TEST_CLASS(CPPUnitTests)
	{
	public:
		
		TEST_METHOD(TestMethod1)
		{
			int i = 5;
			int *ptr = &i;

			Node<int> test = Node<int>(ptr);
			
			Assert::AreEqual(ptr, test.get_value());
			Assert::AreEqual(i, *test.get_value());
		}
	};
}
