﻿using System.Diagnostics;
using System.Windows.Forms;

namespace ContextMenuManager.Controls.Interfaces
{
    interface ITsiWebSearchItem
    {
        string SearchText { get; }
        WebSearchMenuItem TsiSearch { get; set; }
    }

    sealed class WebSearchMenuItem : ToolStripMenuItem
    {
        public WebSearchMenuItem(ITsiWebSearchItem item) : base(AppString.Menu.WebSearch)
        {
            this.Click += (sender, e) => WebSearch(item.SearchText);
        }

        public static void WebSearch(string text)
        {
            //替换网址转义符
            text = text.Replace("%", "%25").Replace("#", "%23").Replace("&", "%26").Replace("+", "%2B");
            Process.Start(AppConfig.EngineUrl.Replace("%s", text));
        }
    }
}