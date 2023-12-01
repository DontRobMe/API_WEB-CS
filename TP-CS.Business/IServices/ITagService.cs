using TP_CS.Business.Models;

namespace TP_CS.Business.IServices;

public interface ITagService
{
    BusinessResult<Tag> GetTagById(long id);
    BusinessResult<IEnumerable<Tag>> GetTags();
    BusinessResult<Tag> CreateTag(Tag label);
    BusinessResult UpdateTag(Tag label);
    BusinessResult DeleteTag(long id);   
}