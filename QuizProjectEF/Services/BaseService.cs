

using QuizProjectEF.DBEntity;

namespace QuizProjectEF.Services;

public class BaseService
{
    protected QuizDBContext _context;
    public BaseService(QuizDBContext context)
    {
        _context = context;
    }
}
