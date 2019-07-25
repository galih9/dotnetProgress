using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projecOne.Models.Param;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace projectOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController
    {
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get([FromQuery]GetBookParam param)
        {
            var dataSource = new Book[] {
             new Book {
                 Title = "Harry Potter",
                 Date = DateTime.Now
             },
             new Book {
                 Title = "Lion King",
                 Date = DateTime.Now
             }
            };
            if (string.IsNullOrEmpty(param.Title))
            {
                return dataSource;
            }
            return dataSource
            .Where(item => item.Title.ToLower().Contains(param.Title.ToLower()))
            .ToList();
        }

        [HttpPost]
        public ActionResult<IEnumerable<Book>> Post([FromBody]Book param)
        {
            var dataSource = new List<Book> {
             new Book {
                 Title = "Harry Potter",
                 Date = DateTime.Now
             },
             new Book {
                 Title = "Lion King",
                 Date = DateTime.Now
             }
            };

             dataSource.Add(new Book { Title = param.Title, Date = param.Date });
             return dataSource;
        }
        // [HttpGet("{id}")]
        // public ActionResult<Book> Get([FromQuery]GetBookParam param)
        // {
        //     var dataSource = new Book[] {
        //      new Book {
        //          Id = 1,
        //          Title = "Harry Potter",
        //          Date = DateTime.Now
        //      },
        //      new Book {
        //          Id = 2,
        //          Title = "Lion King",
        //          Date = DateTime.Now
        //      }
        //     };
        //     if (string.IsNullOrEmpty(param.Title))
        //     {
        //         // return dataSource;
        //     }
        // }
    }
}