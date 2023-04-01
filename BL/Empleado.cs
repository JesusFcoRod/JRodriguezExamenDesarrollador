using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JrodriguezExamenDesarroladorContext contex = new DL.JrodriguezExamenDesarroladorContext())
                {
                    var query = contex.Database.ExecuteSqlRaw($"[EmpleadoAdd] '{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}',{empleado.Estado.idEstado}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JrodriguezExamenDesarroladorContext contex = new DL.JrodriguezExamenDesarroladorContext())
                {
                    var query = contex.Database.ExecuteSqlRaw($"[EmpleadoUpdate] {empleado.idEmpleado},'{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}',{empleado.Estado.idEstado}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
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

        public static ML.Result Delete(int idEmpleado) {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JrodriguezExamenDesarroladorContext contex = new DL.JrodriguezExamenDesarroladorContext())
                {
                    var query = contex.Database.ExecuteSqlRaw($"[EmpleadoDelete] {idEmpleado}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else { result.Correct = false; }
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JrodriguezExamenDesarroladorContext contex = new DL.JrodriguezExamenDesarroladorContext())
                {
                    var query = contex.Empleados.FromSqlRaw("[EmpleadoGetAll]").ToList();

                    result.Objects = new List<object>();

                    foreach (var item in query)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.idEmpleado = item.IdEmpleado;
                        empleado.NumeroNomina = item.NumeroNomina;
                        empleado.Nombre = item.Nombre;
                        empleado.ApellidoPaterno = item.ApellidoPaterno;
                        empleado.ApellidoMaterno = item.ApellidoMaterno;

                        empleado.Estado = new ML.Estado();
                        empleado.Estado.idEstado = int.Parse(item.IdEstado.ToString());
                        empleado.Estado.Nombre = item.Estado;

                        result.Objects.Add(empleado);
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

        public static ML.Result GetById(int idEmpleado)
        {
            ML.Result result = new ML.Result(); 

            try
            {
                using (DL.JrodriguezExamenDesarroladorContext contex = new DL.JrodriguezExamenDesarroladorContext())
                {
                    var query = contex.Empleados.FromSqlRaw($"[EmpleadoGetById] {idEmpleado}").AsEnumerable().FirstOrDefault();

                    ML.Empleado empleado = new ML.Empleado();
                    empleado.idEmpleado = query.IdEmpleado;
                    empleado.NumeroNomina = query.NumeroNomina;
                    empleado.Nombre = query.Nombre;
                    empleado.ApellidoPaterno = query.ApellidoPaterno;
                    empleado.ApellidoMaterno = query.ApellidoMaterno;

                    empleado.Estado = new ML.Estado();
                    empleado.Estado.idEstado = int.Parse(query.IdEstado.ToString());
                    empleado.Estado.Nombre = query.Nombre;

                    result.Object = empleado;

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