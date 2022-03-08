﻿using FNews.Services.Articles;
using FNews.ViewModels.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FNews.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public IActionResult All()
        {
            var articles = articleService.GetAll();
            return this.View(articles);
        }

        [Authorize]
        public IActionResult Create()
            => this.View();

        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateArticleInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                articleService.CreateArticle(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error");
            }

            return RedirectToAction("All", "Articles");
        }
    }
}