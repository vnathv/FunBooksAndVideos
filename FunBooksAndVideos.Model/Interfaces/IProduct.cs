﻿namespace FunBooksAndVideos.Model.Interfaces
{
    public interface IProduct
    {
        int ProductId { get; set; }
        string ProductName { get; set; }
        double ProductCost { get; set; }
    }
}
