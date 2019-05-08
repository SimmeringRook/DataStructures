#ifndef NODE_H
#define NODE_H

#include <cstddef>

#include "Data_Structures.h"

DATA_STRUCTURES_BEGIN
C_PLUS_PLUS_BEGIN
namespace Nodes
{
	template <class T>
	class Node
	{
	protected:
		T value;
	public:
		T* value_ptr;

		Node<T>();
		Node<T>(T value);

		Node<T>(const Node<T>&);

		Node<T>& operator=(Node<T>);

		~Node<T>();

		T* get_value();
	};
}
C_PLUS_PLUS_END
DATA_STRUCTURES_END
#endif //!NODE_H