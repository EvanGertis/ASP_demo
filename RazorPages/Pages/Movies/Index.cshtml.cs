﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPages.Models;

namespace RazorPages.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPages.Models.RazorPagesContext _context;

        public IndexModel(RazorPages.Models.RazorPagesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        //SearchString contains the text users enter in the search text box.
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        //Requires Microsoft.Asp.NetCore.Mvc.Rendering
        //Genres contains the list of genres. Allows the user to select from a list.
        public SelectList Genres { get; set; }

        //MovieGenre contains the specific genre the user selects.
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            //LINQ to get list of generes.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            //contains a list of movies.
            var movies = from m in _context.Movie
                         select m;

            //completes the users search.
            if (!string.IsNullOrEmpty(SearchString)) {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            //completes the genere users search.
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            //update Genres object from search.
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            //update the movie object from the search.
            Movie = await movies.ToListAsync();
        }
    }
}
