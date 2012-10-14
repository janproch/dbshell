using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.Utility
{
    public static class DbConnectionExtension
    {
        public static IDataReader RunOneSqlCommandReader(this DbConnection conn, string sql)
        {
            return RunOneSqlCommandReader(conn, sql, null, null);
        }

        public static IDataReader RunOneSqlCommandReader(this DbConnection conn, string sql, DbTransaction tran, int? timeout)
        {
            if (sql.StartsWith("@getschema"))
            {
                string[] items = sql.Split(' ');
                string entity = items[1].ToLower().Trim();
                if (entity == "databases") return new DataTableReader(conn.GetSchema("Databases"));
                if (entity == "tables") return new DataTableReader(conn.GetSchema("Tables"));
                if (entity == "columns") return new DataTableReader(conn.GetSchema("Columns", new string[] { null, null, items[2].Trim() }).SelectNewTable("1=1", "ORDINAL_POSITION ASC"));
            }
            DbCommand c = conn.CreateCommand();
            c.Connection = conn;
            if (timeout != null) c.CommandTimeout = timeout.Value;
            c.CommandText = sql;
            if (tran != null) c.Transaction = tran;
            try
            {
                return new CommandDataReader(c.ExecuteReader(), c);
            }
            catch (Exception err)
            {
                err.Data["sql"] = c.CommandText;
                if (c.Connection != null) c.Connection.FillInfo(err.Data);
                throw;
            }
        }

        public static void RunSqlCommands(this DbConnection conn, string sql)
        {
            DbTransaction trans = null;
            try
            {
                trans = conn.BeginTransaction();
            }
            catch (Exception)
            {
                trans = null;
            }

            try
            {
                foreach (string sql_item in GoSplitter.GoSplit(sql))
                {
                    using (DbCommand c = conn.CreateCommand())
                    {
                        if (trans != null) c.Transaction = trans;
                        c.Connection = conn;
                        c.CommandText = sql_item;
                        c.ExecuteNonQueryEx();
                    }
                }
            }
            catch
            {
                if (trans != null) trans.Rollback();
                throw;
            }

            if (trans != null) trans.Commit();
        }

        public static void ExecuteNonQueryEx(this DbCommand cmd)
        {
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                err.Data["sql"] = cmd.CommandText;
                if (cmd.Connection != null) cmd.Connection.FillInfo(err.Data);
                throw;
            }
        }

        public static void ExecuteNonQuery(this DbConnection conn, string sql)
        {
            ExecuteNonQuery(conn, sql, null, null);
        }

        public static void ExecuteNonQuery(this DbConnection conn, string sql, DbTransaction trans, int? timeout)
        {
            if (String.IsNullOrEmpty(sql)) return;
            if (sql.StartsWith("@use"))
            {
                string[] items = sql.Split(' ');
                conn.ChangeDatabase(items[1].Trim());
            }
            else
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    if (timeout != null) cmd.CommandTimeout = timeout.Value;
                    if (trans != null) cmd.Transaction = trans;
                    cmd.ExecuteNonQueryEx();
                }
            }
        }

        public static void ExecuteNonQueries(this DbConnection conn, string sql, DbTransaction tran, int? timeout)
        {
            foreach (string cmd in GoSplitter.GoSplit(sql))
            {
                ExecuteNonQuery(conn, cmd, tran, timeout);
            }
        }

        public static void ExecuteNonQueries(this DbConnection conn, string sql)
        {
            foreach (string cmd in GoSplitter.GoSplit(sql))
            {
                ExecuteNonQuery(conn, cmd);
            }
        }

        public static object ExecuteScalar(this DbConnection conn, string sql, DbTransaction tran)
        {
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Transaction = tran;
                return cmd.ExecuteScalar();
            }
        }

        public static T ExecuteScalar<T>(this DbConnection conn, string sql, DbTransaction tran)
        {
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Transaction = tran;
                return (T)Convert.ChangeType(cmd.ExecuteScalar(), typeof(T));
            }
        }

        public static object ExecuteScalar(this DbConnection conn, string sql)
        {
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                return cmd.ExecuteScalar();
            }
        }

        public static string ExecuteLongTextScalar(this DbConnection conn, string sql)
        {
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                StringBuilder sb = new StringBuilder();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sb.Append(reader[0].SafeToString());
                    }
                }
                return sb.ToString();
            }
        }

        public static T ExecuteScalar<T>(this DbConnection conn, string sql)
        {
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                object res = cmd.ExecuteScalar();
                if (typeof(T) == typeof(int?))
                {
                    if (res == null || res == DBNull.Value) return (T)(object)null;
                    return (T)(object)Int32.Parse(res.ToString());
                }
                return (T)Convert.ChangeType(res, typeof(T));
            }
        }

        public static void SafeChangeDatabase(this DbConnection conn, string dbname)
        {
            try
            {
                if (!String.IsNullOrEmpty(dbname) && conn != null) conn.ChangeDatabase(dbname);
            }
            catch (Exception err)
            {
                throw new DatabaseNotAccessibleError(dbname, err);
            }
        }

        //public static void SafeChangeDatabase(this DbConnection conn, ObjectPath objpath)
        //{
        //    if (objpath != null) SafeChangeDatabase(conn, objpath.DbName);
        //}

        //public static DataTable LoadTableFromQuery(this DbConnection conn, string sql)
        //{
        //    return LoadTableFromQuery(conn, sql, null);
        //}

        //public static DataTable LoadTableFromQuery(this DbConnection conn, string sql, int? maximumRecords)
        //{
        //    using (DbCommand cmd = conn.CreateCommand())
        //    {
        //        cmd.CommandText = sql;
        //        using (DbDataReader reader = cmd.ExecuteReader())
        //        {
        //            return reader.ToDataTable(maximumRecords);
        //        }
        //    }
        //}

        public static void FillInfo(this DbConnection conn, IDictionary data)
        {
            if (conn == null) return;
            try
            {
                data["sysconn_version"] = conn.ServerVersion;
            }
            catch (Exception err)
            {
                data["sysconn_version"] = err.Message;
            }
            data["sysconn_class"] = conn.GetType().FullName;
            data["sysconn_state"] = conn.State.ToString();
        }

        public static void RunScript(this DbConnection conn, Action<ISqlDumper> script, DbTransaction trans)
        {
            ConnectionSqlOutputStream sqlo = new ConnectionSqlOutputStream(conn, trans, GenericDialect.Instance);
            ISqlDumper fmt = GenericDatabaseFactory.Instance.CreateDumper(sqlo, SqlFormatProperties.Default);
            //fmt.ProgressInfo = progress;
            script(fmt);
        }

    }
}
