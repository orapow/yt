using Interop.MapWinGIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using X.Core.Utility;

namespace Tiler
{
    public partial class Pub1 : Form
    {
        private Tn tn = null;
        private Shapefile sf = null;
        private int p = -1;
        private bool stop = false;


        public Pub1(List<Tn> tns)
        {
            InitializeComponent();
            tn = tns[0];
        }

        private void Pub_Load(object sender, EventArgs e)
        {
            sf = tn.data as Shapefile;
            //for (var i = 0; i < shp.NumShapes; i++)
            //    Debug.WriteLine(shp.Shape[i]);

            for (var i = 0; i < sf.NumFields; i++)
            {
                cbl_fields.Items.Add(sf.Field[i].Name);
                cb_namefield.Items.Add(sf.Field[i].Name);
            }
            cb_outtype.SelectedIndex = 0;
            showdemo(1);

            //Debug.WriteLine("");

            //for (var i = 0; i < shp.Table.NumRows; i++) ;
            //{
            //    Debug.Write("No." + i);
            //    for (var j = 0; j < shp.NumFields; j++)
            //    {
            //        string val = shp.Table.CellValue[j, i].ToString();
            //        Debug.Write("," + val);
            //    }
            //    Debug.WriteLine(";");
            //}

            //for (var i = 0; i < shp.NumShapes; i++)
            //{
            //    var sp = shp.Shape[i];
            //    //Debug.WriteLine("center" + sp.Center);
            //}
        }

        void showdemo(int q)
        {
            tb_demo.Text = "";
            p += q;
            if (p < 0) p = 0;
            if (p >= sf.Table.NumRows) p = sf.Table.NumRows - 1;
            for (var i = 0; i < sf.NumFields; i++) tb_demo.Text += sf.Field[i].Name + "：" + sf.Table.CellValue[i, p] + "\r\n";
        }

        private void bt_pre_Click(object sender, EventArgs e)
        {
            showdemo(-1);
        }

        private void bt_nxt_Click(object sender, EventArgs e)
        {
            showdemo(1);
        }

        private void cb_outtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            bt_open.Visible = cb_outtype.SelectedIndex > 0;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            var shps = new List<object>();
            var pt = cb_outtype.SelectedIndex;
            var n = cb_namefield.SelectedIndex;
            var cbs = cbl_fields.CheckedIndices;
            var addr = tb_addr.Text;

            if (n < 0) { MessageBox.Show("请选择要作为名称的字段"); return; }
            if (string.IsNullOrEmpty(addr)) { MessageBox.Show("请填写或选择输出地址"); return; }
            if (cbs == null || cbs.Count == 0) { MessageBox.Show("请选择要输出的字段"); return; }

            btn_start.Enabled = false;
            tsp_pr.Maximum = sf.NumShapes;

            var tc = 10.0;
            var ct = (int)Math.Ceiling(sf.NumShapes / tc);
            Debug.WriteLine("共" + tc + "个线程，每线程" + ct + "个");

            for (var t = 0; t < tc; t++)
            {
                new Thread(o =>
                {
                    var s = (int)o;
                    Debug.WriteLine("线程 " + s + " 启动，开始下标：" + (s * ct) + "，结束下标：" + (s * ct + ct));
                    var list = new List<object>();
                    for (var i = s * ct; i < s * ct + ct; i++)
                    {
                        if (i >= sf.NumShapes || stop) break;
                        var gd = new Dictionary<string, object>();
                        var sp = sf.Shape[i];

                        gd.Add("name", sf.Table.CellValue[n, i]);
                        gd.Add("lng", sp.Center.x);
                        gd.Add("lat", sp.Center.y);

                        Invoke((Action)(() =>
                        {
                            tssl_info.Text = "正在处理：第" + (i + 1) + "个，名称：" + gd["name"];
                        }));

                        gd.Add("style", Serialize.ToJson(new { color = sf.DefaultDrawingOptions.FillColor }));
                        var pts = new List<object>();
                        for (var p = 0; p < sp.numPoints; p++) { var pot = sp.Point[p]; pts.Add(new { lng = pot.x, lat = pot.y }); }
                        gd.Add("points", Serialize.ToJson(pts));

                        var cfg = new Dictionary<string, object>();
                        foreach (int c in cbs)
                        {
                            if (pt == 0) cfg.Add(sf.Field[c].Name, sf.Table.CellValue[c, i]);
                            else gd.Add(sf.Field[c].Name, sf.Table.CellValue[c, i]);
                        }
                        if (pt == 0) gd.Add("cfg", Serialize.ToJson(cfg));
                        list.Add(gd);

                        if (i % 50 == 0)
                        {
                            lock (shps) shps.AddRange(list); list.Clear();
                            Invoke((Action)(() =>
                            {
                                tsp_pr.Value = shps.Count;
                                tssl_pr.Text = (tsp_pr.Value / (float)sf.NumShapes * 100).ToString("F2") + "%";
                            }));
                        }
                    }
                    if (stop)
                    {
                        Invoke((Action)(() =>
                        {
                            tssl_info.Text = "处理中断";
                        }));
                        Debug.WriteLine("处理中断");
                    }
                    else
                    {
                        lock (shps) shps.AddRange(list); list.Clear();
                        Invoke((Action)(() =>
                        {
                            tsp_pr.Value = shps.Count;
                            tssl_pr.Text = (tsp_pr.Value / (float)sf.NumShapes * 100).ToString("F2") + "%";
                        }));

                        Debug.WriteLine("线程 " + s + " 结束");
                        if (shps.Count == sf.NumShapes) OutPut(shps, pt, addr);
                    }
                }).Start(t);
            }
        }

        private void OutPut(List<object> shps, int pt, string addr)
        {
            var limit = 300;
            var page = 1;
            var pc = (int)Math.Ceiling(shps.Count / (float)limit);

            Invoke((Action)(() =>
            {
                tssl_info.Text = "处理完成，准备输出到：" + addr;
                tssl_pr.Text = "";
                tsp_pr.Minimum = 0;
                tsp_pr.Maximum = pc;
                tsp_pr.Value = 0;
            }));

            if (pt == 1) File.WriteAllText(addr, Serialize.ToJson(shps));
            else
            {
                if (pt != 0) File.WriteAllText(addr, "");
                if (pt == 2)
                {
                    var dt = shps[0] as Dictionary<string, object>;
                    Invoke((Action)(() =>
                    {
                        var sb = new StringBuilder();
                        sb.Append("<table border='0'><tr>");
                        foreach (var k in dt.Keys) sb.Append("<td>" + k + "</td>");
                        sb.Append("</tr>");
                        File.AppendAllText(addr, sb.ToString());
                    }));
                }

                do
                {
                    if (stop) break;
                    var list = shps.Skip((page - 1) * limit).Take(limit).ToList();
                    if (list == null || list.Count() == 0) break;

                    Invoke((Action)(() =>
                    {
                        tssl_info.Text = "正在输出第" + page + "页";
                        tsp_pr.Value = page;
                        tssl_pr.Text = Math.Ceiling(page / (float)pc * 100).ToString("F2");
                    }));

                    Debug.WriteLine("正在输出第" + page + "页");

                    if (pt == 0) Tools.PostHttpData(addr, Serialize.ToJson(list));
                    else
                    {
                        var data = list as List<object>;
                        var sb = new StringBuilder();
                        foreach (var d in data)
                        {
                            var c = d as Dictionary<string, object>;
                            if (pt == 2) sb.Append("<tr>");
                            foreach (var k in c.Keys)
                            {
                                if (pt == 3) sb.Append(c[k] + ",");
                                else sb.Append("<td>" + c[k] + "</td>");
                            }
                            if (pt == 2) sb.Append("</tr>");
                            else sb.Append("\r\n");
                        }
                        File.AppendAllText(addr, sb.ToString());
                    }

                    page++;
                } while (true);
            }

            if (stop)
            {
                Invoke((Action)(() =>
                {
                    tssl_info.Text = "发布中断";
                }));
            }
            else
            {
                if (pt == 2) File.AppendAllText(addr, "</table>");
                Invoke((Action)(() =>
                {
                    tssl_info.Text = "输出完成，共输出" + shps.Count + "个图形。";
                    btn_start.Enabled = true;
                }));
            }
        }
    }
}
