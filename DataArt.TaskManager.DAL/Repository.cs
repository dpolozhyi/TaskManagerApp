using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataArt.TaskManager.Entities;

namespace DataArt.TaskManager.DAL
{
    public class Repository
    {
        private SqlConnection connection;



        public Repository() : this(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DataArt.TaskManager.Database_1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        public Repository(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
            this.connection.Open();
        }

        public IEnumerable<Entities.Task> GetData()
        {
            IList<Entities.Task> taskList = new List<Entities.Task>();
            SqlCommand sqlCommand = new SqlCommand("select Tasks.Id, Title, IsDone, Categories.Id, Name from Tasks join Categories on Tasks.Category_Id=Categories.Id;", this.connection);
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

        private int ParseInt(string value)
        {
            int num;
            Int32.TryParse(value, out num);
            return num;
        }
    }
}
