#ifndef NODE_H
#define NODE_H

#include <cstddef>
namespace CPlusPlus
{
	template <class T>
	class Node
	{
	public:
		T* value_ptr;

		Node<T>();
		Node<T>(T* value);

		~Node<T>();

		T* get_value();
	};
}
#endif