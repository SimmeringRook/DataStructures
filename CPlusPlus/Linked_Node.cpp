#include "Linked_Node.h"

DATA_STRUCTURES_CPP_BEGIN

namespace Nodes
{
	template <typename T>
	Linked_Node<T>::Linked_Node() : Node<T>()
	{
		this->next_ptr = NULL;
	};

	template <typename T>
	Linked_Node<T>::Linked_Node(T value) : Node<T>(value)
	{
		this->next_ptr = NULL;
	};

	template <class T>
	Linked_Node<T>::Linked_Node(const Linked_Node<T>& node)
	{
		this->value = node.value;
		this->value_ptr = &this->value;

		this->next_ptr = node.next_ptr;
	}

	template <class T>
	Linked_Node<T>& Linked_Node<T>::operator=(Linked_Node<T> other)
	{
		this->value = other.value;
		this->value_ptr = &this->value;

		this->next_ptr = other.next_ptr;
		
		return *this;
	}

	template <typename T>
	Linked_Node<T>::~Linked_Node()
	{
		this->next_ptr = NULL;
	};

	//template <typename T>
	//Linked_Node<T>* Linked_Node<T>::get_next()
	//{
	//	return this->next_node_ptr;
	//};

	template <typename T>
	void  Linked_Node<T>::insert(Linked_Node<T>* previous, Linked_Node<T>* next)
	{
		if (previous != NULL)
		{
			previous->next_ptr = this;
		}

		this->next_ptr = next;
	};

	template <typename T>
	void Linked_Node<T>::disconnect()
	{
		this->next_ptr = NULL;
	};
}

DATA_STRUCTURES_CPP_END