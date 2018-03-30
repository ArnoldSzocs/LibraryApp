using LibraryApp.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class UserDAO : IUserDAO
    {

        ConnectionManager connection = ConnectionManager.GetConnection();
  
        public void Delete(long id)
        {
            String query = "DELETE FROM User WHERE id = " + id;
            connection.ExecuteQuery(query);
           
        }

        public void Delete(User user)
        {
            Delete(user.Id);
        }

        public void Insert(User user)
        {
            String query = "INSERT INTO User(username,password) VALUES('"+ user.Username + "','" + user.Password + "')";
            connection.ExecuteQuery(query);
        }

        public void InsertAll(List<User> users)
        {  
            foreach (var user in users)
            {
                Insert(user);
            }
        }

        public List<User> SelectAll()
        {
            List<User> users = new List<User>();
            String query = "SELECT * FROM User";
            MySqlDataReader reader = connection.ReadQuery(query);
            while (reader.Read()){
                User user = new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2)
                };
                users.Add(user);
            }
            return users;
        }

        public User SelectByUsername(string username)
        {
            String query = "SELECT * FROM User WHERE username = " + username;
            MySqlDataReader reader = connection.ReadQuery(query);
            if (reader.Read())
            {
                User user = new User();
                user.Id = reader.GetInt32(0);
                user.Username = reader.GetString(1);
                user.Password = reader.GetString(2);
                return user;
            }
            throw new EntityNotFoundException();
        }

        public User SelectOne(long id)
        {
            String query = "SELECT * FROM User WHERE id = " + id;
            MySqlDataReader reader = connection.ReadQuery(query);
            if (reader.Read())
            {
                User user = new User();
                user.Id = reader.GetInt32(0);
                user.Username = reader.GetString(1);
                user.Password = reader.GetString(2);
                return user;
            }
            throw new EntityNotFoundException();
        }

        public void Update(User user)
        {
            String query = "UPDATE User set username = " + user.Username + ", password = " + user.Password + " where ID = " + user.Id;
            connection.ExecuteQuery(query);
        }
    }
}
