#ifndef LINKED_NODE_H
#define LINKED_NODE_H

#include "node.h"
namespace CPlusPlus
{
	template <class T>
	class Linked_Node :
		public Node<T>
	{
	protected:
		Linked_Node<T>* next_node_ptr;

	public:
		Linked_Node<T>();
		Linked_Node<T>(T*);
		~Linked_Node<T>();

		virtual Linked_Node<T>* get_next();
		virtual void insert(Linked_Node<T>*, Linked_Node<T>*);
		virtual void disconnect();
	};
}
#endif