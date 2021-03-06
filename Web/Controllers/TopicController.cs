﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Facades;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class TopicController : Controller
    {

        private readonly TopicFacade topicFacade;

        public TopicController(TopicFacade topicFacade)
        {
            this.topicFacade = topicFacade;
        }

        // GET: Topic
        [Authorize(Roles = "Teacher")]
        public ActionResult Index()
        {
            var topicViewModel = new TopicViewModel()
            {
                Topics = topicFacade.ListAll()
            };
            return View(topicViewModel);
        }

        // GET: Topic/Create
        [Authorize(Roles = "Teacher")]
        public ActionResult Create()
        {
            var topicEditViewModel = new TopicEditViewModel()
            {
                Topics = topicFacade.ListAll()
            };
            return View(topicEditViewModel);
        }

        // POST: Topic/Create
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult Create(TopicEditViewModel model)
        {
            try
            {
                topicFacade.Create(model.Topic, model.SelectedParent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Topic/Edit/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int id)
        {
            var topicEditViewModel = new TopicEditViewModel()
            {
                Topic = topicFacade.FindById(id),
                Topics = topicFacade.ListAll()
            };
            return View(topicEditViewModel);
        }

        // POST: Topic/Edit/5
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult Edit(TopicEditViewModel model)
        {
            try
            {
                topicFacade.Update(model.Topic, model.SelectedParent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Topic/Delete/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Delete(int id)
        {
            topicFacade.RemoveById(id);
            return RedirectToAction("Index");
        }
    }
}
