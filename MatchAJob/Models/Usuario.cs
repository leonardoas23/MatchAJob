using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatchAJob.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Area { get; set; }
        public string Tipo { get; set; }
        public string Nivel { get; set; }
        public string Email { get; set; }
        public string Habilidades { get; set; }



       
        public List<Usuario> Lista()
        {
            var lista = new List<Usuario>();
            var usuarioDb = new UsuarioDB();
            {
                foreach (DataRow row in usuarioDb.Lista().Rows)
                {
                    var usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(row["id"]);

                    usuario.Nome = row["nome"].ToString();
                    usuario.Area = row["area"].ToString();
                    usuario.Tipo = row["tipo"].ToString();
                    usuario.Nivel = row["nivel"].ToString();
                    usuario.Email = row["email"].ToString();
                    usuario.Habilidades = row["habilidades"].ToString();

                    lista.Add(usuario);

                }
                return lista;
            }
        }

        public static Usuario BuscarId(int id)
        {
            var usuario = new Usuario();
            var usuarioDb = new UsuarioDB();
            {
                foreach (DataRow row in usuarioDb.BuscarId(id).Rows)
                {
                    usuario.Id = Convert.ToInt32(row["id"]);
                    usuario.Nome = row["nome"].ToString();
                    usuario.Area = row["area"].ToString();
                    usuario.Tipo = row["tipo"].ToString();
                    usuario.Nivel = row["nivel"].ToString();
                    usuario.Email = row["email"].ToString();
                    usuario.Habilidades = row["habilidades"].ToString();

                }

                return usuario;
            }
        }

        public void Save()
        {
            new UsuarioDB().Salvar(this.Id, this.Nome, this.Area, this.Tipo, this.Nivel, this.Email, this.Habilidades);
        }

        public static void Excluir(int id)
        {
            new UsuarioDB().Excluir(id);
        }

    }
}