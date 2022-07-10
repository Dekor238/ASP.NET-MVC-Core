using Lesson_1.DAL.Interfaces;
using Lesson_1.Emails;
using Lesson_1.Models;

namespace Lesson_1.Services;

public class ProductAddEmail : IProductAddEmail
{
    private readonly IProduct _product;
    private readonly IEmailService _emailService;
    private readonly ILogger<ProductAddEmail> _logger;

    public ProductAddEmail(IProduct product, IEmailService emailService, ILogger<ProductAddEmail> logger)
    {
        _product = product;
        _emailService = emailService;
        _logger = logger;
    }

    public void Add(Products product)
    {
        if (product.Id != 0)
        {
            _product.Add(product);
            try
            {
                _emailService.Send("New Product add to Catalog", 
                    $"New Product add to Catalog <br> " +
                    $"{product.Id} + {product.Name} + {product.Img}");
                _logger.LogInformation("Email send successfuly!");
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Email do not send");
            }
            
        }
    }
}