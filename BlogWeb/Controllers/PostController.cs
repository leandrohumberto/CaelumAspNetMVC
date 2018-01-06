﻿using BlogWeb.DAO;
using BlogWeb.Filters;
using BlogWeb.Infra;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    [AutorizacaoFilter]
    public class PostController : Controller
    {
        private IPostDAO<Post> _postDAO;
        private IUsuarioDAO<Usuario> _usuarioDAO;

        public PostController(IPostDAO<Post> postDAO, IUsuarioDAO<Usuario> usuarioDAO)
        {
            _postDAO = postDAO;
            _usuarioDAO = usuarioDAO;
        }

        // GET: Post
        [Route("posts", Name = "ListaPosts")]
        public ActionResult Index()
        {
            IList<Post> posts = _postDAO.Lista();
            return View(posts);
        }

        public ActionResult Form()
        {
            ViewBag.Usuarios = _usuarioDAO.Lista();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(PostModel viewModel)
        {
            ExecutarValidacoesComplexas(viewModel);
            
            if (ModelState.IsValid)
            {
                var post = viewModel.CriaPost();
                _postDAO.Adiciona(post);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Usuarios = _usuarioDAO.Lista();
                return View("Form", viewModel);
            }
        }

        public ActionResult Remove(int id)
        {
            Post post = _postDAO.BuscaPorId(id);
            _postDAO.Remove(post);
            return RedirectToAction(nameof(Index));
        }

        [Route("posts/{id}", Name = "VisualizaPost")]
        public ActionResult Visualiza(int id)
        {
            Post post = _postDAO.BuscaPorId(id);
            PostModel viewModel = new PostModel(post);
            ViewBag.Usuarios = _usuarioDAO.Lista();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Altera(PostModel viewModel)
        {
            ExecutarValidacoesComplexas(viewModel);
            
            if (ModelState.IsValid)
            {
                var post = viewModel.CriaPost();
                _postDAO.Atualiza(post);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Usuarios = _usuarioDAO.Lista();
                return View("Visualiza", viewModel);
            }
        }

        public ActionResult Publica(int id)
        {
            Post post = _postDAO.BuscaPorId(id);
            post.Publicado = true;
            post.DataPublicacao = DateTime.Now;
            _postDAO.Atualiza(post);
            return new EmptyResult();
        }

        private void ExecutarValidacoesComplexas(PostModel viewModel)
        {
            if (viewModel.Publicado && !viewModel.DataPublicacao.HasValue)
            {
                ModelState.AddModelError("post.Invalido", "Posts publicados precisam de data de publicação");
            }
        }
    }
}