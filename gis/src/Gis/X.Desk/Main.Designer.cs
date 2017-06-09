namespace X.Desk
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ms_top = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_open = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_new = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_save = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_save_as = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.图层LToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.缩放到ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.底图管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更换底图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.天地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.矢量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.属性PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输出瓦片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spc_panel = new System.Windows.Forms.SplitContainer();
            this.tv_layers = new System.Windows.Forms.TreeView();
            this.cms_tv_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmi_newgroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_inport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_outtile = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_split1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_zoomTothis = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_split2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_remove = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmi_split4 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_prop = new System.Windows.Forms.ToolStripMenuItem();
            this.map1 = new AxInterop.MapWinGIS.AxMap();
            this.tlb_tip = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tpb_prog = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsl_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.tr_time = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_links = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spc_panel)).BeginInit();
            this.spc_panel.Panel1.SuspendLayout();
            this.spc_panel.Panel2.SuspendLayout();
            this.spc_panel.SuspendLayout();
            this.cms_tv_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.map1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_top
            // 
            this.ms_top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.图层LToolStripMenuItem,
            this.输出ToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.ms_top.Location = new System.Drawing.Point(0, 0);
            this.ms_top.Name = "ms_top";
            this.ms_top.Size = new System.Drawing.Size(921, 24);
            this.ms_top.TabIndex = 11;
            this.ms_top.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_open,
            this.tsmi_new,
            this.toolStripMenuItem2,
            this.tsmi_save,
            this.tsmi_save_as,
            this.toolStripMenuItem3,
            this.tsmi_links,
            this.toolStripSeparator2,
            this.tsmi_exit});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // tsmi_open
            // 
            this.tsmi_open.Name = "tsmi_open";
            this.tsmi_open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmi_open.Size = new System.Drawing.Size(201, 22);
            this.tsmi_open.Text = "打开(&O)";
            this.tsmi_open.Click += new System.EventHandler(this.tsmi_open_Click);
            // 
            // tsmi_new
            // 
            this.tsmi_new.Name = "tsmi_new";
            this.tsmi_new.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmi_new.Size = new System.Drawing.Size(201, 22);
            this.tsmi_new.Text = "新建(&N)";
            this.tsmi_new.Click += new System.EventHandler(this.tsmi_new_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(198, 6);
            // 
            // tsmi_save
            // 
            this.tsmi_save.Name = "tsmi_save";
            this.tsmi_save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmi_save.Size = new System.Drawing.Size(201, 22);
            this.tsmi_save.Text = "保存(&S)";
            this.tsmi_save.Click += new System.EventHandler(this.tsmi_save_Click);
            // 
            // tsmi_save_as
            // 
            this.tsmi_save_as.Name = "tsmi_save_as";
            this.tsmi_save_as.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsmi_save_as.Size = new System.Drawing.Size(201, 22);
            this.tsmi_save_as.Text = "另存为(&A)";
            this.tsmi_save_as.Click += new System.EventHandler(this.tsmi_save_as_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(198, 6);
            // 
            // tsmi_exit
            // 
            this.tsmi_exit.Name = "tsmi_exit";
            this.tsmi_exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmi_exit.Size = new System.Drawing.Size(201, 22);
            this.tsmi_exit.Text = "退出(&E)";
            this.tsmi_exit.Click += new System.EventHandler(this.tsmi_exit_Click);
            // 
            // 图层LToolStripMenuItem
            // 
            this.图层LToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加文件夹ToolStripMenuItem,
            this.toolStripMenuItem7,
            this.toolStripMenuItem4,
            this.缩放到ToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem11,
            this.toolStripMenuItem6,
            this.toolStripMenuItem8,
            this.底图管理ToolStripMenuItem,
            this.更换底图ToolStripMenuItem,
            this.toolStripMenuItem10,
            this.toolStripMenuItem9,
            this.属性PToolStripMenuItem});
            this.图层LToolStripMenuItem.Name = "图层LToolStripMenuItem";
            this.图层LToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.图层LToolStripMenuItem.Text = "图层(&L)";
            // 
            // 添加文件夹ToolStripMenuItem
            // 
            this.添加文件夹ToolStripMenuItem.Name = "添加文件夹ToolStripMenuItem";
            this.添加文件夹ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加文件夹ToolStripMenuItem.Text = "新建图层组";
            this.添加文件夹ToolStripMenuItem.Click += new System.EventHandler(this.tmi_newgroup_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem7.Text = "添加数据";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.tmi_inport_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
            // 
            // 缩放到ToolStripMenuItem
            // 
            this.缩放到ToolStripMenuItem.Name = "缩放到ToolStripMenuItem";
            this.缩放到ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.缩放到ToolStripMenuItem.Text = "缩放到图层";
            this.缩放到ToolStripMenuItem.Click += new System.EventHandler(this.tmi_zoomTothis_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem11.Text = "编辑(&E)";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "移除(&R)";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.tmi_remove_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(149, 6);
            // 
            // 底图管理ToolStripMenuItem
            // 
            this.底图管理ToolStripMenuItem.Enabled = false;
            this.底图管理ToolStripMenuItem.Name = "底图管理ToolStripMenuItem";
            this.底图管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.底图管理ToolStripMenuItem.Text = "底图管理";
            this.底图管理ToolStripMenuItem.Visible = false;
            // 
            // 更换底图ToolStripMenuItem
            // 
            this.更换底图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.天地图ToolStripMenuItem});
            this.更换底图ToolStripMenuItem.Name = "更换底图ToolStripMenuItem";
            this.更换底图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.更换底图ToolStripMenuItem.Text = "更换底图";
            // 
            // 天地图ToolStripMenuItem
            // 
            this.天地图ToolStripMenuItem.Checked = true;
            this.天地图ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.天地图ToolStripMenuItem.Name = "天地图ToolStripMenuItem";
            this.天地图ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.天地图ToolStripMenuItem.Text = "天地图";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.矢量ToolStripMenuItem,
            this.影像ToolStripMenuItem});
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem10.Text = "底图类型";
            // 
            // 矢量ToolStripMenuItem
            // 
            this.矢量ToolStripMenuItem.Checked = true;
            this.矢量ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.矢量ToolStripMenuItem.Name = "矢量ToolStripMenuItem";
            this.矢量ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.矢量ToolStripMenuItem.Text = "矢量";
            this.矢量ToolStripMenuItem.Click += new System.EventHandler(this.矢量ToolStripMenuItem_Click);
            // 
            // 影像ToolStripMenuItem
            // 
            this.影像ToolStripMenuItem.Name = "影像ToolStripMenuItem";
            this.影像ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.影像ToolStripMenuItem.Text = "影像";
            this.影像ToolStripMenuItem.Click += new System.EventHandler(this.影像ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(149, 6);
            // 
            // 属性PToolStripMenuItem
            // 
            this.属性PToolStripMenuItem.Name = "属性PToolStripMenuItem";
            this.属性PToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.属性PToolStripMenuItem.Text = "属性(&P)...";
            // 
            // 输出ToolStripMenuItem
            // 
            this.输出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输出瓦片ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.设置SToolStripMenuItem});
            this.输出ToolStripMenuItem.Name = "输出ToolStripMenuItem";
            this.输出ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.输出ToolStripMenuItem.Text = "输出(&O)";
            // 
            // 输出瓦片ToolStripMenuItem
            // 
            this.输出瓦片ToolStripMenuItem.Name = "输出瓦片ToolStripMenuItem";
            this.输出瓦片ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.输出瓦片ToolStripMenuItem.Text = "发布服务(&P)";
            this.输出瓦片ToolStripMenuItem.Click += new System.EventHandler(this.tmi_showpub_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // 设置SToolStripMenuItem
            // 
            this.设置SToolStripMenuItem.Name = "设置SToolStripMenuItem";
            this.设置SToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置SToolStripMenuItem.Text = "下载底图(&D)";
            this.设置SToolStripMenuItem.Click += new System.EventHandler(this.设置SToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // spc_panel
            // 
            this.spc_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spc_panel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spc_panel.Location = new System.Drawing.Point(4, 28);
            this.spc_panel.Name = "spc_panel";
            // 
            // spc_panel.Panel1
            // 
            this.spc_panel.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spc_panel.Panel1.Controls.Add(this.tv_layers);
            this.spc_panel.Panel1.Padding = new System.Windows.Forms.Padding(1);
            this.spc_panel.Panel1MinSize = 200;
            // 
            // spc_panel.Panel2
            // 
            this.spc_panel.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spc_panel.Panel2.Controls.Add(this.map1);
            this.spc_panel.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.spc_panel.Size = new System.Drawing.Size(912, 643);
            this.spc_panel.SplitterDistance = 200;
            this.spc_panel.TabIndex = 256;
            // 
            // tv_layers
            // 
            this.tv_layers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv_layers.CheckBoxes = true;
            this.tv_layers.ContextMenuStrip = this.cms_tv_menu;
            this.tv_layers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_layers.FullRowSelect = true;
            this.tv_layers.ItemHeight = 22;
            this.tv_layers.LabelEdit = true;
            this.tv_layers.Location = new System.Drawing.Point(1, 1);
            this.tv_layers.Name = "tv_layers";
            this.tv_layers.Size = new System.Drawing.Size(198, 641);
            this.tv_layers.TabIndex = 13;
            this.tv_layers.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tv_layers_AfterLabelEdit);
            this.tv_layers.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_layers_AfterCheck);
            this.tv_layers.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_layers_NodeMouseClick);
            this.tv_layers.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_layers_NodeMouseDoubleClick);
            // 
            // cms_tv_menu
            // 
            this.cms_tv_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmi_newgroup,
            this.tmi_inport,
            this.toolStripMenuItem5,
            this.tmi_outtile,
            this.tmi_split1,
            this.tmi_zoomTothis,
            this.tmi_split2,
            this.tmi_remove,
            this.tmi_edit,
            this.tmi_split4,
            this.tmi_prop});
            this.cms_tv_menu.Name = "cms_tv_menu";
            this.cms_tv_menu.Size = new System.Drawing.Size(137, 182);
            // 
            // tmi_newgroup
            // 
            this.tmi_newgroup.Name = "tmi_newgroup";
            this.tmi_newgroup.Size = new System.Drawing.Size(136, 22);
            this.tmi_newgroup.Text = "新建图层组";
            this.tmi_newgroup.Click += new System.EventHandler(this.tmi_newgroup_Click);
            // 
            // tmi_inport
            // 
            this.tmi_inport.Name = "tmi_inport";
            this.tmi_inport.Size = new System.Drawing.Size(136, 22);
            this.tmi_inport.Text = "添加数据";
            this.tmi_inport.Click += new System.EventHandler(this.tmi_inport_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(133, 6);
            // 
            // tmi_outtile
            // 
            this.tmi_outtile.Name = "tmi_outtile";
            this.tmi_outtile.Size = new System.Drawing.Size(136, 22);
            this.tmi_outtile.Text = "发布服务(&P)";
            this.tmi_outtile.Click += new System.EventHandler(this.tmi_showpub_Click);
            // 
            // tmi_split1
            // 
            this.tmi_split1.Name = "tmi_split1";
            this.tmi_split1.Size = new System.Drawing.Size(133, 6);
            // 
            // tmi_zoomTothis
            // 
            this.tmi_zoomTothis.Name = "tmi_zoomTothis";
            this.tmi_zoomTothis.Size = new System.Drawing.Size(136, 22);
            this.tmi_zoomTothis.Text = "缩放到图层";
            this.tmi_zoomTothis.Click += new System.EventHandler(this.tmi_zoomTothis_Click);
            // 
            // tmi_split2
            // 
            this.tmi_split2.Name = "tmi_split2";
            this.tmi_split2.Size = new System.Drawing.Size(133, 6);
            // 
            // tmi_remove
            // 
            this.tmi_remove.Name = "tmi_remove";
            this.tmi_remove.Size = new System.Drawing.Size(136, 22);
            this.tmi_remove.Text = "移除";
            this.tmi_remove.Click += new System.EventHandler(this.tmi_remove_Click);
            // 
            // tmi_edit
            // 
            this.tmi_edit.Name = "tmi_edit";
            this.tmi_edit.Size = new System.Drawing.Size(136, 22);
            this.tmi_edit.Text = "编辑";
            this.tmi_edit.Click += new System.EventHandler(this.tmi_edit_Click);
            // 
            // tmi_split4
            // 
            this.tmi_split4.Name = "tmi_split4";
            this.tmi_split4.Size = new System.Drawing.Size(133, 6);
            // 
            // tmi_prop
            // 
            this.tmi_prop.Name = "tmi_prop";
            this.tmi_prop.Size = new System.Drawing.Size(136, 22);
            this.tmi_prop.Text = "属性(&P)...";
            // 
            // map1
            // 
            this.map1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map1.Enabled = true;
            this.map1.Location = new System.Drawing.Point(1, 1);
            this.map1.Name = "map1";
            this.map1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("map1.OcxState")));
            this.map1.Size = new System.Drawing.Size(706, 641);
            this.map1.TabIndex = 1;
            // 
            // tlb_tip
            // 
            this.tlb_tip.Name = "tlb_tip";
            this.tlb_tip.Size = new System.Drawing.Size(787, 17);
            this.tlb_tip.Spring = true;
            this.tlb_tip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlb_tip,
            this.tpb_prog,
            this.tsl_time});
            this.statusStrip1.Location = new System.Drawing.Point(0, 674);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(921, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tpb_prog
            // 
            this.tpb_prog.Name = "tpb_prog";
            this.tpb_prog.Size = new System.Drawing.Size(0, 17);
            this.tpb_prog.Visible = false;
            // 
            // tsl_time
            // 
            this.tsl_time.Name = "tsl_time";
            this.tsl_time.Size = new System.Drawing.Size(119, 17);
            this.tsl_time.Text = "2016-09-09 12:00:00";
            // 
            // tr_time
            // 
            this.tr_time.Enabled = true;
            this.tr_time.Interval = 1;
            this.tr_time.Tick += new System.EventHandler(this.tr_time_Tick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(198, 6);
            // 
            // tsmi_links
            // 
            this.tsmi_links.Name = "tsmi_links";
            this.tsmi_links.Size = new System.Drawing.Size(201, 22);
            this.tsmi_links.Text = "服务链接管理(&L)";
            this.tsmi_links.Click += new System.EventHandler(this.tsmi_links_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 696);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.spc_panel);
            this.Controls.Add(this.ms_top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ms_top;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YtTiler 切图软件 V1.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ms_top.ResumeLayout(false);
            this.ms_top.PerformLayout();
            this.spc_panel.Panel1.ResumeLayout(false);
            this.spc_panel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spc_panel)).EndInit();
            this.spc_panel.ResumeLayout(false);
            this.cms_tv_menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.map1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip ms_top;
        private System.Windows.Forms.ToolStripMenuItem 图层LToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输出瓦片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 设置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_open;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_save;
        private System.Windows.Forms.ToolStripMenuItem tsmi_save_as;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmi_exit;
        private System.Windows.Forms.SplitContainer spc_panel;
        private System.Windows.Forms.TreeView tv_layers;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmi_new;
        private System.Windows.Forms.ContextMenuStrip cms_tv_menu;
        private System.Windows.Forms.ToolStripMenuItem tmi_inport;
        private System.Windows.Forms.ToolStripSeparator tmi_split2;
        private System.Windows.Forms.ToolStripMenuItem tmi_remove;
        private System.Windows.Forms.ToolStripSeparator tmi_split1;
        private System.Windows.Forms.ToolStripMenuItem tmi_zoomTothis;
        private System.Windows.Forms.ToolStripSeparator tmi_split4;
        private System.Windows.Forms.ToolStripMenuItem tmi_prop;
        private System.Windows.Forms.ToolStripMenuItem tmi_newgroup;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tmi_outtile;
        private System.Windows.Forms.ToolStripMenuItem 底图管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem 缩放到ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem 更换底图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tlb_tip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem tmi_edit;
        private System.Windows.Forms.ToolStripStatusLabel tpb_prog;
        private System.Windows.Forms.ToolStripStatusLabel tsl_time;
        private AxInterop.MapWinGIS.AxMap map1;
        private System.Windows.Forms.Timer tr_time;
        private System.Windows.Forms.ToolStripMenuItem 天地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem 属性PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem 矢量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_links;
    }
}

