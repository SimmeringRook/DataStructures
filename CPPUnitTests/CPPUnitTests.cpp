#include "CppUnitTest.h"
#include "../CPlusPlus/node.h"
#include "../CPlusPlus/node.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

using namespace DataStructures::CPlusPlus::Nodes;

namespace CPPUnitTests
{
	TEST_CLASS(CPPUnitTests)
	{
	public:
		
		TEST_METHOD(TestMethod1)
		{
			int i = 5;
			int *ptr = &i;

			Node<int> test = Node<int>(i);
			
			Assert::AreEqual(i, *test.get_value());
		}
	};
}
