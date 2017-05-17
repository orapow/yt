YT.DOTS_PER_INCH = 96;

YT.INCHES_PER_UNIT["千米"] = YT.INCHES_PER_UNIT["km"];
YT.INCHES_PER_UNIT["米"] = YT.INCHES_PER_UNIT["m"];
YT.INCHES_PER_UNIT["英里"] = YT.INCHES_PER_UNIT["mi"];
YT.INCHES_PER_UNIT["英尺"] = YT.INCHES_PER_UNIT["ft"];

Xc = {
    Init: function (map) {

        this.map = map;
        map.addLayer(Xc.Layers.VecLayer);
        map.addLayer(Xc.Layers.ImgLayer);
        map.addLayer(Xc.Layers.GraLayer);

        map.setLayerIndex(Xc.Layers.VecLayer, 1);
        map.setLayerIndex(Xc.Layers.ImgLayer, 1);
        map.setLayerIndex(Xc.Layers.GraLayer, 2);

        map.setCenter(map.options.center.pt, map.options.center.z);

        Xc.Layers.Init();
        Xc.Shape.Style = {
            strokeColor: "",
            strokeOpacity: 1,
            strokeWidth: 1,
            strokeLinecap: "butt", //round | square
            fillColor: "#000",
            fillOpacity: 1
        };
        Xc.Shape.Init(map.getExtent());

    }
};
Xc.Layers = {
    VecLayer: new YT.Layer.XYZ("矢量",
    [
        "http://cut.tiler.591map.net/tiler/tdt--0-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt--1-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt--2-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt--3-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt--4-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt--5-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt--6-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt--7-${x}-${y}-${z}.html"
    ], {
        isBaseLayer: true,
        visibility: true,
        displayInLayerSwitcher: true
    }),
    ImgLayer: new YT.Layer.XYZ("影像",
    [
        "http://cut.tiler.591map.net/tiler/tdt-img_c-0-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt-img_c-1-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt-img_c-2-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt-img_c-3-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt-img_c-4-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt-img_c-5-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt-img_c-6-${x}-${y}-${z}.html",
        "http://cut.tiler.591map.net/tiler/tdt-img_c-7-${x}-${y}-${z}.html"
    ], {
        isBaseLayer: true,
        visibility: true,
        displayInLayerSwitcher: true
    }),
    GraLayer: new YT.Layer.Vector("GraLayer", { style: YT.Util.extend({}, YT.Feature.Vector.style['default']) }),
    ShowVec: function () {
        Xc.map.removeLayer(this.ImgLayer);
        Xc.map.addLayer(this.VecLayer);
    },
    ShowImg: function () {
        Xc.map.removeLayer(this.VecLayer);
        Xc.map.addLayer(this.ImgLayer);
    },
    Init: function () {
        var list = this.Load();
        if (!list) return;

        for (var i in list) {
            var ly = list[i];
            var lay = new YT.Layer.XYZ(
                 ly.name,
                 [ly.url],
                 {
                     visibility: true,
                     displayInLayerSwitcher: true
                 }
             )
            map.addLayer(lay);
            map.setLayerIndex(lay, ly.sort);
        }
    },
    Load: function () {
        console.log("请重写Xc.Layers.Load方法来加载自定义图层。");
    }
}
Xc.Shape = {
    SetStyle: function (style, shape) {
        shape.strokeColor = style.strokeColor;
        shape.strokeOpacity = style.strokeOpacity;
        shape.strokeWidth = style.strokeWidth;
        shape.strokeLinecap = style.strokeLinecap;
        shape.fillColor = style.fillColor;
        shape.fillOpacity = style.fillOpacity;
        Xc.Layers.GraLayer.redraw();
    },
    Init: function () {
        var list = this.Load();
        if (!list) return;

        for (var i in list) {
            var sp = list[i];
            var fe = null;

            switch (sp.tp) {
                case 1://线
                    fe = new YT.Geometry.LineString(getpoints(sp.points));
                    break;
                case 2://圆
                    fe = new YT.Geometry.Polygon.createRegularPolygon(new YT.Geometry.Point(sp.lng, sp.lat), sp.radius, 100, 0);
                    break;
                case 3://多边形
                    fe = new YT.Geometry.Polygon([new YT.Geometry.LinearRing([getpoints(sp.points)])]);
                    break;
            }
            var st = sp.style ? JSON.parse(sp.style) : Xc.Shape.Style;
            Xc.Layers.GraLayer.addFeatures([new YT.Feature.Vector(fe, null, st)]);
        }

        function getpoints(ptstr) {
            var pts = [];
            var ptarr = ptstr.split(";");
            for (var i in ptarrt) {
                var pt = ptattr[i].split(",");
                if (pt.length != 2) continue;
                pts.push(new YT.Geometry.Point(parseFloat(pt[0]), parseFloat(pt[0])))
            }
            return pts;
        }

    },
    Load: function () {
        console.log("请重写Xc.Shape.Load方法来加载图形，当前范围：" + extent);
    },
    Edit: function (shape) {
        console.log("请重写Xc.Shape.Edit方法来获取修改后的图形数据，当前图形：" + shape);
    }
}