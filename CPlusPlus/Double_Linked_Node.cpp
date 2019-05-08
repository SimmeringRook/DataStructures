#include "Double_Linked_Node.h"

DATA_STRUCTURES_CPP_BEGIN

namespace Nodes
{
	template <typename T>
	Double_Linked_Node<T>::Double_Linked_Node(T* value) : Linked_Node(value)
	{

	};

	template <typename T>
	Double_Linked_Node<T>::~Double_Linked_Node()
	{
		this->previous_node_ptr = NULL;
	};

	template <typename T>
	Double_Linked_Node<T>* Double_Linked_Node<T>::get_next()
	{
		return this->next_node_ptr;
	};

	template <typename T>
	Double_Linked_Node<T>* Double_Linked_Node<T>::get_previous()
	{
		return this->previous_node_ptr;
	};

	template <typename T>
	void  Double_Linked_Node<T>::insert(Double_Linked_Node<T>* previous, Double_Linked_Node<T>* next)
	{
		if (previous->get_next() == NULL)
		{
			previous->next_node_ptr = this;
		}
		else if (previous->get_next() != NULL)
		{
			this->next_node_ptr = previous->get_next();
			previous->next_node_ptr = this;
		}

		if (next != NULL)
		{
			this->next_node_ptr = next;
		}
	};

	template <typename T>
	void Double_Linked_Node<T>::disconnect()
	{
		if (this->get_previous() != NULL && this->get_next() != NULL)
		{
			this->previous_node_ptr->get_next() = this->get_next();
			return;
		}

		if (this->get_previous() != NULL && this->get_next() == NULL)
		{
			this->previous_node_ptr->get_next() = NULL;
			return;
		}
	};
}

DATA_STRUCTURES_CPP_END