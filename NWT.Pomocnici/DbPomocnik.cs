using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWT.Pomocnici{
	public class DbPomocnik {

        private static readonly string CONNECTION_STRING = @"Data Source=.\SQLSERVER;Initial Catalog=NWT;Integrated Security=True";

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
	}
}
