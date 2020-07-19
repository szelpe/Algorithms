using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    class Node<T>
        where T : IEntity
    {
        public int Id { get; }
        public T Value { get; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> Uncle
        {
            get
            {
                if (GrandParent == null)
                    return null;

                if (GrandParent.Left == Parent)
                {
                    return GrandParent.Right;
                }

                return GrandParent.Left;
            }
        }

        public Node<T> GrandParent
        {
            get
            {
                if (Parent == null)
                    return null;

                return Parent.Parent;
            }
        }

        public NodeColor Color;

        public Node(int id, T value)
        {
            Id = id;
            Value = value;
        }

        internal void AddLeft(Node<T> item)
        {
            if (Left == null)
            {
                Left = item;
                item.Parent = this;
                return;
            }

            Left.Add(item);
        }

        internal void AddRight(Node<T> item)
        {
            if (Right == null)
            {
                Right = item;
                item.Parent = this;
                return;
            }

            Right.Add(item);
        }

        public void Add(Node<T> item)
        {
            if (item == null) return;

            if (item.Id < Id)
            {
                AddLeft(item);
            }
            else
            {
                AddRight(item);
            }
        }

        public void SetLeft(Node<T> item)
        {
            Left = item;
            if(item != null)
                item.Parent = this;
        }

        public void SetRight(Node<T> item)
        {
            Right = item;
            if (item != null)
                item.Parent = this;
        }

        public override bool Equals(object obj)
        {
            return obj is Node<T> node &&
                   Id == node.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(Node<T> a, Node<T> b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Node<T> a, Node<T> b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return Color + ": " + Value.ToString();
        }
    }

    public enum NodeColor
    {
        Red,
        Black,
    }
}
