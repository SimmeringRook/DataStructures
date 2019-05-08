#include "node.h"

using namespace std;

DATA_STRUCTURES_CPP_BEGIN

namespace Nodes
{
	template <class T>
	Node<T>::Node()
	{
		this->value_ptr = NULL;
		this->value = T();
	}

	template <class T>
	Node<T>::Node(T value)
	{
		this->value = value;
		this->value_ptr = &this->value;
	}

	template <class T>
	Node<T>::Node(const Node<T> &node)
	{
		this->value = node.value;
		this->value_ptr = &this->value;
	}

	template <class T>
	Node<T>& Node<T>::operator=(Node<T> other)
	{
		this->value = other.value;
		this->value_ptr = &this->value;
		return *this;
	}

	template<class T>
	Node<T>::~Node()
	{
		this->value_ptr = NULL;
	}

	template <class T>
	T* Node<T>::get_value()
	{
		return this->value_ptr;
	}
}

DATA_STRUCTURES_CPP_END