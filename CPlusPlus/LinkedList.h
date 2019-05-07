#ifndef LINKED_LIST_H
#define LINKED_LIST_H

#include "Linked_Node.h"

namespace CPlusPlus
{
	template <class T>
	class LinkedList
	{
	protected:
		Linked_Node<T>* head_node_ptr;
		Linked_Node<T>* tail_node_ptr;

		bool is_cached_count_valid;
		int cached_count;

	public:

		LinkedList<T>();
		LinkedList<T>(T*, int);

		~LinkedList<T>();

		T* operator[](int);
		int operator[](T);

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
	};
}
#endif // !LINKED_LIST_H


