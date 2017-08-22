using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace Don.Sportsstore.Products.Dtos
{
    [AutoMap(typeof(Product))]
    // public class UpdateProductInput: IDoublyWayDto
    // public class UpdateProductInput : ProductDto //todo play with dto inheritance - checkj required attributes 
    public class CreateUpdateProductInput: Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
//Doubleways DTOhttps://aspnetboilerplate.com/Pages/Documents/Object-To-Object-Mapping#creating-mappings
//https://forum.aspnetboilerplate.com/viewtopic.php?f=2&t=244&p=690&hilit=crud#p690
//Blog-module
//https://github.com/aspnetboilerplate/sample-blog-module/blob/master/src/Abp.Samples.Blog.Application/Application/Services/CrudAppService.cs