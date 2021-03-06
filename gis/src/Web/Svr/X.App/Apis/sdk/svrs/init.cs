﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using X.App.Com;
using X.Core.Utility;
using X.Gis;
using X.Web;
using X.Web.Com;
using static X.Gis.ShpLayer;

namespace X.App.Apis.sdk.svrs
{
    public class init : _sdk
    {
        [ParmsAttr(name = "服务名称", req = true)]
        public string name { get; set; }
        protected override XResp Execute()
        {
            var s = db.x_service.FirstOrDefault(o => o.name == name);
            if (s == null) throw new XExcep("T服务不存在");

            var path = Context.Server.MapPath("/svrs/" + name + "_new_" + s.service_id);
            if (!Directory.Exists(path)) throw new XExcep("T服务初始化失败，没有找到数据");

            updateSvr(path, s);
            getLayers(path, s);
            getBlocks(path, s);
            db.SubmitDBChanges();

            getShapes(path, s);

            db.SubmitDBChanges();

            return new XResp();
        }
        void updateSvr(string path, x_service s)
        {
            if (!File.Exists(path + "/svr.x")) throw new XExcep("T找不到服务配置文件");

            var data = Secret.XcDecode(File.ReadAllBytes(path + "/svr.x"), s.secret_key);
            if (data == null) throw new XExcep("T配置数据解密失败");

            var svr = Serialize.FromJson<Svr>(Encoding.UTF8.GetString(data));
            if (svr == null) throw new XExcep("T服务数据识别失败");

            //if (cfg.version < svr.Version) throw new XExcep("T服务端版本过低，请升级！");

            s.blocksize = svr.BlockSize;
            s.cache = Serialize.ToJson(svr.Cached);
            s.dir = svr.Dir;
            s.docinfo = Serialize.ToJson(svr.DocumentInfo);
            s.fullextend = Serialize.ToJson(svr.FullExtend);
            s.innerextend = Serialize.ToJson(svr.InitialExtend);
            s.version = svr.Version;
            s.watermark = Serialize.ToJson(svr.WaterMarked);
        }

        void getBlocks(string path, x_service s)
        {
            if (!Directory.Exists(path + "/图像") || !File.Exists(path + "/图像/000.x")) return;

            var data = Secret.XcDecode(File.ReadAllBytes(path + "/图像/000.x"), s.secret_key);
            if (data == null) return;

            var blocks = Serialize.FromJson<List<Block>>(Encoding.UTF8.GetString(data));
            if (blocks == null) return;

            foreach (var b in blocks)
            {
                if (!File.Exists(path + "/图像/" + b.file)) continue;

                data = File.ReadAllBytes(path + "/图像/" + b.file);
                data = Secret.XcDecode(data, s.secret_key);
                File.WriteAllBytes(path.Replace(name + "_new_" + s.service_id, name) + "/" + b.file, data);

                db.x_block.InsertOnSubmit(new x_block()
                {
                    file = b.file,
                    height = b.bound.Height,
                    service_id = s.service_id,
                    width = b.bound.Width,
                    level = b.level,
                    x = b.bound.X,
                    y = b.bound.Y
                });
            }
        }

        void getLayers(string path, x_service s)
        {
            if (!File.Exists(path + "/lays.x")) return;
            var data = Secret.XcDecode(File.ReadAllBytes(path + "/lays.x"), s.secret_key);
            if (data == null) return;

            var lays = Serialize.FromJson<List<ShpLayer>>(Encoding.UTF8.GetString(data));
            if (lays == null) return;

            foreach (var l in lays)
            {
                var lay = new x_layer()
                {
                    copy = l.Copyright,
                    desc = l.Desc,
                    service_id = s.service_id,
                    extend = Serialize.ToJson(l.Extends),
                    name = l.Name,
                    type = l.Tp
                };
                lay.drawstyle = Serialize.ToJson(l.Style);
                lay.fiedls = Serialize.ToJson(l.Fields);
                lay.id_field = l.IDField;
                lay.show_field = l.DiaplsyField;
                db.x_layer.InsertOnSubmit(lay);
            }
        }

        void getShapes(string path, x_service s)
        {
            if (!Directory.Exists(path + "/图形")) return;
            var fs = Directory.GetFiles(path + "/图形", "*.x");
            if (fs == null) return;
            foreach (var f in fs)
            {
                var data = Secret.XcDecode(File.ReadAllBytes(f), s.secret_key);
                if (data == null) return;//错误处理

                var shapes = Serialize.FromJson<List<Shape>>(Encoding.UTF8.GetString(data));
                if (shapes == null) return;//错误处理

                foreach (var sh in shapes)
                {
                    var g = new x_grid()
                    {
                        lat = (decimal)sh.Extent.xCenter,
                        lng = (decimal)sh.Extent.yCenter,
                        lno = sh.LayerNo,
                        name = sh.Name,
                        service_id = s.service_id,
                        style = Serialize.ToJson(sh.Style),
                        type = getTp(sh.Tp)
                    };
                    g.data = Serialize.ToJson(sh.Data);

                    var pts = new List<PointF>();
                    foreach (var k in sh.Points.Keys) pts.AddRange(sh.Points[k]);
                    g.points = Serialize.ToJson(pts.Select(o => new { lng = o.X, lat = o.Y }));
                    db.x_grid.InsertOnSubmit(g);
                }
                db.SubmitDBChanges();
            }
        }

        int getTp(int tp)
        {
            switch (tp)
            {
                case 1:
                    return 1;
                case 3:
                case 13:
                    return 3;
                case 5:
                case 15:
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
