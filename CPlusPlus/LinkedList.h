#ifndef LINKED_LIST_H
#define LINKED_LIST_H

#include "Linked_Node.h"

DATA_STRUCTURES_CPP_BEGIN

namespace Lists
{
	template <class T>
	class LinkedList
	{
	protected:
		Nodes::Linked_Node<T>* head_node_ptr;
		Nodes::Linked_Node<T>* tail_node_ptr;

		bool is_cached_count_valid;
		int cached_count;

		int get_uncached_count() const;

		T* get_at(int) const;
	public:

		LinkedList<T>();
		LinkedList<T>(T*, int);

		LinkedList<T>(const LinkedList<T>&);

		LinkedList<T>& operator=(LinkedList<T>);

		~LinkedList<T>();

		T* operator[](int);
		/*int operator[](T);*/

		void add(T);
		void add_range(T*, int);

		void clear();

		bool contains(T);

		int count();
		int index_of(T);

		void remove(T);
		void remove_at(int);
		void remove_range(int, int);

		void reverse();

		T* to_array() const;
	};
}

DATA_STRUCTURES_CPP_END

#endif // !LINKED_LIST_H


