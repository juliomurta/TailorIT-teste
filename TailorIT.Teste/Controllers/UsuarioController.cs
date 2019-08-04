using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TailorIT.Teste.Models;
using TailorIT.Teste.Models.ViewModels;
using TailorIT.Teste.Repository;

namespace TailorIT.Teste.Controllers
{
    public class UsuarioController : Controller
    {
        private IRepository<Usuario> usuarioRepository = null;
        private IRepository<Sexo> sexoRepository = null;

        public UsuarioController(IRepository<Usuario> usrRepository, IRepository<Sexo> sxRepository)
        {
            this.usuarioRepository = usrRepository;
            this.sexoRepository = sxRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var usuarios = this.usuarioRepository.Listar().Select(x =>
            {
                return new UsuarioViewModel(x);
            }).ToList();

            var relatorioViewModel = new RelatorioViewModel
            {
                Usuarios = usuarios,
                Filtros = new FiltrosViewModel()
            };

            return View(relatorioViewModel);
        }

        [HttpPost]
        public IActionResult Listar(FiltrosViewModel filtros)
        {
            var usuarios = new List<Usuario>();
            if (!string.IsNullOrEmpty(filtros.Ativo))
            {
                usuarios = this.usuarioRepository.Listar(x => !string.IsNullOrEmpty(filtros.Nome) ? x.Nome.ToLower().Contains(filtros.Nome.ToLower()) : true &&
                                                             (filtros.Ativo == "1" && x.Ativo ||
                                                              filtros.Ativo == "2" && !x.Ativo));
            }
            else
            {
                usuarios = this.usuarioRepository.Listar(x => !string.IsNullOrEmpty(filtros.Nome) ? x.Nome.ToLower().Contains(filtros.Nome.ToLower()) : true);
            }

            var relatorioViewModel = new RelatorioViewModel
            {
                Usuarios = usuarios.Select(x =>
                {
                    return new UsuarioViewModel(x);
                }).ToList(),
                Filtros = filtros
            };

            return View(relatorioViewModel);
        }

        [HttpGet]
        public IActionResult Inserir()
        {
            var sexos = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "",
                    Selected = true,
                    Text = "Selecione um item"
                }
            };

            sexos.AddRange(this.sexoRepository.Listar().Select(s =>
            {
                return new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Descricao.ToString()
                };
            }));

            ViewBag.Sexos = sexos;
            return View(new UsuarioViewModel());
        }

        [HttpPost]
        public IActionResult Inserir(UsuarioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var usuario = model.GetUsuario();
                    usuario.Ativo = true;
                    this.usuarioRepository.Inserir(usuario);
                    TempData["resultadoSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Listar");

                }

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["resultadoErro"] = $"Ocorreu um erro durante o processamento. Mensagem: {ex.Message}";
                return RedirectToAction("Listar");
            }
        }
    }
}