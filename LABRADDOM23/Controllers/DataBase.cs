using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace LABRADDOM23.Controllers
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection _connection;
        public DataBase() { }

        public DataBase(string dbpath) 
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            // Creacion de tablas de base de datos
            _connection.CreateTableAsync<Models.Estudiantes>().Wait();
        }


        // Creacion de metodos crud de base de datos Create - Read - Update - Delete

        public Task<int> AddEstudiante(Models.Estudiantes est)
        {
            if(est.id == 0) 
            {
                return _connection.InsertAsync(est);
            }
            else
            {
                return _connection.UpdateAsync(est);
            }
        }

        public Task<List<Models.Estudiantes>> ObtenerListaEstudiante()
        {
            return _connection.Table<Models.Estudiantes>().ToListAsync(); 
        }

        public Task<Models.Estudiantes> ObtenerEstudiante(int pid)
        {
            return _connection.Table<Models.Estudiantes>().Where(i=> i.id == pid).FirstOrDefaultAsync();
        }

        public Task<int> DeleteEstudiante(Models.Estudiantes est)
        { 
            return _connection.DeleteAsync(est);
        }

    }
}
