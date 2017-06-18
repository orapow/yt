using MapWinGIS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using X.Gis;

namespace X.Desk
{
    public partial class Main : Form
    {
        bool ischanged = false;
        string msg = "";

        public Main()
        {
            InitializeComponent();
            var tn_root = new Tn()
            {
                Text = "图层",
                tp = 0
            };
            tn_root.Checked = true;
            tv_layers.Nodes.Add(tn_root);
            tv_layers.SelectedNode = tn_root;
            //Directory.CreateDirectory(Application.StartupPath + "\\temp");
        }

        private void tv_layers_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tv_layers.SelectedNode = e.Node;
        }

        private void tmi_newgroup_Click(object sender, EventArgs e)
        {
            ischanged = true;
            var nd = tv_layers.SelectedNode as Tn;
            if (nd == null) return;
            if (nd.tp > 1) nd = nd.Parent as Tn;
            var tn = new Tn()
            {
                Text = "新建图层组",
                tp = 1
            };
            tn.Checked = true;
            nd.Nodes.Insert(0, tn);
            nd.Expand();
            tn.BeginEdit();
            tv_layers.SelectedNode = tn;
        }

        private void tv_layers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var tn = e.Node as Tn;
            if (tn.tp <= 1) return;
            tmi_zoomTothis_Click(sender, null);
        }

        private void showtip(string tip)
        {
            msg = tip;
            //Invoke((Action)(() =>
            //{
            //    tlb_tip.Text = tip;
            //}));
        }

        private void tmi_inport_Click(object sender, EventArgs e)
        {
            ischanged = true;
            var ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "支持文件(*.jpg,*.tif,*.png,*.shp)|*.jpg;*.tif;*.png;*.shp";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            var nd = tv_layers.SelectedNode as Tn;
            foreach (var f in ofd.FileNames)
            {
                showtip("正在加载文件：" + f);
                var ext = f.Substring(ofd.FileName.LastIndexOf("."));
                Tn tn = new Tn() { Text = f.Substring(f.LastIndexOf('\\') + 1), file = f };
                addLayer(tn);
                tn.Checked = true;
                if (nd.tp <= 1) { nd.Nodes.Add(tn); nd.Expand(); }
                else nd.Parent.Nodes.Add(tn);
            }
            showtip("文件加载完成");
            tmi_zoomTothis_Click(nd, null);
        }

        private void tmi_zoomTothis_Click(object sender, EventArgs e)
        {
            var nd = tv_layers.SelectedNode as Tn;
            var ext = getext(nd, nd.extents);
            map1.Extents = ext;
        }

        Extents getext(Tn tn, Extents ext)
        {
            if (tn.tp <= 1) { foreach (Tn t in tn.Nodes) { if (!t.Checked) continue; ext = getext(t, ext); } return ext; }
            if (ext == null)
            {
                ext = map1.Extents as Extents;
                ext.SetBounds(tn.extents.xMin, tn.extents.yMin, tn.extents.mMin, tn.extents.xMax, tn.extents.yMax, tn.extents.zMax);
            }
            else ext.SetBounds(
                    ext.xMin > tn.extents.xMin ? tn.extents.xMin : ext.xMin,
                    ext.yMin > tn.extents.yMin ? tn.extents.yMin : ext.yMin,
                    ext.zMin > tn.extents.zMin ? tn.extents.zMin : ext.zMin,
                    ext.xMax < tn.extents.xMax ? tn.extents.xMax : ext.xMax,
                    ext.yMax < tn.extents.yMax ? tn.extents.yMax : ext.yMax,
                    ext.zMax < tn.extents.zMax ? tn.extents.zMax : ext.zMax
                );
            return ext;
        }

        private void tmi_remove_Click(object sender, EventArgs e)
        {
            var tn = tv_layers.SelectedNode as Tn;
            if (tn == null) return;
            if (tn.tp == 0) { MessageBox.Show("不能移除根元素"); return; }
            removelay(tn);
            tn.Remove();
            ischanged = true;
        }

        void removelay(Tn tn)
        {
            if (tn.tp == 1) foreach (Tn t in tn.Nodes) removelay(t);
            else map1.RemoveLayer(tn.inptr);
        }

        void getLayer(Edit ed, TreeNodeCollection tnc)
        {
            foreach (Tn t in tnc)
            {
                if (t.tp <= 1) { getLayer(ed, t.Nodes); return; }
                Layer lay = null;
                if (t.tp == 2) lay = new ImgLayer() { Name = t.Text, Tp = 1, Extends = new Extend(t.extents.xMin, t.extents.yMin, t.extents.xMax, t.extents.yMax), File = t.file };
                else if (t.tp == 3) lay = new ShpLayer() { Name = t.Text, Tp = 2, Extends = new Extend(t.extents.xMin, t.extents.yMin, t.extents.xMax, t.extents.yMax), File = t.file, Shapes = t.Shapges, Fields = t.Fields };
                ed.AddLayer(lay);
            }
        }

        private void tmi_showpub_Click(object sender, EventArgs e)
        {
            var pub = new Pub();
            if (pub.ShowDialog() != DialogResult.OK) return;

            var ed = new Edit(pub.Path, pub.SName, pub.Key, pub.Dir, pub.Op);
            getLayer(ed, tv_layers.Nodes);
            ed.Show();

            //var ed = new Edit(pub.cfg);

            //ed.Show();
            //var tn = tv_layers.SelectedNode as Tn;

            //if (tn.tp == 2)
            //{
            //    new Thread(o =>
            //    {
            //        showtip("正在处理图片...");
            //        var img = tn.data as Interop.MapWinGIS.Image;
            //        if (img == null) return;
            //        var data = new List<byte>();
            //        var file = Secret.MD5(img.Filename) + ".x";
            //        data.AddRange(Encoding.UTF8.GetBytes("img\r\n" + Serialize.ToJson(new double[4] { img.Extents.xMin, img.Extents.xMax, img.Extents.yMin, img.Extents.yMax }) + "\r\n"));
            //        data.AddRange(File.ReadAllBytes(img.Filename));
            //        File.WriteAllBytes(Application.StartupPath + "\\temp\\" + file, data.ToArray());
            //        showtip("图片处理完成，正在调起发布程序。");
            //    }).Start();
            //}
            //else if (tn.tp == 3)
            //{
            //    showtip("正在处理图形...");
            //    var shp = tn.data as Shapefile;

            //    var file = Application.StartupPath + "\\temp\\" + Secret.MD5(shp.Filename) + ".x";
            //    File.WriteAllText(file, "shp\r\n" + Serialize.ToJson(new List<double> { shp.Extents.xMin, shp.Extents.xMax, shp.Extents.yMin, shp.Extents.yMax }) + "\r\n");
            //    File.AppendAllText(file, Serialize.ToJson(new uint[] { shp.DefaultDrawingOptions.LineColor, (uint)shp.DefaultDrawingOptions.LineWidth, (uint)shp.DefaultDrawingOptions.LineTransparency, shp.DefaultDrawingOptions.FillColor, (uint)shp.DefaultDrawingOptions.FillTransparency }) + "\r\n");

            //    var fs = new List<string>();
            //    for (var f = 0; f < shp.NumFields; f++) fs.Add(shp.Field[f].Name);
            //    File.AppendAllText(file, Serialize.ToJson(fs) + "\r\n");

            //    var gds = new List<object>();
            //    var ns = shp.NumShapes;

            //    for (var i = 0; i < ns; i++)
            //    {
            //        showtip("正在处理图形 " + i + "/" + ns);
            //        var sp = shp.Shape[i];
            //        var gd = new List<object>();
            //        var d = DateTime.Now;
            //        gd.Add(new List<double>() { sp.Center.x, sp.Center.y });

            //        var dt = new List<object>();
            //        for (var c = 0; c < fs.Count; c++) dt.Add(shp.Table.CellValue[c, i] + "");
            //        gd.Add(dt);

            //        var t = 0;
            //        gd.Add(shp.QuickPoints(i, ref t));

            //        gds.Add(gd);
            //        if (i % 10000 == 0)
            //        {
            //            File.AppendAllText(file, Serialize.ToJson(gds) + "\r\n");
            //            gds.Clear();
            //        }
            //    }
            //    if (gds.Count > 0) File.AppendAllText(file, Serialize.ToJson(gds));
            //    showtip("图片处理完成，正在调起发布程序。");

            //}
        }

        private void tv_layers_AfterCheck(object sender, TreeViewEventArgs e)
        {
            setlayervisible(e.Node as Tn, e.Node.Checked);
        }

        void setlayervisible(Tn tn, bool check)
        {
            if (tn.tp <= 1) foreach (Tn t in tn.Nodes) { setlayervisible(t, check); t.Checked = check; }
            else map1.set_LayerVisible(tn.inptr, check);
        }

        private void tmi_edit_Click(object sender, EventArgs e)
        {
            var tn = tv_layers.SelectedNode;
            if (tn != null) tn.BeginEdit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            map1.Projection = tkMapProjection.PROJECTION_WGS84;
            TileProviders providers = map1.Tiles.Providers;
            //int providerId = (int)tkTileProvider.ProviderCustom + 1;    // (1024 + 1) should be unique across application runs in case disk caching is used
            providers.Add(
                1025,
                "矢量",
                "http://webgis.591map.net/tiler/tdt-vec_w-{switch:1,2,3,4,5,6}-{x}-{y}-{zoom}.html",
                0,
                1,
                19);
            providers.Add(
                1026,
                "影像",
                "http://webgis.591map.net/tiler/tdt-img_w-{switch:1,2,3,4,5,6}-{x}-{y}-{zoom}.html",
                0,
                1,
                19);
            map1.Tiles.ProviderId = 1025;// = tkTileProvider.ProviderCustom;
            map1.KnownExtents = tkKnownExtents.keChina;
            map1.Refresh();
        }

        private void tr_time_Tick(object sender, EventArgs e)
        {
            tsl_time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            tlb_tip.Text = msg;
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void 设置SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Down(map1.Extents as Extents).Show();
        }

        private void tsmi_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmi_open_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Yt工程文件|*.ytp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //file = ofd.FileName;
                //var data = File.ReadAllText(ofd.FileName);
                //var node = Serialize.FromJson<Node>(data);
                //tv_layers.Nodes.Clear();
                //map1.RemoveAllLayers();
                //var tn = new Tn() { Text = node.name, tp = 0, Checked = true };
                //tv_layers.Nodes.Add(tn);
                ////node2tree(node.nodes, tv_layers.Nodes[0].Nodes);
                //tn.Expand();
            }
        }

        private void tsmi_save_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(file))
            //{
            //    var sfd = new SaveFileDialog();
            //    sfd.Filter = "Yt工程文件|*.ytp";
            //    if (sfd.ShowDialog() == DialogResult.OK) file = sfd.FileName;
            //}
            //if (string.IsNullOrEmpty(file)) return;

            ////var n = new Node() { name = "图层", nodes = new List<Node>() };
            ////tree2node(n.nodes, tv_layers.Nodes[0].Nodes);
            //var data = Serialize.ToJson(n);
            //File.WriteAllText(file, data);
        }

        void addLayer(Tn tn)
        {
            var ext = tn.file.Substring(tn.file.LastIndexOf("."));
            object lay = null;
            if (ext == ".shp")
            {
                var shp = new Shapefile();
                shp.Open(tn.file);
                lay = shp;
                tn.tp = 3;
                tn.extents = shp.Extents;

                tn.Fields = new List<ShpLayer.Field>();
                for (var f = 0; f < shp.NumFields; f++)
                {
                    var fe = shp.Field[f];
                    tn.Fields.Add(new ShpLayer.Field() { Name = fe.Name, Length = fe.Width, Type = fe.Type.ToString("G") });
                }

                tn.Shapges = new List<ShpLayer.Shape>();
                for (var i = 0; i < shp.NumShapes; i++)
                {
                    showtip("正在加载文件：" + tn.file + " " + i + "/" + shp.NumShapes);
                    var sp = shp.Shape[i];
                    var spe = new ShpLayer.Shape();
                    spe.Tp = (byte)sp.ShapeType;
                    spe.Extent = new Extend(sp.Extents.xMin, sp.Extents.yMin, sp.Extents.xMax, sp.Extents.yMax);
                    var data = new Dictionary<string, string>();
                    for (var f = 0; f < shp.NumFields; f++) data.Add(shp.Field[f].Name, shp.Table.CellValue[f, i] + "");
                    spe.Data = data;
                    for (var j = 0; j < sp.NumParts; j++) spe.Points.Add(j, getPoints(sp.PartAsShape[j]));
                    tn.Shapges.Add(spe);
                }

            }
            else
            {
                var img = new MapWinGIS.Image();
                img.Open(tn.file);
                var r = false;
                img.SetNoDataValue(0, ref r);
                lay = img;
                tn.tp = 2;
                tn.extents = img.Extents;
            }
            tn.inptr = map1.AddLayer(lay, true);
            showtip("文件：" + tn.file + " 加载完成");
        }

        List<PointF> getPoints(IShape s)
        {
            var pts = new List<PointF>();
            for (var i = 0; i < s.numPoints; i++)
            {
                var pt = s.Point[i];
                pts.Add(new PointF((float)pt.x, (float)pt.y));
            }
            return pts;
        }

        //void node2tree(List<Node> ns, TreeNodeCollection tnc)
        //{
        //    foreach (var n in ns)
        //    {
        //        Tn tn = new Tn() { tp = n.tp, Checked = true };
        //        if (!File.Exists(n.file))
        //            tn.Text += "(" + n.file + "不存在)";
        //        else
        //        {
        //            tn.Text = n.name;
        //            if (n.tp == 3)
        //            {
        //                if (!File.Exists(n.file)) tn.Text += "(" + n.file + "不存在)";
        //                else
        //                {
        //                    var shp = new Shapefile();
        //                    shp.Open(n.file);
        //                    tn.layhandler = map1.AddLayer(shp, true);
        //                    tn.data = shp;
        //                    tn.extents = shp.Extents;
        //                }
        //            }
        //            else if (n.tp == 2)
        //            {
        //                var img = new Interop.MapWinGIS.Image();
        //                img.Open(n.file);
        //                tn.data = img;
        //                tn.extents = img.Extents;
        //                tn.layhandler = map1.AddLayer(img, true);
        //            }
        //        }
        //        tnc.Add(tn);
        //        node2tree(n.nodes, tn.Nodes);
        //        tn.Expand();
        //    }
        //}

        //void tree2node(List<Node> ns, TreeNodeCollection tnc)
        //{
        //    if (ns == null) ns = new List<Node>();
        //    foreach (Tn tn in tnc)
        //    {
        //        var n = new Node() { name = tn.Text, nodes = new List<Node>(), tp = tn.tp };
        //        if (tn.tp == 2)
        //        {
        //            var img = tn.data as Interop.MapWinGIS.Image;
        //            n.file = img.Filename;
        //        }
        //        else if (tn.tp == 3)
        //        {
        //            var shp = tn.data as Shapefile;
        //            n.file = shp.Filename;
        //        }
        //        ns.Add(n);
        //        tree2node(n.nodes, tn.Nodes);
        //    }
        //}

        private void tsmi_new_Click(object sender, EventArgs e)
        {
            if (ischanged)
            {
                var rt = MessageBox.Show("工程已经更改，是否保存？", "消息提示", MessageBoxButtons.YesNoCancel);
                if (rt == DialogResult.Yes) tsmi_save_Click(sender, e);
                else if (rt == DialogResult.Cancel) return;
            }
            tv_layers.Nodes.Clear();
            map1.RemoveAllLayers();
            tv_layers.Nodes.Add(new Tn() { Text = "图层", tp = 0, Checked = true });
        }

        private void tv_layers_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            ischanged = true;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ischanged) return;
            if (e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.WindowsShutDown) tsmi_save_Click(sender, e);
            else
            {
                var rt = MessageBox.Show("工程已经更改，是否保存？", "消息提示", MessageBoxButtons.YesNoCancel);
                if (rt == DialogResult.Yes) tsmi_save_Click(sender, e);
                else if (rt == DialogResult.Cancel) e.Cancel = true;
            }
        }

        private void tsmi_save_as_Click(object sender, EventArgs e)
        {
            //file = "";
            tsmi_save_Click(sender, e);
        }

        private void 矢量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            矢量ToolStripMenuItem.Checked = true;
            影像ToolStripMenuItem.Checked = false;
            map1.Tiles.ProviderId = 1025;
            map1.Extents = map1.Extents;
        }

        private void 影像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            矢量ToolStripMenuItem.Checked = false;
            影像ToolStripMenuItem.Checked = true;
            map1.Tiles.ProviderId = 1026;
            map1.Extents = map1.Extents;
        }

        public class Tn : TreeNode
        {
            /// <summary>
            /// 0、根
            /// 1、文件夹
            /// 2、图片层
            /// 3、热区层
            /// </summary>
            public int tp { get; set; }
            public string file { get; set; }
            public Extents extents { get; set; }
            public int inptr { get; set; }
            public List<ShpLayer.Field> Fields { get; set; }
            public List<ShpLayer.Shape> Shapges { get; set; }
        }

        private void tsmi_links_Click(object sender, EventArgs e)
        {
            new Links().ShowDialog();
        }
    }
}
