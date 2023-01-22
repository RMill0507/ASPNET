using Dapper;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Testing.Models;

namespace Testing
{
    public class ReviewsRepository : IReviewRepository
    {
        private readonly IDbConnection _conn;

        public ReviewsRepository(IDbConnection conn)
        {
            _conn = conn;   
        }
        public IEnumerable<Review> GetAllReviews()
        {
            return _conn.Query<Review>("SELECT * FROM REVIEWS");
        }

       
    }
}
