﻿namespace BookstoreApp.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? ISBN { get; set; }
    public int AuthoId { get; set; }
    public int CategoryId { get; set; }
    public decimal? Price { get; set; }
    public int StockQuantity { get; set; }
}
