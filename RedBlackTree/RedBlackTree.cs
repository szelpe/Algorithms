using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedBlackTree
{
    class RedBlackTree<T> : ICollection<T>
        where T : IEntity
    {
        private Node<T> root;

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            var nodeToAdd = new Node<T>(item.Id, item);
            if (root == null)
            {
                root = nodeToAdd;
                root.Color = NodeColor.Black;
                return;
            }

            root.Add(nodeToAdd);

            RepairTree(nodeToAdd);
        }

        private void RepairTree(Node<T> node)
        {
            if (node.Parent == null)
            {
                node.Color = NodeColor.Black;
                return;
            }
            else if (node.Parent.Color == NodeColor.Black)
            {
                return;
            }
            else if (node.Uncle != null && node.Uncle.Color == NodeColor.Red)
            {
                // Both Parent and Uncle are RED

                node.Parent.Color = NodeColor.Black;
                node.Uncle.Color = NodeColor.Black;
                node.GrandParent.Color = NodeColor.Red;
                RepairTree(node.GrandParent);
            }
            else
            {
                if (node == node.Parent.Right && node.Parent == node.GrandParent.Left)
                {
                    RotateLeft(node.Parent);
                    node = node.Left;
                }
                else if (node == node.Parent.Left && node.Parent == node.GrandParent.Right)
                {
                    RotateRight(node.Parent);
                    node = node.Right;
                }

                var parent = node.Parent;
                var grandParent = node.GrandParent;

                if (node == parent.Left)
                {
                    RotateRight(grandParent);
                }
                else
                {
                    RotateLeft(grandParent);
                }

                parent.Color = NodeColor.Black;
                grandParent.Color = NodeColor.Red;
            }
        }

        private void RotateLeft(Node<T> parent)
        {
            var node = parent.Right;

            if (parent.Parent == null)
            {
                node.Parent = null;
                root = node;
            }
            else
            {
                if (parent == parent.Parent.Left)
                {
                    parent.Parent.SetLeft(node);
                }
                else if (parent == parent.Parent.Right)
                {
                    parent.Parent.SetRight(node);
                }
            }

            parent.SetRight(node.Left);

            node.SetLeft(parent);
        }

        private void RotateRight(Node<T> parent)
        {
            var node = parent.Left;

            if (parent.Parent == null)
            {
                node.Parent = null;
                root = node;
            }
            else
            {
                if (parent == parent.Parent.Left)
                {
                    parent.Parent.SetLeft(node);
                }
                else if (parent == parent.Parent.Right)
                {
                    parent.Parent.SetRight(node);
                }
            }

            parent.SetLeft(node.Right);

            node.SetRight(parent);
        }

        public void Clear()
        {
            root = null;
        }

        public bool Contains(T item)
        {
            return SubTreeContains(root, new Node<T>(item.Id, item));
        }

        private bool SubTreeContains(Node<T> tree, Node<T> node)
        {
            if (tree == null)
            {
                return false;
            }

            if (node == tree)
            {
                return true;
            }

            return SubTreeContains(tree.Left, node) || SubTreeContains(tree.Right, node);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                return false;
            }

            return RemoveNode(root, new Node<T>(item.Id, item));
        }

        private bool RemoveNode(Node<T> subTree, Node<T> node)
        {
            if (subTree == null)
            {
                return false;
            }

            Node<T> nodeFound = null;

            if (subTree.Left == node)
            {
                nodeFound = subTree.Left;
                subTree.Left = null;
            }

            if (subTree.Right == node)
            {
                nodeFound = subTree.Right;
                subTree.Right = null;
            }

            if (nodeFound != null)
            {
                subTree.Add(nodeFound.Left);
                subTree.Add(nodeFound.Right);

                return true;
            }

            return RemoveNode(subTree.Left, node) || RemoveNode(subTree.Right, node);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        internal sealed class Enumerator : IEnumerator<T>
        {
            private readonly Stack<Node<T>> nodesToEnumerate;
            private RedBlackTree<T> bTree;
            object IEnumerator.Current => Current;

            public Enumerator(RedBlackTree<T> bTree)
            {
                this.bTree = bTree;
                nodesToEnumerate = new Stack<Node<T>>();
                PushNode(bTree.root);
            }

            private void PushNode(Node<T> node)
            {
                if (node == null) return;

                PushNode(node.Right);
                nodesToEnumerate.Push(node);
                PushNode(node.Left);
            }

            public T Current { get; private set; }


            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (!nodesToEnumerate.Any())
                {
                    return false;
                }

                var nextNode = nodesToEnumerate.Pop();

                Current = nextNode.Value;

                return true;
            }

            public void Reset()
            {
                nodesToEnumerate.Clear();
                nodesToEnumerate.Push(bTree.root);
            }

            private void PushChildren(Node<T> node)
            {
                if (node.Left != null)
                {
                    nodesToEnumerate.Push(node.Left);
                }
                if (node.Right != null)
                {
                    nodesToEnumerate.Push(node.Right);
                }
            }
        }
    }
}
