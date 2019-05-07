#include "Linked_Node.h"

namespace CPlusPlus
{
	template <typename T>
	Linked_Node<T>::Linked_Node() : Node<T>()
	{
		this->next_node_ptr = NULL;
	};

	template <typename T>
	Linked_Node<T>::Linked_Node(T* value) : Node<T>(value)
	{
		this->next_node_ptr = NULL;
	};


	template <typename T>
	Linked_Node<T>::~Linked_Node()
	{
		this->next_node_ptr = NULL;
	};

	template <typename T>
	Linked_Node<T>* Linked_Node<T>::get_next()
	{
		return this->next_node_ptr;
	};

	template <typename T>
	void  Linked_Node<T>::insert(Linked_Node<T>* previous, Linked_Node<T>* next)
	{
		if (previous != NULL)
		{
			previous->next_node_ptr = this;
		}

		this->next_node_ptr = next;
	};

	template <typename T>
	void Linked_Node<T>::disconnect()
	{
		this->next_node_ptr = NULL;
	};
}