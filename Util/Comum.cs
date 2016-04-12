using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Transportadora.Models;

namespace Transportadora.Util
{
    public class Comum
    {
        public static Usuario UsuarioLogado()
        {
            var usuario = (Usuario)HttpContext.Current.Session["UsuarioLogado"];
            return (usuario == null ? new Usuario() : usuario);
        }
        public static void GravarUsuarioLogado(Usuario usuario)
        {
            HttpContext.Current.Session["UsuarioLogado"] = usuario;
        }
    }
}
