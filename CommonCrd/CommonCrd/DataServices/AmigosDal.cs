using System;
using System.Data.SqlClient;
using System.Collections;
using CommonCrd.Models;
using static CommonCrd.Code.GLB;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;

namespace CommonCrd.DataServices
{
    public class CodeMsg
    {
        public int RetValue { get; set; }
        public string RowId { get; set; }
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }

        public CodeMsg()
        {
            RetValue = -99;
            RowId = "-1";
            ErrCode = -99;
            ErrMsg = "Erro na execucao do comando";
        }
    }
    public class A
    {
        public async static Task<int> Method( SqlCommand cmd)
        {
            await  cmd.ExecuteNonQueryAsync();   
            return 1;
        }
    }

    public class AmigosDal
    {
        public CodeMsg Incluir(AmigosMd Amg)
        {
            CodeMsg cm = new CodeMsg();
            try
            {
                string sql = "Insert into Amigos";
                       sql += "  (        Nome,          Address,          Email,          Phone  ) values ";
                       sql += $" ( '{@Amg.Nome}', '{@Amg.Address}', '{@Amg.Email}', '{@Amg.Phone}')";

                using SqlConnection cn = new SqlConnection(CnnString);
                using SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                cm.ErrCode = 0;
                cm.ErrMsg = $"Registro { Amg.Nome} gravado";
            } catch (Exception) { throw; }
            return cm;
        }
        public async Task<CodeMsg> IncluirAsync(AmigosMd Amg)
        {
            CodeMsg cm = new CodeMsg();
            try
            {
                string sql = "Insert into Amigos";
                sql += "  (        Nome,          Address,          Email,          Phone  ) values ";
                sql += $" ( '{@Amg.Nome}', '{@Amg.Address}', '{@Amg.Email}', '{@Amg.Phone}')";

                using SqlConnection cn = new SqlConnection(CnnString);
                using SqlCommand cmd = new SqlCommand(sql, cn);
                await cn.OpenAsync();
                await Task.Run(() => cmd.ExecuteNonQueryAsync() );
                cn.Close();

                cm.ErrCode = 0;
                cm.ErrMsg = $"Registro { Amg.Nome} gravado";
            } catch (Exception ex) { throw ex; }
            return cm;
        }
        public AmigosMd GetById(int RowId)
        {
            AmigosMd Amigo = new AmigosMd();
            try
            {
                string Sql = "Select * from Amigos where RowId = " + $"{ RowId}";

                using SqlConnection cn = new SqlConnection(CnnString);
                using SqlCommand cmd = new SqlCommand(Sql, cn);
                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                using DataTable dt = new DataTable();
                {
                    cn.Open(); da.Fill(dt); cn.Close();
                    if ( dt.Rows.Count > 0)
                    {
                        Amigo.Nome    = (string)dt.Rows[0]["Nome"];
                        Amigo.Address = (string)dt.Rows[0]["Address"];
                        Amigo.Phone   = (string)dt.Rows[0]["Phone"];
                        Amigo.Email   = (string)dt.Rows[0]["Email"];
                        Amigo.RowId   = (int)dt.Rows[0]["RowId"];                        
                    }                    
                }
            } catch (Exception ex) { throw ex; }
            return Amigo;
        }
        public async Task<AmigosMd> GetByIdAsync( int RowId)
        {
            AmigosMd Amigo = new AmigosMd();                   
            try
            {
                string Sql = "Select * from Amigos where RowId = " + $"{ RowId}";

                using SqlConnection cn = new SqlConnection( CnnString);
                using SqlCommand cmd = new SqlCommand( Sql, cn);
                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                using DataTable dt = new DataTable();
                {
                    await cn.OpenAsync();
                    await Task.Run(() => da.Fill(dt));

                    if (dt.Rows.Count > 0)
                    {
                        Amigo.Nome = (string)dt.Rows[0]["Nome"];
                        Amigo.Address = (string)dt.Rows[0]["Address"];
                        Amigo.Phone = (string)dt.Rows[0]["Phone"];
                        Amigo.Email = (string)dt.Rows[0]["Email"];
                        Amigo.RowId = (int)dt.Rows[0]["RowId"];
                    }
                    cn.Close();
                }
            }  catch (Exception ex) { throw ex; }
            return Amigo;
        }
        public List<AmigosMd> Listar( string sort)
        {
            DataTable dt = new DataTable();
            List<AmigosMd> Amigos = new List<AmigosMd>();

            try
            {
                string Sql = "Select * from Amigos" + $" order by {sort}";

                using SqlConnection cn = new SqlConnection(CnnString);
                using SqlCommand cmd = new SqlCommand(Sql, cn);
                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                cn.Open(); da.Fill(dt); cn.Close();

                //  Move data from table to list        
                foreach (DataRow dr in dt.Rows)
                {
                    AmigosMd A = new AmigosMd()
                    {
                        Nome = (string)dr["Nome"],
                        Address = (string)dr["Address"],
                        Phone = (string)dr["Phone"],
                        Email = (string)dr["Email"],
                        RowId = (int)dr["RowId"]
                    };
                    Amigos.Add(A);
                }
            }
            catch (Exception ex) { throw ex; }

            return Amigos;
        }
        public async Task<List<AmigosMd>> ListarAsync( string sort)
        {
            DataTable dt = new DataTable();
            List<AmigosMd> Amigos = new List<AmigosMd>();

            try
            {
                string Sql = "Select * from Amigos" + $" order by {sort}";

                using SqlConnection cn = new SqlConnection(CnnString);
                using SqlCommand cmd = new SqlCommand(Sql, cn);
                using SqlDataAdapter da = new SqlDataAdapter(cmd);
                {
                    cn.Open();
                    await Task.Run(() => da.Fill(dt));
                    cn.Close();
                }

                //  Move data from table to list        
                foreach (DataRow dr in dt.Rows)
                {
                    AmigosMd A = new AmigosMd()
                    {
                        Nome = (string)dr["Nome"],
                        Address = (string)dr["Address"],
                        Phone = (string)dr["Phone"],
                        Email = (string)dr["Email"],
                        RowId = (int)dr["RowId"]
                    };
                    Amigos.Add(A);
                }
            }
            catch (Exception ex) { throw ex; }

            return Amigos;
        }
        public CodeMsg Deletar(int RowId)
        {
            CodeMsg cm = new CodeMsg();
            try
            {
                string sql = "Delete from Amigos where RowId = " + $"{RowId}";

                using SqlConnection cn = new SqlConnection( CnnString);
                using SqlCommand cmd = new SqlCommand( sql, cn);
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    cm.ErrCode = 0;
                    cm.ErrMsg = $"Registro {RowId} excluido";
                }
            } catch (Exception ex) { throw ex; }

            return cm;
        }
        public async Task<CodeMsg> DeletarAsync( int RowId)
        {
            CodeMsg cm = new CodeMsg();
            try
            {
                string sql = "Delete from Amigos where RowId = " + $"{RowId}";

                using SqlConnection cn = new SqlConnection(CnnString);
                using SqlCommand cmd = new SqlCommand(sql, cn);
                {
                    await cn.OpenAsync();
                    await Task.Run(() => cmd.ExecuteNonQueryAsync());
                    cn.Close();

                    cm.ErrCode = 0;
                    cm.ErrMsg = $"Registro {RowId} excluido";
                }
            } catch (Exception ex) { throw ex; }

            return cm;
        }
    }
}