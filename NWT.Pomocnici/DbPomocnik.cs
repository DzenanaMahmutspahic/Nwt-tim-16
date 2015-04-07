﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWT.Pomocnici{ 
    /// <summary>
    /// Klasa koja sadrži podatke i metode za rad sa bazom podataka
    /// </summary>
	public class DbPomocnik {

        private static readonly string CONNECTION_STRING = @"Data Source=.\SQLSERVER;Initial Catalog=NWT;Integrated Security=True";
        //private static readonly string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=NWT;Integrated Security=True";
        //private static readonly string CONNECTION_STRING = @"workstation id=nwtbaza.mssql.somee.com;packet size=4096;user id=HarisJavoras_SQLLogin_1;pwd=7dtdicwprj;data source=nwtbaza.mssql.somee.com;persist security info=False;initial catalog=nwtbaza";

        /// <summary>
        /// Metoda za izvršavanje procedure na Bazi podataka
        /// </summary>
        /// <param name="NazivProcedure"></param>
        /// <param name="parametri"></param>   
        /// <returns></returns>
		public static DataTable IzvrsiProceduru(string NazivProcedure, Dictionary<string, object> parametri) {    
			using(SqlConnection conn = new SqlConnection(CONNECTION_STRING)) {
				conn.Open();

				SqlCommand cmd = new SqlCommand(NazivProcedure, conn);

				cmd.CommandType = CommandType.StoredProcedure;

				if(parametri != null)
					foreach(KeyValuePair<string, object> parametar in parametri) {
						cmd.Parameters.Add(new SqlParameter("@" + parametar.Key, parametar.Value));
					}

				DataTable odgovor = new DataTable();
				using(SqlDataReader rdr = cmd.ExecuteReader()) {
					while(rdr.Read()) {
						List<object> parametri1 = new List<object>();
						for(int i = 0; i < rdr.FieldCount; i++) {
							if(!odgovor.Columns.Contains(rdr.GetName(i)))
								odgovor.Columns.Add(rdr.GetName(i));
							parametri1.Add(rdr.GetValue(i));
						}
						odgovor.Rows.Add(parametri1.ToArray());
					}
				}
				return odgovor;
			}
		}

        /// <summary>
        /// Metoda proceduru na Bazi a kao parametre prosljeđuje vrijednosti propertija primljenog modela
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="imeProcedure"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DataTable IzvrsiProceduru<T>(string imeProcedure, T model)
        {
            var properties = model.GetType().GetProperties();
            Dictionary<string, object> parametri = new Dictionary<string,object>();
            foreach (var p in properties)
            {
                var p_vrijednost = p.GetValue(model);
                if (p_vrijednost != null)
                    parametri.Add(p.Name, p_vrijednost);
            }
            return IzvrsiProceduru(imeProcedure, parametri);
        }

        /// <summary>
        /// Metoda koja kreira objekat od rezultata izvršene procedure
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="imeProcedure"></param>
        /// <param name="parametri"></param>
        /// <returns></returns>
        public static T IzvrsiProceduru<T>(string imeProcedure, Dictionary<string, object> parametri) where T : new()
        {
            T odgovor = new T();
            var kolone = IzvrsiProceduru(imeProcedure, parametri).Rows[0];
            var properties = typeof(T).GetProperties();
            foreach (var p in properties)
            {
                if (kolone.Table.Columns.Contains(p.Name))
                {
                    var k = kolone[p.Name];
                    Type p_type = p.PropertyType;
                    
                    if(k!= null && !Convert.IsDBNull(k))
                        p.SetValue(odgovor, Convert.ChangeType(k, p_type));
                }
            }
            return odgovor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="imeProcedure"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<T2> IzvrsiProceduru<T1, T2>(string imeProcedure, T1 model) where T2:new()
        {
            //var properties = model.GetType().GetProperties();
            List<T2> odgovor = new List<T2>();

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(imeProcedure, conn);
                //SqlCommand cmd2 = new SqlCommand(imeProcedure, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                if (model != null)
                {
                    SqlCommandBuilder.DeriveParameters(cmd);
                    var modelProperties = model.GetType().GetProperties();
                    foreach (SqlParameter p in cmd.Parameters)
                    {
                        var properti = modelProperties.FirstOrDefault(y => y.Name == p.ParameterName.Substring(1));
                        if (properti != null)
                            cmd.Parameters[p.ParameterName].Value = properti.GetValue(model);
                    }

                }
                var odgovor_properties = typeof(T2).GetProperties();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        T2 cvor = new T2();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {   
                            var ovajProperty = odgovor_properties.FirstOrDefault(x=>x.Name == (rdr.GetName(i)));
                            var ovajValue = rdr.GetValue(i);
                            if ( ovajProperty != null && ovajValue != null && ovajValue != DBNull.Value)
                                 ovajProperty.SetValue(cvor, Convert.ChangeType(ovajValue, ovajProperty.PropertyType ));
                            //parametri1.Add(rdr.GetValue(i));
                        }
                        odgovor.Add(cvor);
                    }
                }
                return odgovor;
            }
        }
	}
}
