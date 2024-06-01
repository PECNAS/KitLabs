using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface SegmentRepositories
    {
        public List<Segment> GetSegments();
    }
}
