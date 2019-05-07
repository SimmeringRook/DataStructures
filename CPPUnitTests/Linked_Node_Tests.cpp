#include "CppUnitTest.h"
#include "Linked_Node_Tests.h"

#include "../CPlusPlus/Linked_Node.h"
#include "../CPlusPlus/Linked_Node.cpp"
#include "../CPlusPlus/node.cpp"

#include <string>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

using namespace CPlusPlus;
using namespace std;

namespace CPPUnitTests
{
	TEST_CLASS(Linked_Node_Tests)
	{
	public:

		TEST_METHOD(LinkedNode_HasDefault_Values)
		{
			Linked_Node<int> node = Linked_Node<int>();

			Assert::IsNull(node.value_ptr);
			Assert::IsNull(node.get_next());
		}

		TEST_METHOD(LinkedNode_Assigns_Value_Successfully)
		{
			//Arrange
			int value_to_assign = 1;
			Linked_Node<int> by_ptr;
			Linked_Node<int> by_constructor;

			//Act
			by_ptr.value_ptr = &value_to_assign;
			by_constructor = Linked_Node<int>(&value_to_assign);

			//Assert
			Assert::AreEqual(value_to_assign, *by_ptr.value_ptr);
			Assert::AreEqual(value_to_assign, *by_constructor.get_value());
		}

		TEST_METHOD(LinkedNode_Assigns_NextNode_Successfully)
		{
			//Arrange
			string a = "A";
			string b = "B";

			Linked_Node<string> node_a = Linked_Node<string>(&a);
			Linked_Node<string> node_b = Linked_Node<string>(&b);

			//Act
			node_b.insert(&node_a, NULL);

			//Assert
			Assert::IsNotNull(node_a.get_next());
			Assert::IsTrue(&node_b == node_a.get_next());
		}

		TEST_METHOD(LinkedNode_InsertsBetween_Successfully)
		{
			//Arrange
			string a = "A";
			string b = "B";
			string c = "C";

			Linked_Node<string> node_a = Linked_Node<string>(&a);
			Linked_Node<string> node_b = Linked_Node<string>(&b);
			Linked_Node<string> node_c = Linked_Node<string>(&c);

			node_c.insert(&node_a, NULL);

			//Act
			node_b.insert(&node_a, &node_c);

			//Assert
			Assert::IsFalse(&node_c == node_a.get_next());
			Assert::IsTrue(&node_b == node_a.get_next());
		}
	};
}