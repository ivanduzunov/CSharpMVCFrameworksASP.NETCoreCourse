﻿namespace UndergroundStation.Services.Forum
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IArticleService
    {
        Task<bool> Create(string title, string content, string authorId, int forumThemeId, DateTime publishedDate, int motherArticleId);
    }
}