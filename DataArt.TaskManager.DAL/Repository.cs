using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataArt.TaskManager.Entities;
using System.Diagnostics;
using DataArt.TaskManager.DAL.Exceptions;

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
            try
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
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw new DataSourceCommunicationException(ex.Message, ex);
            }
        }

        public IEnumerable<Category> GetCategoriesList()
        {
            try
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
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw new DataSourceCommunicationException(ex.Message, ex);
            }
        }

        public int AddTask(string title, int categoryId, bool isDone)
        {
            try
            {
                IList<Category> categoryList = new List<Category>();
                SqlCommand sqlCommand = new SqlCommand("AddTask", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
                sqlCommand.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;
                sqlCommand.Parameters.Add("@isDone", SqlDbType.Bit).Value = isDone;
                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw new DataSourceCommunicationException(ex.Message, ex);
            }
        }

        public int DeleteTaskById(int id)
        {
            try
            {
                IList<Category> categoryList = new List<Category>();
                SqlCommand sqlCommand = new SqlCommand("DeleteTask", this.connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                throw new DataSourceCommunicationException(ex.Message, ex);
            }
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
