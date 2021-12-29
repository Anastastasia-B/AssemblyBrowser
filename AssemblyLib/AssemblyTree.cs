using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssemblyLib.Node;
using AssemblyLib.Reflection;
using AssemblyLib.Extension;

namespace AssemblyLib
{
    internal class AssemblyTree
    {
        private Assembly _assembly;
        private List<AssemblyNode> _tree;
        private Dictionary<TypeNode, Func<object, string>> _nameFuncs;

        internal AssemblyTree(Assembly assembly)
        {
            _assembly = assembly;
            _tree = new List<AssemblyNode>();
            _nameFuncs = new Dictionary<TypeNode, Func<object, string>>()
            {
                { TypeNode.Namespace, NameFormatter.GetNamespaceName },
                { TypeNode.Type, NameFormatter.GetTypeName },
                { TypeNode.Field, NameFormatter.GetFieldName },
                { TypeNode.Property, NameFormatter.GetPropertyName },
                { TypeNode.Method, NameFormatter.GetMethodSignature }
            };
        }

        internal void SetCustomNameFunc(TypeNode typeNode, Func<object, string> func)
        {
            if (_nameFuncs.ContainsKey(typeNode))
            {
                _nameFuncs[typeNode] = func;
            }
            else
            {
                throw new Exception("Not exist for this type generator");
            }
        }

        private void CreateTree()
        {
        }


        internal List<AssemblyNode> GetAssemblyTree()
        {
            CreateTree();
            return _tree.OrderBy(node => node.Name).ToList();
        }
    }
}
