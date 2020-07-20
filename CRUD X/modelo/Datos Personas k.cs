
using CRUD_X.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TIC
{
    public static class DatosPersonask
    {
        public static string cadenaConexion = "server = DESKTOP-U1CHEML; database = TI2020; user id = sa; password = ayapamba259";
        public static int crear(DatosPersonas datospersonas)

        {
            //1. configurar la conexion con una fuente de datos 
            
            //definir un objeto tipo conexion
            SqlConnection conn = new SqlConnection(cadenaConexion);
            //2. escribir sentencia sql
            string sql = "insert into DatosPersonas(cedula, apellidos, nombres, sexo," +
            "fechaNacimiento, correo, estaturacm, peso) values (@cedula, @apellidos, @nombres, @sexo, @fechaNacimiento, @correo, @estaturacm, @peso)";
            //definir un comaando para ejcutar la operacion
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@cedula", datospersonas.Cedula);
            comando.Parameters.AddWithValue("@apellidos", datospersonas.Apellidos);
            comando.Parameters.AddWithValue("@nombres", datospersonas.Nombres);
            comando.Parameters.AddWithValue("@sexo", datospersonas.Sexo);
            comando.Parameters.AddWithValue("@fechaNacimiento", datospersonas.FechaNacimiento.Date);
            comando.Parameters.AddWithValue("@correo",datospersonas.Correo);
            comando.Parameters.AddWithValue("@estaturacm", datospersonas.Estatura);
            comando.Parameters.AddWithValue("@peso",datospersonas.Peso);
            //3.Se abre la conexion y se ejecuta el comando
            conn.Open();
         int x = comando.ExecuteNonQuery();
             
  
            //4.cerrar la conexion  
            conn.Close();
            return x;
    
           
        }
        


 public static DataTable getAll()
        {


            //1. definir y configurar conexión
            SqlConnection conn = new SqlConnection(cadenaConexion);
            //2. Definir y Cinfigurar la operacion a realizar en el motor de BDD 
            //escribir sentencia sql
            string sql = "select  cedula Cédula,apellidos,nombres,sexo ," + "FechaNacimiento,correo,Estaturacm,peso " + "from DatosPersonas " +
                "order by apellidos,nombres";
            //2.1 Definir un adptador de datos: es un puente que permite pasa los datos de muestra , hacia el datatable
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            //3 recuperamos los datos 
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;


        }





    }
}   
