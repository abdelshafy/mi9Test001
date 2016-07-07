using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MI9.Models.appdomain;

namespace MI9.Models.utilities
{
    public static class Helper
    {

        public static Response[] FilterAndGenerateResponse(Request req)
        {
            int counter = 0;

            try
            {

                List<dynamic> movies = req.payload.Where(p => p.drm == true && p.episodeCount > 0).ToList();

                Response[] responses = new Response[movies.Count()];


                foreach (dynamic movie in movies)
                {


                    responses[counter] = new Response { image = movie.image.showImage, slug = movie.slug, title = movie.title };

                    counter++;


                }

                return responses;
            }
            catch(Exception ex)
            {

                throw new HttpException(400, "bad request");

            }            
        }
    }
}