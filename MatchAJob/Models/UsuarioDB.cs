using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MatchAJob.Models
{
    public class UsuarioDB
    {
        private string sqlConn()
        {
            {
                return ConfigurationManager.AppSettings["sqlConn"];

            }

        }
        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from usuarios";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;

            }            
        
                    
                    }

        public void Salvar(int id, string nome, string area, string tipo, string nivel, string email, string habilidades)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "insert into usuarios(nome, area, tipo, nivel, email, habilidades) values ('" + nome + "', '" + area + "', '" + tipo + "', '" + nivel + "', '" + email + "', '" + habilidades + "')";
                if (id != 0)
                {
                    queryString = "update usuarios set nome = '" + nome + "', area= '" + area + "', tipo='" + tipo + "', nivel='" + nivel + "',email= '" + email + "', habilidades= '" + habilidades + "' where id=" + id;
                }
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscarId(int id)
        {
            using (SqlConnection connection = new SqlConnection (sqlConn()))
            {
                string queryString = "select * from usuarios where id =" + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;

            }
        }

        public void Excluir(int id )
        {
            using(SqlConnection connection = new SqlConnection (sqlConn()))
            {
                string queryString = "delete from usuarios where id=" + id;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}