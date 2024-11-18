using System.Collections.Generic;

namespace MunicipalServicesAppWPF
{
    public class BinarySearchTree
    {
        private TreeNode root;

        // Insert a ServiceRequest into the tree
        public void Insert(ServiceRequest request)
        {
            root = InsertRec(root, request);
        }

        private TreeNode InsertRec(TreeNode node, ServiceRequest request)
        {
            if (node == null)
            {
                return new TreeNode(request);
            }

            if (request.Id < node.Data.Id)
            {
                node.Left = InsertRec(node.Left, request);
            }
            else if (request.Id > node.Data.Id)
            {
                node.Right = InsertRec(node.Right, request);
            }

            return node;
        }

        // Search for a ServiceRequest by ID
        public ServiceRequest Search(int id)
        {
            return SearchRec(root, id)?.Data;
        }

        private TreeNode SearchRec(TreeNode node, int id)
        {
            if (node == null || node.Data.Id == id)
            {
                return node;
            }

            return id < node.Data.Id ? SearchRec(node.Left, id) : SearchRec(node.Right, id);
        }

        // Traverse the tree in order and return a list of ServiceRequests
        public List<ServiceRequest> InOrderTraversal()
        {
            var result = new List<ServiceRequest>();
            InOrderRec(root, result);
            return result;
        }

        private void InOrderRec(TreeNode node, List<ServiceRequest> result)
        {
            if (node == null) return;

            InOrderRec(node.Left, result);
            result.Add(node.Data);
            InOrderRec(node.Right, result);
        }

        // TreeNode inner class
        private class TreeNode
        {
            public ServiceRequest Data { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }

            public TreeNode(ServiceRequest data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }
    }
}
