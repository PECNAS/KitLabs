using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class SegmentRepositoriesImpl : SegmentRepositories
    {
        private MobileContext _context;
        public SegmentRepositoriesImpl(MobileContext context)
        {
            this._context = context;
        }

        public List<Segment> GetSegments()
        {
            return _context.Segments.ToList();
        }

        public Segment GetSegById(int seg_id)
        {
            return _context.Segments.FirstOrDefault(x => x.Id == seg_id);
        }
    }
}
