#ifndef LINKED_NODE_H
#define LINKED_NODE_H

#include "node.h"

#include "Data_Structures.h"

DATA_STRUCTURES_CPP_BEGIN

namespace Nodes
{
	template <class T>
	class Linked_Node :
		public Node<T>
	{
	public:
		Linked_Node<T>();
		Linked_Node<T>(T);

		Linked_Node<T>(const Linked_Node<T>&);

		Linked_Node<T>& operator=(Linked_Node<T>);

		~Linked_Node<T>();

		Linked_Node<T>* next_ptr;

		//virtual Linked_Node<T>* get_next();
		virtual void insert(Linked_Node<T>*, Linked_Node<T>*);
		virtual void disconnect();
	};
}

DATA_STRUCTURES_CPP_END

#endif //!LINKED_NODE_H