using System;
using Livraria.Application.Interfaces;
using Livraria.Application.ViewModels;
using Livraria.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.UI.Site.Controllers
{
    public class LivroController : BaseController
    {
        private readonly ILivroAppService _livroAppService;

        public LivroController(ILivroAppService livroAppService, 
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _livroAppService = livroAppService;
        }

        [HttpGet]
        [Route("livros/listar-todos")]
        public IActionResult Index()
        {
            return View(_livroAppService.GetAll());
        }

        [HttpGet]
        [Route("livros/detalhes/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroViewModel = _livroAppService.GetById(id.Value);

            if (livroViewModel == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        [HttpGet]
        [Route("livros/novo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("livros/novo")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LivroViewModel livroViewModel)
        {
            if (!ModelState.IsValid) return View(livroViewModel);

            _livroAppService.Register(livroViewModel);

            if (IsValidOperation())
            {
                ViewBag.Sucesso = "Livro cadastrado!";
                return RedirectToAction("Index");
            }

            return View(livroViewModel);
        }
        
        [HttpGet]
        [Route("livros/editar/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroViewModel = _livroAppService.GetById(id.Value);

            if (livroViewModel == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        [HttpPost]
        [Route("livros/editar/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LivroViewModel livroViewModel)
        {
            if (!ModelState.IsValid) return View(livroViewModel);

            _livroAppService.Update(livroViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Livro atualizado!";

            return View(livroViewModel);
        }

        [HttpGet]
        [Route("livros/remover/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livroViewModel = _livroAppService.GetById(id.Value);

            if (livroViewModel == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Route("livros/remover/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _livroAppService.Remove(id);

            if (!IsValidOperation()) return View(_livroAppService.GetById(id));

            ViewBag.Sucesso = "Livro removido!";
            return RedirectToAction("Index");
        }

    }
}
