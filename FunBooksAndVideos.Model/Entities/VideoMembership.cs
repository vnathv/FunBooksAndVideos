﻿using FunBooksAndVideos.Model.Interfaces;

namespace FunBooksAndVideos.Model.Entities
{
    public class VideoMembership : INonPhysicalProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductCost { get; set; }
    }
}
