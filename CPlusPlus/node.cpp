#include "node.h"

using namespace std;

namespace CPlusPlus
{
	template <class T>
	Node<T>::Node()
	{
		this->value_ptr = NULL;
	}

	template <class T>
	Node<T>::Node(T* value)
	{
		this->value_ptr = value;
	}

	template<class T>
	Node<T>::~Node()
	{
		this->value_ptr = NULL;
	};

	template <class T>
	T* Node<T>::get_value()
	{
		return this->value_ptr;
	}
}