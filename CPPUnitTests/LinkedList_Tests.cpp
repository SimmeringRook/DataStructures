#include "CppUnitTest.h"
#include "LinkedList_Tests.h"

#include "../CPlusPlus/Linked_Node.h"
#include "../CPlusPlus/Linked_Node.cpp"
#include "../CPlusPlus/node.cpp"

#include "../CPlusPlus/LinkedList.h"
#include "../CPlusPlus/LinkedList.cpp"

#include <iostream>
#include <string>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

using namespace DataStructures::CPlusPlus::Nodes;
using namespace DataStructures::CPlusPlus::Lists;

using namespace std;

namespace CPPUnitTests
{
	TEST_CLASS(LinkedList_Tests)
	{
	public:

		TEST_METHOD(LinkedList_Adds_TwoValues_Successfully)
		{
			//Arrange
			int a = 1;
			int b = 2;

			LinkedList<int> list = LinkedList<int>();

			//Act
			list.add(a);
			list.add(b);

			for (int i = 0; i < list.count(); i++)
			{
				int n = *list[i];
				string s = to_string(n) + "\n";
				Logger::WriteMessage(s.c_str());
			}

			//Assert
			Assert::AreEqual(b, *list[1]);
			Assert::AreEqual(2, list.count());
		}

		TEST_METHOD(LinkedList_Adds_ThreeValues_Successfully)
		{
			//Arrange
			int a = 1;
			int b = 2;
			int c = 3;

			LinkedList<int> list = LinkedList<int>();
			list.add(a);
			list.add(b);

			//Act
			list.add(c);

			for (int i = 0; i < list.count(); i++)
			{
				int n = *list[i];
				string s = to_string(n) + "\n";
				Logger::WriteMessage(s.c_str());
			}

			//Assert
			Assert::AreEqual(c, *list[2]);
			Assert::AreEqual(3, list.count());
		}

		TEST_METHOD(LinkedList_Adds_Collection_Successfully)
		{
			//Arrange
			int size = 3;
			int* int_array = new int[size];
			for (int i = 0; i < 3; i++)
			{
				int n = i + 1;
				string s = to_string(n) + "\n";
				Logger::WriteMessage(s.c_str());
				int_array[i] = n;
			}
				

			LinkedList<int> list = LinkedList<int>();

			//Act
			list.add_range(int_array, size);

			//Assert
			Assert::AreEqual(size, list.count());

			for (int i = 0; i < size; i++)
			{
				string s = "Expected: " + to_string(int_array[i]) + "\n";
				Logger::WriteMessage(s.c_str());

				int expected = int_array[i];
				int actual = *list[i];

				s = "actual: " + to_string(actual) + "\n";
				Logger::WriteMessage(s.c_str());

				Assert::AreEqual(expected, actual);
			}

			delete[] int_array;
			int_array = NULL;
		}

		TEST_METHOD(LinkedList_To_Array_Successfully)
		{
			//Arrange
			int size = 3;
			int* int_array = new int[size];

			for (int i = 0; i < 3; i++)
			{
				int_array[i] = i + 1;
			}

			LinkedList<int> original = LinkedList<int>();
			original.add_range(int_array, size);

			//Act
			int* as_array = original.to_array();

			//Assert

			for (int i = 0; i < size; i++)
			{
				int expected = *original[i];
				int actual = as_array[i];

				string s = "Expected: " + to_string(expected) + "\n";
				Logger::WriteMessage(s.c_str());

				s = "actual: " + to_string(actual) + "\n";
				Logger::WriteMessage(s.c_str());

				Assert::AreEqual(expected, actual);
			}

			delete[] int_array;
			delete[] as_array;

			int_array = NULL;
			as_array = NULL;
		}

		TEST_METHOD(LinkedList_Copies_Successfully)
		{
			//Arrange
			int size = 3;
			int* int_array = new int[size];
			for (int i = 0; i < 3; i++)
			{
				int n = i + 1;
				string s = to_string(n) + "\n";
				Logger::WriteMessage(s.c_str());
				int_array[i] = n;
			}

			LinkedList<int> original = LinkedList<int>();
			original.add_range(int_array, size);
			
			//Act
			LinkedList<int> copied = original;

			//Assert
			Assert::AreEqual(copied.count(), original.count());

			for (int i = 0; i < size; i++)
			{
				int expected = *original[i];
				int actual = *copied[i];

				string s = "Expected: " + to_string(expected) + "\n";
				Logger::WriteMessage(s.c_str());

				s = "actual: " + to_string(actual) + "\n";
				Logger::WriteMessage(s.c_str());

				Assert::AreEqual(expected, actual);
			}

			delete[] int_array;
			int_array = NULL;
		}

		TEST_METHOD(LinkedList_Removes_Value_Successfully)
		{
			//Arrange
			int size = 3;
			int* int_array = new int[size];

			for (int i = 0; i < 3; i++)
				int_array[i] = i + 1;

			LinkedList<int> list = LinkedList<int>();
			list.add_range(int_array, size);

			//Act
			list.remove(1);

			//Assert
			Assert::AreEqual(size - 1, list.count());

			for (int i = size - 2; i > 0; i--)
			{
				int expected = int_array[i+1];
				int actual = *list[i];

				string s = "Expected: " + to_string(expected) + "\n";
				s += "actual: " + to_string(actual) + "\n";
				Logger::WriteMessage(s.c_str());

				Assert::AreEqual(expected, actual);
			}

			delete[] int_array;
			int_array = NULL;
		}

		TEST_METHOD(LinkedList_Removes_ValueAtIndex_Successfully)
		{
			//Arrange
			int size = 3;
			int* int_array = new int[size];

			for (int i = 0; i < 3; i++)
				int_array[i] = i + 1;

			LinkedList<int> list = LinkedList<int>();
			list.add_range(int_array, size);

			//Act
			list.remove_at(1);

			//Assert
			Assert::AreEqual(size - 1, list.count());

			Assert::AreEqual(int_array[0], *list[0]);
			Assert::AreEqual(int_array[2], *list[1]);

			delete[] int_array;
			int_array = NULL;
		}

		TEST_METHOD(LinkedList_Removes_Range_Successfully)
		{
			//Arrange
			int size = 3;
			int* int_array = new int[size];

			for (int i = 0; i < 3; i++)
				int_array[i] = i + 1;

			LinkedList<int> list = LinkedList<int>();
			list.add_range(int_array, size);

			//Act
			list.remove_range(0, 2);

			//Assert
			Assert::AreEqual(size - 2, list.count());

			Assert::AreEqual(int_array[2], *list[0]);

			delete[] int_array;
			int_array = NULL;
		}

		TEST_METHOD(LinkedList_Clears_Successfully)
		{
			//Arrange
			int size = 3;
			int* int_array = new int[size];

			for (int i = 0; i < 3; i++)
				int_array[i] = i + 1;

			LinkedList<int> list = LinkedList<int>();
			list.add_range(int_array, size);

			Assert::AreEqual(size, list.count());

			//Act
			list.clear();

			//Assert
			Assert::AreEqual(0, list.count());

			delete[] int_array;
			int_array = NULL;
		}
	};
}