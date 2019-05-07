#include "LinkedList.h"

using namespace CPlusPlus;

template <class T>
LinkedList<T>::LinkedList()
{
	this->head_node_ptr = NULL;
	this->tail_node_ptr = NULL;

	this->is_cached_count_valid = true;
	this->count = 0;
}

template <class T>
LinkedList<T>::LinkedList(T *collection, int size) 
{
	this->head_node_ptr = NULL;
	this->tail_node_ptr = NULL;

	this->is_cached_count_valid = true;
	this->count = 0;

	this->add_range(collection, size);
}

template <class T>
LinkedList<T>::~LinkedList()
{
	this->clear();
}

template<class T>
T* LinkedList<T>::operator[](int index)
{
	Linked_Node<T>* current_node_ptr = this->head_node_ptr;

	for (int i = 0; i < index; i++)
	{
		current_node_ptr = current_node_ptr->get_next();
	}

	return current_node_ptr->get_value();
}

template<class T>
int LinkedList<T>::operator[](T value)
{
	Linked_Node<T>* current_node_ptr = this->head_node_ptr;

	for (int i = 0; i < this->count(); i++)
	{
		if (*current_node_ptr->get_value() == value)
			return i;
		current_node_ptr = current_node_ptr->get_next();
	}

	return -1;
}

template<class T>
void LinkedList<T>::add(T value)
{
	this->is_cached_count_valid = false;

	if (this->head_node_ptr == NULL)
	{
		this->head_node_ptr = new Linked_Node<T>(&value);
		this->tail_node_ptr = this->head_node_ptr;
		return;
	}
	else if (this->head_node_ptr = this->tail_node_ptr)
	{
		this->tail_node_ptr = new Linked_Node<T>(&value);
		this->head_node_ptr->next_node_ptr = this->tail_node_ptr;
	}
	else 
	{
		this->tail_node_ptr->next_node_ptr = new Linked_Node<T>(&value);
		this->tail_node_ptr = this->tail_node_ptr->get_next();
	}
}

template<class T>
void LinkedList<T>::add_range(T* collection, int size)
{
	this->is_cached_count_valid = false;

	for (int i = 0; i < size; i++) 
	{
		this->add(collection[i]);
	}
}

template<class T>
void LinkedList<T>::clear()
{
	if (this->count() == 0)
		return;

	Linked_Node<T> *current_node_ptr = this->head_node_ptr;
	Linked_Node<T> *next_node_ptr = this->head_node_ptr;

	while (next_node_ptr != NULL) 
	{
		current_node_ptr = next_node_ptr;
		next_node_ptr = current_node_ptr->get_next();

		current_node_ptr->disconnect();
		delete current_node_ptr;
		current_node_ptr = NULL;
	}

	delete this->head_node_ptr;
	delete this->tail_node_ptr;
	this->head_node_ptr = NULL;
	this->tail_node_ptr = NULL;

	next_node_ptr = NULL;

	this->is_cached_count_valid = false;
}

template<class T>
bool LinkedList<T>::contains(T value)
{
	return (this[value] >= 0);
}

template<class T>
int LinkedList<T>::count()
{
	if (this->is_cached_count_valid == false)
	{
		int live_count = 0;

		if (this->head_node_ptr != NULL)
		{
			Linked_Node<T>* current_node_ptr = this->head_node_ptr;

			while (current_node_ptr != NULL)
			{
				live_count++;
				current_node_ptr = current_node_ptr->get_next();
			}

			this->cached_count = live_count;
			this->is_cached_count_valid = true;
		}
	}

	return this->cached_count;
}

template<class T>
int LinkedList<T>::index_of(T value)
{
	return this[value];
}

template<class T>
void LinkedList<T>::remove(T value)
{
	if (this->count() < 1)
		return;

	if (this->count() == 1)
	{
		this->clear();
	}
	else 
	{
		Linked_Node<T>* current_node_ptr = this->head_node_ptr;
		Linked_Node<T>* previous_node_ptr = current_node_ptr;

		while (*current_node_ptr->get_value() != value)
		{
			previous_node_ptr = current_node_ptr;
			current_node_ptr = current_node_ptr->get_next();

			if (current_node_ptr == NULL)
				return;
		}

		if (current_node_ptr == this->head_node_ptr)
		{
			this->head_node_ptr = this->head_node_ptr->get_next();
		}
		else if (current_node_ptr == this->tail_node_ptr)
		{
			this->tail_node_ptr = previous_node_ptr;
			this->tail_node_ptr->disconnect();
		}
		else
		{
			previous_node_ptr->next_node_ptr = current_node_ptr->get_next();
		}

		this->is_cached_count_valid = false;
		delete current_node_ptr;
	}
}

template<class T>
void LinkedList<T>::remove_at(int index)
{
	if (this->count() == 0)
	{
		return;
	}
	else if (this->count() == 1)
	{
		this->clear();
	}
	else
	{
		Linked_Node<T>* current_node_ptr = this->head_node_ptr;
		Linked_Node<T>* previous_node_ptr = current_node_ptr;

		for (int i = 0; i < index; i++)
		{
			previous_node_ptr = current_node_ptr;
			current_node_ptr = current_node_ptr->get_next();
		}

		if (index == 0)
		{
			this->head_node_ptr = this->head_node_ptr->get_next();
		}
		else if (index == this->count() - 1)
		{
			this->tail_node_ptr = previous_node_ptr;
			this->tail_node_ptr->next_node_ptr->disconnect();
		}
		else 
		{
			previous_node_ptr->next_node_ptr = current_node_ptr->get_next();
		}

		delete current_node_ptr;
	}

	this->is_cached_count_valid = false;
}

template<class T>
void LinkedList<T>::remove_range(int start_index, int length)
{
	for (int i = length - 1; i >= 0; i--)
	{
		this->remove_at(start_index + i);
	}
}

template<class T>
void LinkedList<T>::reverse()
{
	if (this.count() < 2)
		return;

	Linked_Node<T>* new_head_node = new Linked_Node<T>(this->tail_node_ptr->get_value());
	Linked_Node<T>* new_tail_node = new_head_node;

	for (int i = this->count() - 2; i >= 0; i--)
	{
		Linked_Node<T> *current = new Linked_Node<T>(this[i]);

		new_tail_node->next_node_ptr = current;
		new_tail_node = new_tail_node->get_next();
	}

	this->clear();

	this->head_node_ptr = new_head_node;
	this->tail_node_ptr = new_tail_node;
}