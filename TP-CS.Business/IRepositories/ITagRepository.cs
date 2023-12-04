using TP_CS.Business.Models;

namespace TP_CS.Business.IRepositories;

public interface ITagRepository
{
    IEnumerable<Tag>? GetTags();
    Tag GetTagById(long id);
    void CreateTag(Tag label, UserTask task);
    BusinessResult<Tag> UpdateTag(Tag label, long id);
    void DeleteTag(long id);
    IEnumerable<Tag>? SearchTag(string keyword);
}