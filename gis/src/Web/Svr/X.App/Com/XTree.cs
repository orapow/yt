﻿using System.Collections.Generic;
using System.Threading;

namespace X.App
{
    public class XTree
    {
        public delegate List<TreeNode> LoadListHandler(object id);
        public event LoadListHandler LoadList;

        TreeNode root;
        List<TreeNode> list;
        object locker = 0;

        int deep = 0;

        public void InitTree(string title)
        {
            InitTree(title, 3);
        }

        public void InitTree(string title, int deep)
        {
            list = new List<TreeNode>();
            root = new TreeNode(title);
            this.deep = deep;
            getChild(root, 0);
        }

        public List<TreeNode> OutTree()
        {
            outNode(root);
            return list;
        }

        void outNode(TreeNode n)
        {
            var nt = n as TreeNode;
            foreach (var tn in nt.childs)
            {
                var name = "";
                if (tn.pn != null && tn.pn.pn != null)
                {
                    var t = tn.pn;
                    for (; t.pn != null;)
                    {
                        if (t.deep == t.pn.childs.Count - 1) { name = "　" + name; }//<span style='display:inline-block;width:14px;'></span>
                        else name = "　" + name;//│
                        t = t.pn;
                    }
                }
                if (tn.pn != null) { if (tn.deep == tn.pn.childs.Count - 1) name += "└"; else name += "├"; }
                tn.name = name + tn.name;
                list.Add(tn);
                outNode(tn);
            }
        }

        void getChild(TreeNode n, int d)
        {
            if (d > deep) return;
            if (LoadList == null) return;
            var list = LoadList(n.value);
            if (list == null || list.Count == 0) return;

            var wh = new List<ManualResetEvent>();
            foreach (var ent in list)
            {
                if (d == 0)
                {
                    n.AddNode(ent);
                    getChild(ent, d + 1);
                }
                else
                {
                    n.AddNode(ent);
                    getChild(ent, d + 1);
                }
            }
            if (wh.Count > 0) WaitHandle.WaitAll(wh.ToArray());

        }
    }

    public class TreeNode
    {
        [Json.JsonIgnore]
        public TreeNode pn { get; set; }
        [Json.JsonIgnore]
        public List<TreeNode> childs { get; set; }
        [Json.JsonIgnore]
        public int deep { get; set; }
        public object value { get; set; }
        public string name { get; set; }
        public TreeNode(string n)
        {
            name = n;
            value = 0;
            childs = new List<TreeNode>();
        }
        public TreeNode() : this("") { }
        public void AddNode(TreeNode n)
        {
            n.pn = this;
            n.deep = childs.Count;
            childs.Add(n);
        }
    }
}
