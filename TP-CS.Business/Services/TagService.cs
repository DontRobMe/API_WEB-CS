using System;
using System.Collections.Generic;
using TP_CS.Business.IRepositories;
using TP_CS.Business.IServices;
using TP_CS.Business.Models;

namespace TP_CS.Business.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
        }

        public BusinessResult<Tag> GetTagById(long id)
        {
            var tag = _tagRepository.GetTagById(id);
            return BusinessResult<Tag>.FromSuccess(tag);
        }

        public BusinessResult<IEnumerable<Tag>> GetTags()
        {
            var tags = _tagRepository.GetTags();
            return BusinessResult<IEnumerable<Tag>>.FromSuccess(tags);
        }

        public BusinessResult<Tag> CreateTag(Tag tag)
        {
            _tagRepository.CreateTag(tag);
            return BusinessResult<Tag>.FromSuccess(tag);
        }

        public BusinessResult UpdateTag(Tag tag, long id)
        {
            var existingTag = _tagRepository.UpdateTag(tag, id);
            return BusinessResult.FromSuccess(existingTag);
        }

        public BusinessResult DeleteTag(long id)
        {
            _tagRepository.DeleteTag(id);
            return BusinessResult.FromSuccess();
        }
        
        public BusinessResult<List<Tag>> SearchTag(string keyword)
        {
            var matchingTasks = _tagRepository.SearchTag(keyword);
            return BusinessResult<List<Tag>>.FromSuccess(matchingTasks?.ToList());
        }
    }
}