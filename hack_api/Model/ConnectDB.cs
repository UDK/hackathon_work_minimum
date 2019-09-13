//using Npgsql;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace workminimum.Models
//{
//    public class ConnectDB
//    {
//        private NpgsqlConnection getConnect()
//        {
//            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
//            var databaseUri = new Uri(databaseUrl);
//            var userInfo = databaseUri.UserInfo.Split(':');
//            var builder = new NpgsqlConnectionStringBuilder
//            {
//                Host = databaseUri.Host,
//                Port = databaseUri.Port,
//                Username = userInfo[0],
//                Password = userInfo[1],
//                Database = databaseUri.LocalPath.TrimStart('/')
//            };
//            return new NpgsqlConnection(builder.ToString());
//        }

//        public string insertNote(Note note)
//        {
//            var connect = getConnect();
//            try
//            {
//                connect.Open();
//                NpgsqlCommand commands = new NpgsqlCommand("INSERT into \"Note\"(body,\"lastTimeModified\",title,attachments,tags) values('" + note.body + "','" + DateTime.Now + "','" + note.title + "','" + string.Join(',', note.attachments) + "','" + string.Join(',', note.tags) + "')", connect);
//                return commands.ExecuteNonQuery().ToString();
//            }
//            catch(Exception o)
//            {
//                return o.ToString();
//            }
//            finally
//            {
//                connect.Close();
//            }
//        }
//    }
//}
