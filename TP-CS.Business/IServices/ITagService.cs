using TP_CS.Business.Models;

namespace TP_CS.Business.IServices;

public interface ITagService
{
    BusinessResult<Tag> GetTagById(long id);
    BusinessResult<IEnumerable<Tag>> GetTags();
    BusinessResult<Tag> CreateTag(Tag label);
    BusinessResult UpdateTag(Tag label, long id);
    BusinessResult DeleteTag(long id);
    BusinessResult<List<Tag>> SearchTag(string keyword);
}