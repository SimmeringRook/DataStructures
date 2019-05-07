#include "CppUnitTest.h"
#include "../node.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest1
{
	TEST_CLASS(UnitTest1)
	{
	public:
		
		TEST_METHOD(TestMethod1)
		{
			int i = 5;
			int* i_ptr = &i;

			Node<int> myNode = Node<int>(i_ptr);
			
			Assert::AreEqual(myNode.get_value(), i_ptr);
			Assert::AreEqual(*myNode.get_value(), i);
		}
	};
}
