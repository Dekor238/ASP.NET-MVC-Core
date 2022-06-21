using Lesson_1.DAL.Interfaces;
using Lesson_1.Emails;
using Lesson_1.Models;

namespace Lesson_1.Services;

public class ProductAddEmail : IProductAddEmail<Products>
{
    private readonly IProduct _product;
    private readonly IEmailService _emailService;

    public ProductAddEmail(IProduct product, IEmailService emailService)
    {
        _product = product;
        _emailService = emailService;
    }

    public void Add(Products product)
    {
        if (product.Id != 0)
        {
            _product.Add(product);
            _emailService.Send("dekor238@gmail.com", 
                "New Product add to Catalog", 
                $"New Product add to Catalog <br> {product}",
                "asp2022gb@rodion-m.ru");
        }
    }
}