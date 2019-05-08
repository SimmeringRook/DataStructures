#ifndef DOUBLE_LINKED_NODE_H
#define DOUBLE_LINKED_NODE_H

#include "Linked_Node.h"
#include "Data_Structures.h"

DATA_STRUCTURES_CPP_BEGIN

namespace Nodes
{
	template <class T>
	class Double_Linked_Node :
		public Linked_Node<T>
	{
	protected:
		Double_Linked_Node<T>* previous_node_ptr;

	public:
		Double_Linked_Node<T>(T*);
		~Double_Linked_Node<T>();

		virtual Double_Linked_Node<T>* get_next();
		virtual Double_Linked_Node<T>* get_previous();
		virtual void insert(Double_Linked_Node<T>*, Double_Linked_Node<T>*);
		virtual void disconnect();
	};
}

DATA_STRUCTURES_CPP_END

#endif //!DOUBLE_LINKED_NODE_H