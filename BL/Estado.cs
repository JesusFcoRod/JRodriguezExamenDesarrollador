using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JrodriguezExamenDesarroladorContext contex = new DL.JrodriguezExamenDesarroladorContext())
                {
                    var query = contex.CatEntidadFederativas.FromSqlRaw("[EstadoGetAll]").ToList();

                    result.Objects = new List<object>();

                    foreach (var item in query)
                    {
                        ML.Estado estado = new ML.Estado();
                        estado.idEstado = item.IdEstado;
                        estado.Nombre = item.Estado;

                        result.Objects.Add(estado);
                    }
                    result.Correct = true;
                }

            }
            catch(Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
