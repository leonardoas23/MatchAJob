using MatchAJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatchAJob.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Registrar()
        {
            return View();
        }      

        public ActionResult Perfis()
        {
           ViewBag.Usuarios = new Usuario().Lista();

            return View();
        }

        [HttpPost]
        public void Cadastrar()
        {
            var usuario = new Usuario();

            usuario.Nome = Request["nome"];
            usuario.Area = Request["area"];
            usuario.Tipo = Request["tipo"];
            usuario.Nivel = Request["nivel"];
            usuario.Email = Request["email"];
            usuario.Habilidades = Request["habilidades"];

            usuario.Save();

            Response.Redirect("/usuario/perfis");
        }

        public ActionResult Alterar(int id)
        {
            var usuario = Usuario.BuscarId(id);
            ViewBag.Usuario = usuario;
            return View();
        }

        [HttpPost]
        public void Editar(int id)
        {
            try {
                var usuario = Usuario.BuscarId(id);

                usuario.Nome = Request["nome"];
                usuario.Area = Request["area"];
                usuario.Tipo = Request["tipo"];
                usuario.Nivel = Request["nivel"];
                usuario.Email = Request["email"];
                usuario.Habilidades = Request["habilidades"];

                usuario.Save();

                TempData["Sucesso"] = "Alteracao realizada com sucesso";
            }
            catch {
                TempData["Erro"] = "Falha durante o processo de alteracao";
                    }
            Response.Redirect("/Usuario/Perfis");
        }
        public void Excluir (int id)
        {
            Usuario.Excluir(id);

            Response.Redirect("/Usuario/Perfis");
        }
    }
}