using System.Collections;
using System.Collections.Generic;
using Testing.Models;

namespace Testing
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetAllReviews();
    }
}
