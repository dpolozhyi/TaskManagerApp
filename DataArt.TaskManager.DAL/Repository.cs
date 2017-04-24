using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataArt.TaskManager.Entities;

namespace DataArt.TaskManager.DAL
{
    public class Repository: IRepository, IDisposable
    {
        private SqlConnection connection;

        public Repository() : this(ConfigurationManager.ConnectionStrings["TaskConnection"].ConnectionString)
        {

        }

        public Repository(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
            this.connection.Open();
        }

        public IEnumerable<Entities.Task> GetTasksList()
        {
            IList<Entities.Task> taskList = new List<Entities.Task>();
            SqlCommand sqlCommand = new SqlCommand("GetTasksList", this.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    Entities.Task task = new Entities.Task();
                    task.Id = this.ParseInt(sqlReader[0].ToString());
                    task.Title = sqlReader[1].ToString();
                    task.IsDone = sqlReader[2].ToString() == "True" ? true : false;
                    Category category = new Category();
                    category.Id = this.ParseInt(sqlReader[3].ToString());
                    category.Name = sqlReader[4].ToString();
                    task.Category = category;
                    taskList.Add(task);
                }
            }
            return taskList;
        }

        public IEnumerable<Category> GetCategoriesList()
        {
            IList<Category> categoryList = new List<Category>();
            SqlCommand sqlCommand = new SqlCommand("GetCategoriesList", this.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    Category category = new Category();
                    category.Id = this.ParseInt(sqlReader[0].ToString());
                    category.Name = sqlReader[1].ToString();
                    categoryList.Add(category);
                }
            }
            return categoryList;
        }

        private int ParseInt(string value)
        {
            int num;
            Int32.TryParse(value, out num);
            return num;
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}
