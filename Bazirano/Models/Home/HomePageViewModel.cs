﻿using Bazirano.Models.News;
using Bazirano.Models.Board;
using System.Collections.Generic;
using Bazirano.Models.Column;

namespace Bazirano.Models.Home
{
    /// <summary>
    /// The viewmodel class used for displaying all home page elements.
    /// </summary>
    public class HomePageViewModel
    {
        /// <summary>
        /// The main post to display.
        /// </summary>
        public Article MainPost { get; set; }

        /// <summary>
        /// The list of popular posts to display.
        /// </summary>
        public List<Article> PopularPosts { get; set; }

        /// <summary>
        /// The list of board threads to display.
        /// </summary>
        public List<BoardThread> Threads { get; set; }

        public List<ColumnPost> ColumnPosts { get; set; }
    }
}
