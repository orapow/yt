﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.SessionState;

using X.Core;
using X.Core.Plugin;
using X.Core.Utility;
using X.Web.Com;

namespace X.Web
{
    public class XApp : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext c)
        {
            var v = c.Request.QueryString["v"].ToLower().Replace("/", ".");
            var t = int.Parse(c.Request.QueryString["t"]);
            var data = (byte[])null;
            XFace face = null;
            var assb = Assembly.Load("X.App");
            try
            {
                face = assb.CreateInstance(String.Format("X.App.{0}.{1}", (t == 1 ? "Views" : "Apis"), v)) as XFace;
                if (face == null) throw new XExcep((t == 1 ? "0x0001" : "0x0002"), v);
                face.Init(c);
                data = face.GetResponse();
            }
            catch (XExcep fe)
            {
                var rsp = new XResp(fe.ErrCode, fe.ErrMsg);
                if (t == 1)
                {
                    var view = assb.CreateInstance("X.App.Views.com.err") as Views.View;
                    var html = "<html><head><meta http-equiv=\"Content-Type]\" content=\"text/html;charset=utf-8\" /></head><body>{body}</body></html>";
                    if (view == null)
                    {
                        data = Encoding.UTF8.GetBytes(html.Replace("{body}", Serialize.ToJson(rsp)));
                    }
                    else
                    {
                        view.Init(c);
                        view.dict.Add("rsp", rsp);
                        view.dict.Add("backurl", Secret.ToBase64(c.Request.RawUrl));
                        data = view.GetResponse();
                    }
                }
                else
                {
                    data = Encoding.UTF8.GetBytes(Serialize.ToJson(rsp));
                }
                if (fe.ErrCode != "0x0001") Loger.Error(Serialize.ToJson(rsp));
            }
            catch (Exception ex)
            {
                if (ex is ThreadAbortException) return;
                var resp = new XResp(Guid.NewGuid().ToString(), ex.Message);
                data = Encoding.UTF8.GetBytes(Serialize.ToJson(resp) + "\r\n" + Serialize.ToJson(ex));
                Loger.Fatal(GetType(), ex);
            }

            if (data != null)
            {
                c.Response.Clear();
                c.Response.HeaderEncoding = Encoding.UTF8;
                c.Response.ContentEncoding = Encoding.UTF8;
                c.Response.OutputStream.Write(data, 0, data.Length);
                c.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
